/*
 * Author: khuyennv
 * email:vankhuyen.nguyen@vt.vn
 * YM:thansauvtc@yahoo.com.vn
 */

using System;
using System.Web;
using System.Web.Caching;

namespace Paygate.Utility
{
    public class CachingUtility
    {
        #region --- Khai báo tên các session ---
        //Danh sách chức năng hiển thị trên paygate
        public const string CachePaygateControl = "PaygateControls";

        //Danh sách chức năng hiển thị trên ví điện tử
        public const string CacheWalletControl = "WalletControls";

        //Danh sách chức năng hiển thị trên hệ thống phân phối
        public const string CacheDisutributionControl = "DistributionControls";


        public const string CacheInvalidAccount = "InvalidAccount";

        #endregion




        /// <summary>
        /// lấy ra giá trị session
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object GetValue(string name)
        {
            return HttpRuntime.Cache.Get(name.Trim().ToLower());
        }




        /// <summary>
        /// hủy một session
        /// </summary>
        /// <param name="name"></param>
        public void Remove(string name)
        {
            HttpRuntime.Cache.Remove(name.Trim().ToLower());

        }




        /// <summary>
        /// Nạp giá trị cho session
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void SetValue(string name, object value)
        {

            HttpRuntime.Cache.Insert(name.Trim().ToLower(), value, null, DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.High, null);

        }


        public static Int64 CheckIpValid()
        {
            var ip = HttpContext.Current.Request.UserHostAddress.Trim();
            var login = new CachingUtility().GetValue(ip);
            if (login == null) return 0;
            var array = login.ToString().Split('|');
            Int64 logcount;
            Int64.TryParse(array[0], out logcount);
            DateTime date;
            DateTime.TryParse(array[1], out date);
            if (date.Year < 2011) return 0;
            var exprize = DateTime.Now - date;
            if (exprize.Hours > HourExprize)
            {
                new CachingUtility().Remove(ip);
                return 0;
            }
            if (logcount >= 200)
            {
                HttpContext.Current.Response.Redirect("http://google.com.vn", false);
                return logcount;
            }
            return logcount;
        }

        private const int HourExprize = 2 * 2;
        public static Int64 CheckLogin(string name)
        {
            CheckIpValid();
            var login = new CachingUtility().GetValue(name);
            if (login == null) return 0;
            var array = login.ToString().Split('|');

            Int64 logcount;
            Int64.TryParse(array[0], out logcount);
            DateTime date;
            DateTime.TryParse(array[1], out date);
            if (date.Year < 2011) return 0;
            var exprize = DateTime.Now - date;
            if (exprize.Hours > HourExprize)
            {
                new CachingUtility().Remove(name);
                return 0;
            }
            return logcount;
        }



        public static void LoginFailed(string name)
        {
            var ip = HttpContext.Current.Request.UserHostAddress.Trim();
            var countIp = CheckIpValid();
            new CachingUtility().SetValue(ip,string.Format("{0}|{1}",countIp + 1,DateTime.Now));
            var loginName = CheckLogin(name);
            new CachingUtility().SetValue(name, string.Format("{0}|{1}", loginName + 1, DateTime.Now));
        }


        public static void LoginSuccess(string name)
        {
            var ip = HttpContext.Current.Request.UserHostAddress.Trim();
            new CachingUtility().Remove(name);
            new CachingUtility().Remove(ip);
        }

        public static void GotoSSO()
        {
            var querystring = Config.GetStringLanguage();
            querystring = querystring.ToLower().Contains("vi") ? string.Empty : querystring;
            var returnUrl = Config.GetMenuUrl() + HttpContext.Current.Request.Url.Query;
            querystring = string.IsNullOrEmpty(querystring)
                              ? "?ReturnURL=" + HttpUtility.UrlEncode(returnUrl)
                              : querystring + "&ReturnURL=" + HttpUtility.UrlEncode(returnUrl);

            HttpContext.Current.Response.Redirect(string.Format("{0}dang-nhap.html{1}", Config.SSOUrl, querystring), false);
        }
    }
}

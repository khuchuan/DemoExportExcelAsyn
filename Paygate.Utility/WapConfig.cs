using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;

namespace Paygate.Utility
{
    public class WapConfig
    {
        public static int AccountID
        {
            get
            {
                try
                {

                    if (HttpContext.Current != null && HttpContext.Current.User != null && HttpContext.Current.User.Identity != null && !HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        new SessionUtility().Remove(SessionUtility.SessionAccount);
                        return 0;
                    }

                    var current = new SessionUtility().GetValue(SessionUtility.SessionAccount);
                    if (current == null)
                    {
                        var isLogin = HttpContext.Current.User.Identity.Name;
                        if (!string.IsNullOrEmpty(isLogin))
                        {
                            current = isLogin;
                            new SessionUtility().SetValue(SessionUtility.SessionAccount, isLogin);
                        }
                    }
                    else
                    {
                        var isLogin = HttpContext.Current.User.Identity.Name;
                        if (current.ToString() != isLogin)
                        {
                            HttpContext.Current.Session.RemoveAll(); //Remove toàn bộ Session
                            current = isLogin;
                            new SessionUtility().SetValue(SessionUtility.SessionAccount, isLogin);
                        }
                    }
                    if (current == null) return 0;
                    var arrCurrent = current.ToString().Split('|');
                    if (arrCurrent.Length < 5) return 0;
                    var accountID = Convert.ToInt32(arrCurrent[0]);
                    return accountID;
                }
                catch (Exception ex)
                {
                    NLogLogger.PublishException(ex);
                    return 0;
                }
            }
        }

        public static string AccountName
        {
            get
            {
                try
                {
                    if (HttpContext.Current != null && HttpContext.Current.User != null && HttpContext.Current.User.Identity != null && !HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        new SessionUtility().Remove(SessionUtility.SessionAccount);
                        return string.Empty;
                    }

                    var current = new SessionUtility().GetValue(SessionUtility.SessionAccount);
                    if (current == null)
                    {
                        var isLogin = HttpContext.Current.User.Identity.Name;
                        if (!string.IsNullOrEmpty(isLogin))
                        {
                            current = isLogin;
                            new SessionUtility().SetValue(SessionUtility.SessionAccount, current);
                        }
                    }
                    else
                    {
                        var isLogin = HttpContext.Current.User.Identity.Name;
                        if (current.ToString() != isLogin)
                        {
                            HttpContext.Current.Session.RemoveAll(); //Remove toàn bộ Session
                            current = isLogin;
                            new SessionUtility().SetValue(SessionUtility.SessionAccount, isLogin);
                        }
                    }
                    if (current == null) return string.Empty;
                    var arrCurrent = current.ToString().Split('|');
                    if (arrCurrent.Length < 5) return string.Empty;
                    var accountName = arrCurrent[1];
                    if (!string.IsNullOrEmpty(accountName)) CachingUtility.LoginSuccess(CachingUtility.CacheInvalidAccount + accountName);
                    return accountName;
                }
                catch (Exception ex)
                {
                    NLogLogger.PublishException(ex);
                    return string.Empty;
                }
            }
        }


        public static byte AccountTypeID
        {
            get
            {
                try
                {
                    if (HttpContext.Current != null && HttpContext.Current.User != null && HttpContext.Current.User.Identity != null && !HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        new SessionUtility().Remove(SessionUtility.SessionAccount);
                        return 0;
                    }

                    var current = new SessionUtility().GetValue(SessionUtility.SessionAccount);
                    if (current == null)
                    {
                        var isLogin = HttpContext.Current.User.Identity.Name;
                        if (!string.IsNullOrEmpty(isLogin))
                        {
                            current = isLogin;
                            new SessionUtility().SetValue(SessionUtility.SessionAccount, isLogin);
                        }
                    }
                    else
                    {
                        var isLogin = HttpContext.Current.User.Identity.Name;
                        if (current.ToString() != isLogin)
                        {
                            HttpContext.Current.Session.RemoveAll(); //Remove toàn bộ Session
                            current = isLogin;
                            new SessionUtility().SetValue(SessionUtility.SessionAccount, isLogin);
                        }
                    }
                    if (current == null) return 0;
                    var arrCurrent = current.ToString().Split('|');
                    if (arrCurrent.Length < 5) return 0;
                    var accountTypeID = Convert.ToByte(arrCurrent[2]);
                    return accountTypeID;
                }
                catch (Exception ex)
                {
                    NLogLogger.PublishException(ex);
                    return 0;
                }
            }
        }

        public static string SessionKey
        {
            get
            {
                try
                {
                    if (HttpContext.Current != null && HttpContext.Current.User != null && HttpContext.Current.User.Identity != null && !HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        new SessionUtility().Remove(SessionUtility.SessionAccount);
                        return string.Empty;
                    }

                    var current = new SessionUtility().GetValue(SessionUtility.SessionAccount);
                    if (current == null)
                    {
                        var isLogin = HttpContext.Current.User.Identity.Name;
                        if (!string.IsNullOrEmpty(isLogin))
                        {
                            current = isLogin;
                            new SessionUtility().SetValue(SessionUtility.SessionAccount, current);
                        }
                    }
                    else
                    {
                        var isLogin = HttpContext.Current.User.Identity.Name;
                        if (current.ToString() != isLogin)
                        {
                            HttpContext.Current.Session.RemoveAll(); //Remove toàn bộ Session
                            current = isLogin;
                            new SessionUtility().SetValue(SessionUtility.SessionAccount, isLogin);
                        }
                    }
                    if (current == null) return string.Empty;
                    var arrCurrent = current.ToString().Split('|');
                    if (arrCurrent.Length < 5) return string.Empty;
                    var sessionKey = arrCurrent[3];
                    return sessionKey;
                }
                catch (Exception ex)
                {
                    NLogLogger.PublishException(ex);
                    return string.Empty;
                }
            }
        }

        public static string PasswordKey
        {
            get
            {
                try
                {
                    if (HttpContext.Current != null && HttpContext.Current.User != null && HttpContext.Current.User.Identity != null && !HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        new SessionUtility().Remove(SessionUtility.SessionAccount);
                        return string.Empty;
                    }

                    var current = new SessionUtility().GetValue(SessionUtility.SessionAccount);
                    if (current == null)
                    {
                        var isLogin = HttpContext.Current.User.Identity.Name;
                        if (!string.IsNullOrEmpty(isLogin))
                        {
                            current = isLogin;
                            new SessionUtility().SetValue(SessionUtility.SessionAccount, current);
                        }
                    }
                    else
                    {
                        var isLogin = HttpContext.Current.User.Identity.Name;
                        if (current.ToString() != isLogin)
                        {
                            HttpContext.Current.Session.RemoveAll(); //Remove toàn bộ Session
                            current = isLogin;
                            new SessionUtility().SetValue(SessionUtility.SessionAccount, isLogin);
                        }
                    }
                    if (current == null) return string.Empty;
                    var arrCurrent = current.ToString().Split('|');
                    if (arrCurrent.Length < 5) return string.Empty;
                    var passwordKey = arrCurrent[4];
                    return passwordKey;
                }
                catch (Exception ex)
                {
                    NLogLogger.PublishException(ex);
                    return string.Empty;
                }
            }
        }

        public static string ApplicationUrl
        {
            get
            {
                var url = ConfigurationManager.AppSettings["Paygate"] ?? "http://" + System.Web.HttpContext.Current.Request.Url.Authority +
                   System.Web.HttpContext.Current.Request.ApplicationPath;
                return url.EndsWith("/") ? url : url + "/";
            }
        }


        //Hằng số các CategoryId---
        public enum CategoryId : int
        {
            NapTienTraSauMobi = 130,
            NapTienHocmaiVn = 40,
            NapTienTruongTrucTuyen = 41,
            NapVcoin = 115,
            NapPoint = 35,
            HunaRobo = 182,
            HunaTalk = 181,
            NapBac = 187,
            NapmCash = 209,//test: 193 - thật: 209
            ThanhToanDcomTraTruoc = 200,
            ThanhToanDcomTraSau = 202,
            NapScoin = 306,// thật là 310
            VGG = 331, // VGG nạp GG
            ZingXu = 291, // MService nạp Zing Xu
            OnCash = 312, // MService nạp OnCash
            VNPTHCM = 290, // Thanh toán cước VNPT HCM
            InterNetVNPTHCM = 277, // Thanh toán cước VNPT HCM
            JetStar = 289 //Thanh toán vé máy bay JetStar
        }

        public static bool IsMobileBrowser()
        {
            //GETS THE CURRENT USER CONTEXT
            HttpContext context = HttpContext.Current;

            //FIRST TRY BUILT IN ASP.NT CHECK
            if (context.Request.Browser.IsMobileDevice)
            {
                return true;
            }
            //THEN TRY CHECKING FOR THE HTTP_X_WAP_PROFILE HEADER
            if (context.Request.ServerVariables["HTTP_X_WAP_PROFILE"] != null)
            {
                return true;
            }
            //THEN TRY CHECKING THAT HTTP_ACCEPT EXISTS AND CONTAINS WAP
            if (context.Request.ServerVariables["HTTP_ACCEPT"] != null &&
                context.Request.ServerVariables["HTTP_ACCEPT"].ToLower().Contains("wap"))
            {
                return true;
            }
            //AND FINALLY CHECK THE HTTP_USER_AGENT 
            //HEADER VARIABLE FOR ANY ONE OF THE FOLLOWING
            if (context.Request.ServerVariables["HTTP_USER_AGENT"] != null)
            {
                //Create a list of all mobile types
                var mobiles =
                    new[]
                {
                    "midp", "j2me", "avant", "docomo", 
                    "novarra", "palmos", "palmsource", 
                    "240x320", "opwv", "chtml",
                    "pda", "windows ce", "mmp/", 
                    "blackberry", "mib/", "symbian", 
                    "wireless", "nokia", "hand", "mobi",
                    "phone", "cdm", "up.b", "audio", 
                    "SIE-", "SEC-", "samsung", "HTC", 
                    "mot-", "mitsu", "sagem", "sony"
                    , "alcatel", "lg", "eric", "vx", 
                    "NEC", "philips", "mmm", "xx", 
                    "panasonic", "sharp", "wap", "sch",
                    "rover", "pocket", "benq", "java", 
                    "pt", "pg", "vox", "amoi", 
                    "bird", "compal", "kg", "voda",
                    "sany", "kdd", "dbt", "sendo", 
                    "sgh", "gradi", "jb", "dddi", 
                    "moto", "iphone"
                };

                //Loop through each item in the list created above 
                //and check if the header contains that text
                return mobiles.Any(s => context.Request.ServerVariables["HTTP_USER_AGENT"].ToLower().Contains(s.ToLower()));
            }

            return false;
        }
    }
}

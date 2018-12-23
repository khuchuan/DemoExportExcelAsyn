using System;
using System.Web;
using System.Web.Security;

namespace Paygate.Utility
{
    public class CookieUtility
    {
        public static void RemoveAllCookie()
        {
            for (int i = 0; i < HttpContext.Current.Request.Cookies.Count; i++)
            {
                var cookies = HttpContext.Current.Request.Cookies.Get(i);

                if (cookies.Name == FormsAuthentication.FormsCookieName) continue;
                if (cookies.Name == Config.COOKIE_EVENT_NAME) continue;

                cookies.Expires = DateTime.Now.AddDays(-1);
                cookies.Value = string.Empty;
                HttpContext.Current.Response.Cookies.Set(cookies);
            }
        }

        public static void SetCookie(string name, string value, int minutes)
        {
            HttpCookie cookies = new HttpCookie(name);
            cookies.Value = value;
            cookies.Expires = DateTime.Now.AddMinutes(minutes);
            HttpContext.Current.Response.Cookies.Set(cookies);
        }

        public static HttpCookie GetCookie(string name)
        {
            HttpCookie cookies = new HttpCookie(name);
            cookies = HttpContext.Current.Request.Cookies[name];
            if (cookies != null)
                return cookies;
            return null;
         }

        public static void RemoveCookie(string name)
        {
            HttpCookie cookies = new HttpCookie(name);
            cookies = HttpContext.Current.Request.Cookies[name];
            if (cookies != null)
            {
                cookies.Value = string.Empty;
                cookies.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Set(cookies);
            }
        }
    }
}

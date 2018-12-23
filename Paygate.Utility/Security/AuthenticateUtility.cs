using System.Collections.Generic;
using System.Web;


namespace Paygate.Utility.Security
{
    public class AuthenticateUtility
    {


        public static bool ValidateForm()
        {
            var listinvalid = new List<string> { "onmouseover", "onmouseout", "onclick", "onblur", "onfocus", "alert", "prompt", "javascript", "click","script" };
            var querystring = HttpContext.Current.Request.QueryString;
            if (querystring.Count == 0) return true;
            for (var index = 0; index < querystring.Count; index++)
            {
                var query = querystring[index];
                if (string.IsNullOrEmpty(query)) continue;
                foreach (var s in listinvalid)
                {
                    if (query.ToLower().Contains(s))
                        HttpContext.Current.Response.Redirect(Config.ApplicationUrl);
                }
            }
            return true;
        }

    }
}

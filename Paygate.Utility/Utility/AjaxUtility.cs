using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace Paygate.Utility.Utility
{
    public class AjaxUtility
    {
        public static void SetDefaultButton(System.Web.UI.Page page, string buttonClientId)
        {
            var scriptText = "window.setTimeout(ButtonClientID='" + buttonClientId + "',20);";
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "validationAlert", scriptText, true);
        }
    }
}

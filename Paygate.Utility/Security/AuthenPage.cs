using System;

namespace Paygate.Utility.Security
{
    public class AuthenPage : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            Config.SystemMaintain();
            //if (WapConfig.IsMobileBrowser())
            //{
            //    Response.Redirect("https://paygate.vtc.vn/wap3/");
            //    return;
            //}
            Config.SetLanguage();
            base.OnInit(e);
        }

        public new string Title { get; set; }
    }
}

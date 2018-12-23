
using System.Web.UI;

namespace Paygate.Utility
{
    public class Messenger
    {
        /// <summary>
        /// Tung ra thông báo và không cần focus vào đối tượng nào
        /// </summary>
        /// <param name="page"></param>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void Message(Page page, string message, string title)
        {
            var scriptText = "jAlert('" + message + "', '" + title + "');";
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "validationAlert", scriptText, true);
        }


        /// <summary>
        /// Tung ra thông báo và sẽ focus con trỏ vào đối tượng có clientID được truyền vào sau khi click vào nút OK
        /// </summary>
        /// <param name="page"></param>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="clientId"></param>
        public static void Message(Page page, string message, string title, string clientId)
        {
            var scriptText = "jAlert('" + message + "', '" + title + "',function(){$('#" + clientId + "').select();}); ";
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "validationAlert", scriptText, true);
        }



        public static void Message(Page page, string message, string title, string clientId, string popupid)
        {
            var scriptpopup = "var position= $('#" + clientId + "').position();";
            scriptpopup += " $('#" + popupid + "').css('left', position.left-100 );";
            scriptpopup += " $('#" + popupid + "').css('top ', position.top + 30 );";
            scriptpopup += " $('#" + popupid + "').show();";
            var scriptText = "jAlert('" + message + "', '" + title + "',function(){$('#" + clientId + "').select();" + scriptpopup + "}); ";
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "validationAlert", scriptText, true);
        }


        public static void Message(Page page, string message, string title, string url, string clientId, int width, int height)
        {
            var scriptText = string.Format("ShowDialog('{0}','{1}','{2}','{3}',{4},{5});", title, message, url, clientId, width, height);
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "validationAlert", scriptText, true);
        }

        public static void Message_CloseOTP(Page page, string message, string title, string url, string clientId, int width, int height)
        {
            var scriptText = string.Format("ShowDialog_CloseParent('{0}','{1}','{2}','{3}',{4},{5});", title, message, url, clientId, width, height);
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "validationAlert", scriptText, true);
        }
        public static void Message(Page page, string message, string title, string url, int width, int height, string urlRedirect)
        {
            var scriptText = string.Format("ShowDialog_Redirect('{0}','OK','{1}','{2}',{3},{4},'{5}');", title, message, url, width, height, urlRedirect);
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "validationAlert", scriptText, true);
        }

        /// <summary>
        /// Message thông báo, Click btnName redirect sang urlRedirect, Click X close popup
        /// </summary>
        /// <param name="page"></param>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="url"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="urlRedirect"></param>
        /// <param name="XClose"></param>
        public static void Message(Page page, string message, string title, string btnContinueName, string url, int width, int height, string urlRedirect, bool XClose)
        {
            var scriptText = string.Format(XClose ? "ShowDialog_OkRedirect_XClose('{0}','{1}','{2}','{3}',{4},{5},'{6}');" : "ShowDialog_Redirect('{0}','{1}','{2}','{3}',{4},{5},'{6}');", title, btnContinueName, message, url, width, height, urlRedirect);
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "validationAlert", scriptText, true);
        }

        /// <summary>
        /// Message thông báo, Click Ok redirect sang urlRedirect, Click X close popup
        /// </summary>
        /// <param name="page"></param>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <param name="url"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="urlRedirect"></param>
        /// <param name="XClose"></param>
        public static void Message(Page page, string message, string title, string url, int width, int height, string urlRedirect, bool XClose)
        {
            Message(page, message, title, "OK", url, width, height, urlRedirect, XClose);
        }

        public static void ReCallUpload(Page page)
        {
            var script = "UploadFile();";
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "validationAlert", script, true);
        }

        public static void Download(Page page, string url)
        {
            var script = "Download('" + url + "');";
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "validationAlert", script, true);
        }
        public static void Unload(Page page, string method)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "validationAlert", method, true);
        }
        public static void UnloadCard(Page page, string method)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "validationAlert", method, true);
        }
        public static void MessageConfirm(Page page, string title, string message, string url, string clientId, int width, int height)
        {
            var scriptText = string.Format("ShowConfirm('{0}','{1}','{2}','{3}',{4},{5});", title, message, url, clientId, width, height);
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "validationAlert", scriptText, true);
        }
        public static void Message(Page page, string message, string title, string url, string clientId, int width, int height, string method)
        {
            var scriptText = string.Format("ShowDialog('{0}','{1}','{2}','{3}',{4},{5});" + method, title, message, url, clientId, width, height);
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "validationAlert", scriptText, true);
        }

        public static void MessageMutilPhone(Page page, string message, string title, string url, string clientId, int width, int height)
        {
            var scriptText = string.Format("ShowDialog('{0}','{1}','{2}','{3}',{4},{5});UploadFile();", title, message, url, clientId, width, height);
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "validationAlert", scriptText, true);
        }
        public static void MessageDiscount(Page page, string message, string title, string url, string clientId, int width, int height, int count, int pageindex)
        {
            var scriptText = string.Format("ShowDialog('{0}','{1}','{2}','{3}',{4},{5});setTimeout('LoadPage({6},{7})',100);", title, message, url, clientId, width, height,count,pageindex);
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "validationAlert", scriptText, true);
        }
        public static void ExecuteSclipt(Page page, string sclipt)
        {
            ScriptManager.RegisterClientScriptBlock(page, page.GetType(), "validationAlert", sclipt, true);
        }
    }
}

using System;
using System.IO;
using System.Net;
using System.Web;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;
using System.Web.UI;



namespace Paygate.Utility
{
    public static class WebPost
    {
        /// <summary>
        /// Check Validate khi xác minh website tích hợp trong chức năng tích hợp website Paygate 3 - Comment by: NhatND 2011/11/25
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        static public bool CheckValidUrl(string url)
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "GET";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TURE if the Status code == 200
                return (response.StatusCode != HttpStatusCode.RequestTimeout &&
                   response.StatusCode != HttpStatusCode.BadGateway &&
                   response.StatusCode != HttpStatusCode.GatewayTimeout);
            }
            catch (WebException webEx)
            {
                if (webEx.Response != null)
                {
                    using (HttpWebResponse exResponse = (HttpWebResponse)webEx.Response)
                    {
                        return (exResponse.StatusCode != HttpStatusCode.RequestTimeout &&
                          exResponse.StatusCode != HttpStatusCode.BadGateway &&
                          exResponse.StatusCode != HttpStatusCode.GatewayTimeout);
                    }
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                NLogLogger.Info(url + "\t" + ex);
                return false;
            }
        }

        // Send data to BankGate
        static public void PostDataToBankGate(string transXML, string inProcessData)
        {
            // Resources.Controls.Recharge.Money.InProcessData
            var destinationUrl = Config.PaygateUrlGateBanks ?? "https://paygate.vtc.vn/public/";
            var infor = "<div align='center'><h2><font color='red'> " 
                + inProcessData + " </font></h2></div>";

            destinationUrl = destinationUrl + "MerchantCheckout.ashx";//trang nay o noi khac.
            var data = Encrypt.EncryptTripleDes(Config.MerchantSecurityKey ?? "487eea192e6748b4eb06fed0a8eaec5d", transXML);

            var requestBuilder = new ParamBuilder();
            requestBuilder.AddParam("MERCHANTCODE", Config.VtoAccountMerchantCode);
            requestBuilder.AddParam("MERCHANT_DATA", data);
            var checkOutUrl = WebPost.SendPost(requestBuilder.GetParamString(), destinationUrl);
            if (checkOutUrl.ToLower().StartsWith("https://") || checkOutUrl.ToLower().StartsWith("http://"))
            {
                System.Web.HttpContext.Current.Response.Redirect(checkOutUrl, false);
                //Response.Redirect(checkOutUrl, false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
            else
            {              
                System.Web.HttpContext.Current.Response.Write(checkOutUrl.Replace("<form", infor + "<form "));
                System.Web.HttpContext.Current.Response.Flush();
                HttpContext.Current.ApplicationInstance.CompleteRequest();
                System.Web.HttpContext.Current.Response.End();              
            }
        }


        static public void PostToMerchant(string data, string sign, string url)
        {           
            bool SendResult = false;
            try
            {
                string contents = "data=" + HttpUtility.UrlEncode(data);
                contents += "&sign=" + HttpUtility.UrlEncode(sign);
                byte[] contentPost = System.Text.Encoding.ASCII.GetBytes(contents);

                for (int i = 0; i < 3; i++)
                {
                    SendResult = SendNotifyStateChangeOrder(url, contentPost);
                    if (SendResult) break;
                    System.Threading.Thread.Sleep(1000);
                }
                NLogLogger.Info("post success: " + data + ", sign: " + sign );
            }
            catch (Exception ex)
            {
                NLogLogger.Info(ex.Message);
            }

            if (!SendResult)
            {
                NLogLogger.Info("Can not POST data :\t" + data + ":\t to" + url, true);
            }
        }

        static public bool SendNotifyStateChangeOrder(string _NotifyURL, byte[] contentPost)
        {
            bool success = false;
            try
            {
                CookieContainer cookie = new CookieContainer();
                System.Net.ServicePointManager.Expect100Continue = false;
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(_NotifyURL);
                myRequest.Method = "POST";
                myRequest.ContentLength = contentPost.Length;
                myRequest.CookieContainer = cookie;
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.KeepAlive = false;

                using (Stream requestStream = myRequest.GetRequestStream())
                {
                    requestStream.Write(contentPost, 0, contentPost.Length);
                }

                string responseXml = string.Empty;
                using (HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse())
                {
                    if (myResponse.StatusCode != HttpStatusCode.OK)
                    {
                        success = false;
                    }
                    else
                    {
                        success = true;
                    }
                }
            }
            catch (Exception ex)
            {
                NLogLogger.Info(ex.Message);
                NLogLogger.Info(string.Format("_NotifyURL:{0},postToMerchant:{1}", _NotifyURL, System.Text.Encoding.ASCII.GetString(contentPost)));
            }
            return success;
        }

        /// <summary>Send the Message to PalPal Checkout</summary>
        public static string SendPost(string postData, string url)
        {
            bool success = false;
            string resp;
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] data = encoding.GetBytes(postData);

            System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();

            System.Net.ServicePointManager.Expect100Continue = false;

            CookieContainer cookie = new CookieContainer();
            HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
            myRequest.Method = "POST";
            myRequest.ContentLength = data.Length;
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.KeepAlive = false;
            myRequest.CookieContainer = cookie;

            myRequest.AllowAutoRedirect = false;

            using (Stream requestStream = myRequest.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
            }


            string responseXml = string.Empty;
            try
            {
                using (HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse())
                {
                    if (myResponse.StatusCode != HttpStatusCode.OK)
                        success = false;
                    else
                        success = true;
                    using (Stream respStream = myResponse.GetResponseStream())
                    {
                        using (StreamReader respReader = new StreamReader(respStream))
                        {
                            responseXml = respReader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException webEx)
            {
                if (webEx.Response != null)
                {
                    using (HttpWebResponse exResponse = (HttpWebResponse)webEx.Response)
                    {
                        using (StreamReader sr = new StreamReader(exResponse.GetResponseStream()))
                        {
                            responseXml = sr.ReadToEnd();
                        }
                    }
                }
            }



            if (success)
            {
                resp = responseXml;
            }
            else
            {
                resp = responseXml;

            }

            return resp;
        }

        public static object GetHttpResponse(string url)
        {
            object response = null;
            try
            {
                System.Net.ServicePointManager.CertificatePolicy = new TrustAllCertificatePolicy();
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);

                myRequest.Method = "GET";
                //myRequest.ContentLength = data.Length;
                myRequest.CookieContainer = new CookieContainer();
                //myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.ContentType = "text/xml; encoding='utf-8'";
                myRequest.KeepAlive = false;

                using (HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse())
                {
                    using (var reader = new StreamReader(myResponse.GetResponseStream()))
                    {
                        if (reader != null)
                        {
                            response = reader.ReadToEnd();
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Graph API Errors or general web exceptions 

                response = ex.Message;

            }
            catch (Exception)
            { }

            return response;
        }


        /// <summary>
        ///    Classed used to bypass self-signed server certificate
        /// </summary>
        /// <remarks>
        ///     To be used in development only.
        /// </remarks>
        public class TrustAllCertificatePolicy : System.Net.ICertificatePolicy
        {
            public TrustAllCertificatePolicy()
            { }

            public bool CheckValidationResult(ServicePoint sp,
              X509Certificate cert, WebRequest req, int problem)
            {
                return true;
            }
        }
    }
       

    public class ParamBuilder
    {
        System.Text.StringBuilder paramString;

        public ParamBuilder()
        {
            paramString = new System.Text.StringBuilder();
        }

        public void AddParam(string Name, string Value)
        {
            if (paramString.Length > 0)
                paramString.Append("&");

            paramString.Append(Name);
            paramString.Append("=");
            paramString.Append(HttpUtility.UrlEncode(Value));
        }

        public string GetParamString()
        {
            return paramString.ToString();
        }

        public string BuildRequestData(NameValueCollection paramCollection)
        {
            foreach (string name in paramCollection.AllKeys)
            {
                this.AddParam(name, paramCollection[name]);
            }
            return this.GetParamString();
        }
    }
}

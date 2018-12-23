﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.225
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

// 
// This source code was auto-generated by wsdl, Version=4.0.30319.1.
// 
namespace Paygate.Utility
{


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "EmailServiceSoap", Namespace = "http://tempuri.org/")]
    public partial class EmailService : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        private System.Threading.SendOrPostCallback UpdateStatusEmailOperationCompleted;

        private System.Threading.SendOrPostCallback CheckEmailExistsOperationCompleted;

        private System.Threading.SendOrPostCallback SendEMailOperationCompleted;

        private System.Threading.SendOrPostCallback EventEbankOperationCompleted;

        private System.Threading.SendOrPostCallback GetStatusSendOperationCompleted;

        /// <remarks/>
        public EmailService()
        {
            this.Url = "https://ebank.vtc.vn/EbankServices/EmailService.asmx";
        }

        /// <remarks/>
        public event UpdateStatusEmailCompletedEventHandler UpdateStatusEmailCompleted;

        /// <remarks/>
        public event CheckEmailExistsCompletedEventHandler CheckEmailExistsCompleted;

        /// <remarks/>
        public event SendEMailCompletedEventHandler SendEMailCompleted;

        /// <remarks/>
        public event EventEbankCompletedEventHandler EventEbankCompleted;

        /// <remarks/>
        public event GetStatusSendCompletedEventHandler GetStatusSendCompleted;

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/UpdateStatusEmail", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int UpdateStatusEmail(string id, int status, int eventId, string key)
        {
            object[] results = this.Invoke("UpdateStatusEmail", new object[] {
                    id,
                    status,
                    eventId,
                    key});
            return ((int)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginUpdateStatusEmail(string id, int status, int eventId, string key, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("UpdateStatusEmail", new object[] {
                    id,
                    status,
                    eventId,
                    key}, callback, asyncState);
        }

        /// <remarks/>
        public int EndUpdateStatusEmail(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }

        /// <remarks/>
        public void UpdateStatusEmailAsync(string id, int status, int eventId, string key)
        {
            this.UpdateStatusEmailAsync(id, status, eventId, key, null);
        }

        /// <remarks/>
        public void UpdateStatusEmailAsync(string id, int status, int eventId, string key, object userState)
        {
            if ((this.UpdateStatusEmailOperationCompleted == null))
            {
                this.UpdateStatusEmailOperationCompleted = new System.Threading.SendOrPostCallback(this.OnUpdateStatusEmailOperationCompleted);
            }
            this.InvokeAsync("UpdateStatusEmail", new object[] {
                    id,
                    status,
                    eventId,
                    key}, this.UpdateStatusEmailOperationCompleted, userState);
        }

        private void OnUpdateStatusEmailOperationCompleted(object arg)
        {
            if ((this.UpdateStatusEmailCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.UpdateStatusEmailCompleted(this, new UpdateStatusEmailCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CheckEmailExists", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int CheckEmailExists(string email, string key)
        {
            object[] results = this.Invoke("CheckEmailExists", new object[] {
                    email,
                    key});
            return ((int)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginCheckEmailExists(string email, string key, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("CheckEmailExists", new object[] {
                    email,
                    key}, callback, asyncState);
        }

        /// <remarks/>
        public int EndCheckEmailExists(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }

        /// <remarks/>
        public void CheckEmailExistsAsync(string email, string key)
        {
            this.CheckEmailExistsAsync(email, key, null);
        }

        /// <remarks/>
        public void CheckEmailExistsAsync(string email, string key, object userState)
        {
            if ((this.CheckEmailExistsOperationCompleted == null))
            {
                this.CheckEmailExistsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCheckEmailExistsOperationCompleted);
            }
            this.InvokeAsync("CheckEmailExists", new object[] {
                    email,
                    key}, this.CheckEmailExistsOperationCompleted, userState);
        }

        private void OnCheckEmailExistsOperationCompleted(object arg)
        {
            if ((this.CheckEmailExistsCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CheckEmailExistsCompleted(this, new CheckEmailExistsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/SendEMail", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int SendEMail(string fromname, string fromemail, string toemail, string subject, string body, int eventmail, int idauthen, string codeauthen, long id, string key)
        {
            object[] results = this.Invoke("SendEMail", new object[] {
                    fromname,
                    fromemail,
                    toemail,
                    subject,
                    body,
                    eventmail,
                    idauthen,
                    codeauthen,
                    id,
                    key});
            return ((int)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginSendEMail(string fromname, string fromemail, string toemail, string subject, string body, int eventmail, int idauthen, string codeauthen, long id, string key, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("SendEMail", new object[] {
                    fromname,
                    fromemail,
                    toemail,
                    subject,
                    body,
                    eventmail,
                    idauthen,
                    codeauthen,
                    id,
                    key}, callback, asyncState);
        }

        /// <remarks/>
        public int EndSendEMail(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }

        /// <remarks/>
        public void SendEMailAsync(string fromname, string fromemail, string toemail, string subject, string body, int eventmail, int idauthen, string codeauthen, long id, string key)
        {
            this.SendEMailAsync(fromname, fromemail, toemail, subject, body, eventmail, idauthen, codeauthen, id, key, null);
        }

        /// <remarks/>
        public void SendEMailAsync(string fromname, string fromemail, string toemail, string subject, string body, int eventmail, int idauthen, string codeauthen, long id, string key, object userState)
        {
            if ((this.SendEMailOperationCompleted == null))
            {
                this.SendEMailOperationCompleted = new System.Threading.SendOrPostCallback(this.OnSendEMailOperationCompleted);
            }
            this.InvokeAsync("SendEMail", new object[] {
                    fromname,
                    fromemail,
                    toemail,
                    subject,
                    body,
                    eventmail,
                    idauthen,
                    codeauthen,
                    id,
                    key}, this.SendEMailOperationCompleted, userState);
        }

        private void OnSendEMailOperationCompleted(object arg)
        {
            if ((this.SendEMailCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.SendEMailCompleted(this, new SendEMailCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/EventEbank", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int EventEbank(int accountId, string accountName, string fromname, string fromemail, string toemail, int type, string param, string key)
        {
            object[] results = this.Invoke("EventEbank", new object[] {
                    accountId,
                    accountName,
                    fromname,
                    fromemail,
                    toemail,
                    type,
                    param,
                    key});
            return ((int)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginEventEbank(int accountId, string accountName, string fromname, string fromemail, string toemail, int type, string param, string key, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("EventEbank", new object[] {
                    accountId,
                    accountName,
                    fromname,
                    fromemail,
                    toemail,
                    type,
                    param,
                    key}, callback, asyncState);
        }

        /// <remarks/>
        public int EndEventEbank(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }

        /// <remarks/>
        public void EventEbankAsync(int accountId, string accountName, string fromname, string fromemail, string toemail, int type, string param, string key)
        {
            this.EventEbankAsync(accountId, accountName, fromname, fromemail, toemail, type, param, key, null);
        }

        /// <remarks/>
        public void EventEbankAsync(int accountId, string accountName, string fromname, string fromemail, string toemail, int type, string param, string key, object userState)
        {
            if ((this.EventEbankOperationCompleted == null))
            {
                this.EventEbankOperationCompleted = new System.Threading.SendOrPostCallback(this.OnEventEbankOperationCompleted);
            }
            this.InvokeAsync("EventEbank", new object[] {
                    accountId,
                    accountName,
                    fromname,
                    fromemail,
                    toemail,
                    type,
                    param,
                    key}, this.EventEbankOperationCompleted, userState);
        }

        private void OnEventEbankOperationCompleted(object arg)
        {
            if ((this.EventEbankCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.EventEbankCompleted(this, new EventEbankCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetStatusSend", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int GetStatusSend(int accountid, int time, string key)
        {
            object[] results = this.Invoke("GetStatusSend", new object[] {
                    accountid,
                    time,
                    key});
            return ((int)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginGetStatusSend(int accountid, int time, string key, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("GetStatusSend", new object[] {
                    accountid,
                    time,
                    key}, callback, asyncState);
        }

        /// <remarks/>
        public int EndGetStatusSend(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }

        /// <remarks/>
        public void GetStatusSendAsync(int accountid, int time, string key)
        {
            this.GetStatusSendAsync(accountid, time, key, null);
        }

        /// <remarks/>
        public void GetStatusSendAsync(int accountid, int time, string key, object userState)
        {
            if ((this.GetStatusSendOperationCompleted == null))
            {
                this.GetStatusSendOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetStatusSendOperationCompleted);
            }
            this.InvokeAsync("GetStatusSend", new object[] {
                    accountid,
                    time,
                    key}, this.GetStatusSendOperationCompleted, userState);
        }

        private void OnGetStatusSendOperationCompleted(object arg)
        {
            if ((this.GetStatusSendCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.GetStatusSendCompleted(this, new GetStatusSendCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    public delegate void UpdateStatusEmailCompletedEventHandler(object sender, UpdateStatusEmailCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class UpdateStatusEmailCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal UpdateStatusEmailCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public int Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    public delegate void CheckEmailExistsCompletedEventHandler(object sender, CheckEmailExistsCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CheckEmailExistsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal CheckEmailExistsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public int Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    public delegate void SendEMailCompletedEventHandler(object sender, SendEMailCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SendEMailCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal SendEMailCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public int Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    public delegate void EventEbankCompletedEventHandler(object sender, EventEbankCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EventEbankCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal EventEbankCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public int Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    public delegate void GetStatusSendCompletedEventHandler(object sender, GetStatusSendCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.1")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class GetStatusSendCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal GetStatusSendCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public int Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((int)(this.results[0]));
            }
        }
    }
}
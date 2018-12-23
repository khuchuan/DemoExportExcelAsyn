﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
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
using System.Configuration;

// 
// This source code was auto-generated by wsdl, Version=2.0.50727.1432.
// 
namespace Paygate.Utility.Service
{

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Web.Services.WebServiceBindingAttribute(Name = "ePostServiceSoap", Namespace = "http://tempuri.org/")]
    public partial class ePostService : System.Web.Services.Protocols.SoapHttpClientProtocol
    {

        private System.Threading.SendOrPostCallback CheckAccountExistsOperationCompleted;

        private System.Threading.SendOrPostCallback TopupPartnerOperationCompleted;

        private System.Threading.SendOrPostCallback TopupMobileOperationCompleted;

        /// <remarks/>
        public ePostService()
        {
            this.Url = ConfigurationManager.AppSettings["TOPUP.URL"];
            //"http://paygate.vtc.vn/WSePOSTopup/ePostService.asmx";
            this.Timeout = 300000;
        }

        /// <remarks/>
        public event CheckAccountExistsCompletedEventHandler CheckAccountExistsCompleted;

        /// <remarks/>
        public event TopupPartnerCompletedEventHandler TopupPartnerCompleted;

        /// <remarks/>
        public event TopupMobileCompletedEventHandler TopupMobileCompleted;

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/CheckAccountExists", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string CheckAccountExists(string PartnerCode, int ServiceCode, string GameTypeID, string ServerID, string CustomerAccountName)
        {
            object[] results = this.Invoke("CheckAccountExists", new object[] {
                    PartnerCode,
                    ServiceCode,
                    GameTypeID,
                    ServerID,
                    CustomerAccountName});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginCheckAccountExists(string PartnerCode, int ServiceCode, string GameTypeID, string ServerID, string CustomerAccountName, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("CheckAccountExists", new object[] {
                    PartnerCode,
                    ServiceCode,
                    GameTypeID,
                    ServerID,
                    CustomerAccountName}, callback, asyncState);
        }

        /// <remarks/>
        public string EndCheckAccountExists(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void CheckAccountExistsAsync(string PartnerCode, int ServiceCode, string GameTypeID, string ServerID, string CustomerAccountName)
        {
            this.CheckAccountExistsAsync(PartnerCode, ServiceCode, GameTypeID, ServerID, CustomerAccountName, null);
        }

        /// <remarks/>
        public void CheckAccountExistsAsync(string PartnerCode, int ServiceCode, string GameTypeID, string ServerID, string CustomerAccountName, object userState)
        {
            if ((this.CheckAccountExistsOperationCompleted == null))
            {
                this.CheckAccountExistsOperationCompleted = new System.Threading.SendOrPostCallback(this.OnCheckAccountExistsOperationCompleted);
            }
            this.InvokeAsync("CheckAccountExists", new object[] {
                    PartnerCode,
                    ServiceCode,
                    GameTypeID,
                    ServerID,
                    CustomerAccountName}, this.CheckAccountExistsOperationCompleted, userState);
        }

        private void OnCheckAccountExistsOperationCompleted(object arg)
        {
            if ((this.CheckAccountExistsCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.CheckAccountExistsCompleted(this, new CheckAccountExistsCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/TopupPartner", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string TopupPartner(
                    string PartnerCode, //asian la gi
                    string GameTypeID, //-1
                    string ServerID, //-1
                    int ServiceCode, //ma cua he thong 
                    string PaymentCode, //epos
                    long OrderLogId, //ma giao dich
                    string Desc, //mo ta
                    string TopupAccount, //acaount
                    string DeductAccount, //acc tru tien
                    double TopupAmount, //menh gia cua doi tac
                    int DeductAmount, //so tien tru
                    string FromIP,
                    System.DateTime TransDate,
                    string DataSign,
                    string ExtendedField1,
                    string ExtendedField2,
                    string ExtendedField3)
        {
            object[] results = this.Invoke("TopupPartner", new object[] {
                    PartnerCode,
                    GameTypeID,
                    ServerID,
                    ServiceCode,
                    PaymentCode,
                    OrderLogId,
                    Desc,
                    TopupAccount,
                    DeductAccount,
                    TopupAmount,
                    DeductAmount,
                    FromIP,
                    TransDate,
                    DataSign,
                    ExtendedField1,
                    ExtendedField2,
                    ExtendedField3});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginTopupPartner(
                    string PartnerCode,
                    string GameTypeID,
                    string ServerID,
                    int ServiceCode,
                    string PaymentCode,
                    long OrderLogId,
                    string Desc,
                    string TopupAccount,
                    string DeductAccount,
                    double TopupAmount,
                    int DeductAmount,
                    string FromIP,
                    System.DateTime TransDate,
                    string DataSign,
                    string ExtendedField1,
                    string ExtendedField2,
                    string ExtendedField3,
                    System.AsyncCallback callback,
                    object asyncState)
        {
            return this.BeginInvoke("TopupPartner", new object[] {
                    PartnerCode,
                    GameTypeID,
                    ServerID,
                    ServiceCode,
                    PaymentCode,
                    OrderLogId,
                    Desc,
                    TopupAccount,
                    DeductAccount,
                    TopupAmount,
                    DeductAmount,
                    FromIP,
                    TransDate,
                    DataSign,
                    ExtendedField1,
                    ExtendedField2,
                    ExtendedField3}, callback, asyncState);
        }

        /// <remarks/>
        public string EndTopupPartner(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void TopupPartnerAsync(
                    string PartnerCode,
                    string GameTypeID,
                    string ServerID,
                    int ServiceCode,
                    string PaymentCode,
                    long OrderLogId,
                    string Desc,
                    string TopupAccount,
                    string DeductAccount,
                    double TopupAmount,
                    int DeductAmount,
                    string FromIP,
                    System.DateTime TransDate,
                    string DataSign,
                    string ExtendedField1,
                    string ExtendedField2,
                    string ExtendedField3)
        {
            this.TopupPartnerAsync(PartnerCode, GameTypeID, ServerID, ServiceCode, PaymentCode, OrderLogId, Desc, TopupAccount, DeductAccount, TopupAmount, DeductAmount, FromIP, TransDate, DataSign, ExtendedField1, ExtendedField2, ExtendedField3, null);
        }

        /// <remarks/>
        public void TopupPartnerAsync(
                    string PartnerCode,
                    string GameTypeID,
                    string ServerID,
                    int ServiceCode,
                    string PaymentCode,
                    long OrderLogId,
                    string Desc,
                    string TopupAccount,
                    string DeductAccount,
                    double TopupAmount,
                    int DeductAmount,
                    string FromIP,
                    System.DateTime TransDate,
                    string DataSign,
                    string ExtendedField1,
                    string ExtendedField2,
                    string ExtendedField3,
                    object userState)
        {
            if ((this.TopupPartnerOperationCompleted == null))
            {
                this.TopupPartnerOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTopupPartnerOperationCompleted);
            }
            this.InvokeAsync("TopupPartner", new object[] {
                    PartnerCode,
                    GameTypeID,
                    ServerID,
                    ServiceCode,
                    PaymentCode,
                    OrderLogId,
                    Desc,
                    TopupAccount,
                    DeductAccount,
                    TopupAmount,
                    DeductAmount,
                    FromIP,
                    TransDate,
                    DataSign,
                    ExtendedField1,
                    ExtendedField2,
                    ExtendedField3}, this.TopupPartnerOperationCompleted, userState);
        }

        private void OnTopupPartnerOperationCompleted(object arg)
        {
            if ((this.TopupPartnerCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.TopupPartnerCompleted(this, new TopupPartnerCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/TopupMobile", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle = System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public string TopupMobile(string Telco, string TargetMsisdn, string Amount, string PaymentCode, int ServiceCode, string LogType, long OrderLogId, string DataSign)
        {
            object[] results = this.Invoke("TopupMobile", new object[] {
                    Telco,
                    TargetMsisdn,
                    Amount,
                    PaymentCode,
                    ServiceCode,
                    LogType,
                    OrderLogId,
                    DataSign});
            return ((string)(results[0]));
        }

        /// <remarks/>
        public System.IAsyncResult BeginTopupMobile(string Telco, string TargetMsisdn, string Amount, string PaymentCode, int ServiceCode, string LogType, long OrderLogId, string DataSign, System.AsyncCallback callback, object asyncState)
        {
            return this.BeginInvoke("TopupMobile", new object[] {
                    Telco,
                    TargetMsisdn,
                    Amount,
                    PaymentCode,
                    ServiceCode,
                    LogType,
                    OrderLogId,
                    DataSign}, callback, asyncState);
        }

        /// <remarks/>
        public string EndTopupMobile(System.IAsyncResult asyncResult)
        {
            object[] results = this.EndInvoke(asyncResult);
            return ((string)(results[0]));
        }

        /// <remarks/>
        public void TopupMobileAsync(string Telco, string TargetMsisdn, string Amount, string PaymentCode, int ServiceCode, string LogType, long OrderLogId, string DataSign)
        {
            this.TopupMobileAsync(Telco, TargetMsisdn, Amount, PaymentCode, ServiceCode, LogType, OrderLogId, DataSign, null);
        }

        /// <remarks/>
        public void TopupMobileAsync(string Telco, string TargetMsisdn, string Amount, string PaymentCode, int ServiceCode, string LogType, long OrderLogId, string DataSign, object userState)
        {
            if ((this.TopupMobileOperationCompleted == null))
            {
                this.TopupMobileOperationCompleted = new System.Threading.SendOrPostCallback(this.OnTopupMobileOperationCompleted);
            }
            this.InvokeAsync("TopupMobile", new object[] {
                    Telco,
                    TargetMsisdn,
                    Amount,
                    PaymentCode,
                    ServiceCode,
                    LogType,
                    OrderLogId,
                    DataSign}, this.TopupMobileOperationCompleted, userState);
        }

        private void OnTopupMobileOperationCompleted(object arg)
        {
            if ((this.TopupMobileCompleted != null))
            {
                System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
                this.TopupMobileCompleted(this, new TopupMobileCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
            }
        }

        /// <remarks/>
        public new void CancelAsync(object userState)
        {
            base.CancelAsync(userState);
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")]
    public delegate void CheckAccountExistsCompletedEventHandler(object sender, CheckAccountExistsCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class CheckAccountExistsCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal CheckAccountExistsCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")]
    public delegate void TopupPartnerCompletedEventHandler(object sender, TopupPartnerCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TopupPartnerCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal TopupPartnerCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")]
    public delegate void TopupMobileCompletedEventHandler(object sender, TopupMobileCompletedEventArgs e);

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "2.0.50727.1432")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class TopupMobileCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs
    {

        private object[] results;

        internal TopupMobileCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) :
            base(exception, cancelled, userState)
        {
            this.results = results;
        }

        /// <remarks/>
        public string Result
        {
            get
            {
                this.RaiseExceptionIfNecessary();
                return ((string)(this.results[0]));
            }
        }
    }
}
﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18033
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
// This source code was auto-generated by wsdl, Version=4.0.30319.17929.
// 


/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Web.Services.WebServiceBindingAttribute(Name="VDC1718CardSoap", Namespace="http://tempuri.org/")]
public partial class VDC1718Card : System.Web.Services.Protocols.SoapHttpClientProtocol {
    
    private System.Threading.SendOrPostCallback BuyCardOperationCompleted;
    
    private System.Threading.SendOrPostCallback GetCardOperationCompleted;
    
    /// <remarks/>
    public VDC1718Card() {
        this.Url = System.Configuration.ConfigurationManager.AppSettings["WS_VDC1718_URL"];// "http://sandbox2.vtcebank.vn/wsvdc1718/VDC1718Card.asmx";
    }
    
    /// <remarks/>
    public event BuyCardCompletedEventHandler BuyCardCompleted;
    
    /// <remarks/>
    public event GetCardCompletedEventHandler GetCardCompleted;
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/BuyCard", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public string BuyCard(string partnerCode, int partnerTransactionID, string accountName, int amount, int quantity, string cardType) {
        object[] results = this.Invoke("BuyCard", new object[] {
                    partnerCode,
                    partnerTransactionID,
                    accountName,
                    amount,
                    quantity,
                    cardType});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginBuyCard(string partnerCode, int partnerTransactionID, string accountName, int amount, int quantity, string cardType, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("BuyCard", new object[] {
                    partnerCode,
                    partnerTransactionID,
                    accountName,
                    amount,
                    quantity,
                    cardType}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndBuyCard(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public void BuyCardAsync(string partnerCode, int partnerTransactionID, string accountName, int amount, int quantity, string cardType) {
        this.BuyCardAsync(partnerCode, partnerTransactionID, accountName, amount, quantity, cardType, null);
    }
    
    /// <remarks/>
    public void BuyCardAsync(string partnerCode, int partnerTransactionID, string accountName, int amount, int quantity, string cardType, object userState) {
        if ((this.BuyCardOperationCompleted == null)) {
            this.BuyCardOperationCompleted = new System.Threading.SendOrPostCallback(this.OnBuyCardOperationCompleted);
        }
        this.InvokeAsync("BuyCard", new object[] {
                    partnerCode,
                    partnerTransactionID,
                    accountName,
                    amount,
                    quantity,
                    cardType}, this.BuyCardOperationCompleted, userState);
    }
    
    private void OnBuyCardOperationCompleted(object arg) {
        if ((this.BuyCardCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.BuyCardCompleted(this, new BuyCardCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/GetCard", RequestNamespace="http://tempuri.org/", ResponseNamespace="http://tempuri.org/", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
    public string GetCard(string partnerCode, int partnerTransactionID, string accountName) {
        object[] results = this.Invoke("GetCard", new object[] {
                    partnerCode,
                    partnerTransactionID,
                    accountName});
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public System.IAsyncResult BeginGetCard(string partnerCode, int partnerTransactionID, string accountName, System.AsyncCallback callback, object asyncState) {
        return this.BeginInvoke("GetCard", new object[] {
                    partnerCode,
                    partnerTransactionID,
                    accountName}, callback, asyncState);
    }
    
    /// <remarks/>
    public string EndGetCard(System.IAsyncResult asyncResult) {
        object[] results = this.EndInvoke(asyncResult);
        return ((string)(results[0]));
    }
    
    /// <remarks/>
    public void GetCardAsync(string partnerCode, int partnerTransactionID, string accountName) {
        this.GetCardAsync(partnerCode, partnerTransactionID, accountName, null);
    }
    
    /// <remarks/>
    public void GetCardAsync(string partnerCode, int partnerTransactionID, string accountName, object userState) {
        if ((this.GetCardOperationCompleted == null)) {
            this.GetCardOperationCompleted = new System.Threading.SendOrPostCallback(this.OnGetCardOperationCompleted);
        }
        this.InvokeAsync("GetCard", new object[] {
                    partnerCode,
                    partnerTransactionID,
                    accountName}, this.GetCardOperationCompleted, userState);
    }
    
    private void OnGetCardOperationCompleted(object arg) {
        if ((this.GetCardCompleted != null)) {
            System.Web.Services.Protocols.InvokeCompletedEventArgs invokeArgs = ((System.Web.Services.Protocols.InvokeCompletedEventArgs)(arg));
            this.GetCardCompleted(this, new GetCardCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState));
        }
    }
    
    /// <remarks/>
    public new void CancelAsync(object userState) {
        base.CancelAsync(userState);
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void BuyCardCompletedEventHandler(object sender, BuyCardCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class BuyCardCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal BuyCardCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public string Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((string)(this.results[0]));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
public delegate void GetCardCompletedEventHandler(object sender, GetCardCompletedEventArgs e);

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("wsdl", "4.0.30319.17929")]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
public partial class GetCardCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
    
    private object[] results;
    
    internal GetCardCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
            base(exception, cancelled, userState) {
        this.results = results;
    }
    
    /// <remarks/>
    public string Result {
        get {
            this.RaiseExceptionIfNecessary();
            return ((string)(this.results[0]));
        }
    }
}

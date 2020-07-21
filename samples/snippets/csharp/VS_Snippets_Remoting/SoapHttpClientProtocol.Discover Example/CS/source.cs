﻿//<Snippet1>
namespace MyMath {
    using System.Diagnostics;
    using System.Xml.Serialization;
    using System;
    using System.Web.Services.Protocols;
    using System.Web.Services;

    [System.Web.Services.WebServiceBindingAttribute(Name="MathSoap", Namespace="http://tempuri.org/")]
    public class Math : System.Web.Services.Protocols.SoapHttpClientProtocol {

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        public Math() {
            this.Url = "http://www.contoso.com/math.asmx";
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://tempuri.org/Add", Use=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)]
        public int Add(int num1, int num2) {
            object[] results = this.Invoke("Add", new object[] {num1,
                        num2});
            return ((int)(results[0]));
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        public System.IAsyncResult BeginAdd(int num1, int num2, System.AsyncCallback callback, object asyncState) {
            return this.BeginInvoke("Add", new object[] {num1,
                        num2}, callback, asyncState);
        }

        [System.Diagnostics.DebuggerStepThroughAttribute()]
        public int EndAdd(System.IAsyncResult asyncResult) {
            object[] results = this.EndInvoke(asyncResult);
            return ((int)(results[0]));
        }
    }
}
//</Snippet1>
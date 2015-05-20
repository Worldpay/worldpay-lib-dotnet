<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecurringPayment.aspx.cs" Inherits="Worldpay.Sdk.Examples.RecurringPayment" MasterPageFile="Master.Master" %>

<%@ Register TagPrefix="uc" TagName="ErrorControl" Src="ErrorControl.ascx" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <form id="paymentForm" runat="server">
        <h1>.NET 2.0 Library Recurring Payment Example</h1>

        <asp:Panel runat="server" ID="RequestPanel" Visible="<%# !IsPostBack %>">
            <div class="payment-errors"></div>

            <div class="form-row">
                <label>Token</label>
                <input type="text" id="token" name="token" value="" />
            </div>

            <div class="form-row">
                <label>Amount</label>
                <input type="text" id="amount" size="4" name="amount" value="15.23" />
            </div>

            <div class="form-row">
                <label>Currency</label>
                <input type="text" id="currency" name="currency" value="GBP" />
            </div>

            <div class="form-row">
                <label>Description</label>
                <input type="text" id="description" name="description" value="My test order" />
            </div>

            <div>
                <asp:Button ID="PlaceOrder" runat="server" OnCommand="OnCreateOrder" Text="Place Order" />
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="SuccessPanel" Visible="false">
            <h2>Response</h2>
            <p>Order Code: <span id="order-code"><asp:Literal runat="server" ID="ResponseOrderCode"/></span></p>
            <p>Token: <span id="token-result"><asp:Literal runat="server" ID="ResponseToken"/></span></p>
            <p>Payment Status: <span id="payment-status"><asp:Literal runat="server" ID="ResponsePaymentStatus"/></span></p>
            <pre><asp:Literal runat="server" ID="ResponseJson"/></pre>
            <asp:Literal runat="server" ID="OrderResponse"></asp:Literal>
        </asp:Panel>
        <uc:ErrorControl ID="ErrorControl" runat="server"/>

    </form>

</asp:Content>
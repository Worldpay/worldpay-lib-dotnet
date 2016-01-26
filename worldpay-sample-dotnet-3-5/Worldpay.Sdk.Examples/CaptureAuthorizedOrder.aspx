<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaptureAuthorizedOrder.aspx.cs" Inherits="Worldpay.Sdk.Examples.CaptureAuthorizedOrder" MasterPageFile="Master.Master" %>
<%@ Register TagPrefix="uc" TagName="ErrorControl" Src="ErrorControl.ascx" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h1>.NET 3.5 Library Capture Authorised Order Example</h1>

    <asp:Panel runat="server" ID="RequestPanel" Visible="<%# !IsPostBack %>">
        <form method="post" id="CaptureAuthorisedOrderForm" runat="server">
            <div class="payment-errors"></div>
            <div class="form-row">
                <label>Worldpay Order Code</label>
                <input type="text" id="order-code" name="orderCode" value="" />
            </div>
            <div class="form-row">
                <label>Amount</label>
                <input type="text" id="amount" name="amount" value="" />
            </div>
            <asp:Button ID="CaptureOrder" runat="server" OnCommand="OnCaptureOrder" Text="Capture Authorised Order" />
        </form>
    </asp:Panel>

    <asp:Panel runat="server" ID="SuccessPanel" Visible="false">
        <h2>Response</h2>
        <p><asp:Literal runat="server" ID="ServerResponse"></asp:Literal></p>
    </asp:Panel>

    <uc:ErrorControl ID="ErrorControl" runat="server"/>

</asp:Content>
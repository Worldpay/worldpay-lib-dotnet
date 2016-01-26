<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CancelAuthorizedOrder.aspx.cs" Inherits="Worldpay.Sdk.Examples.CancelAuthorizedOrder" MasterPageFile="Master.Master" %>
<%@ Register TagPrefix="uc" TagName="ErrorControl" Src="ErrorControl.ascx" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h1>.NET 2.0 Library Cancel Authorised Order Example</h1>

    <asp:Panel runat="server" ID="RequestPanel" Visible="<%# !IsPostBack %>">
        <form method="post" id="CancelAuthorisedOrderForm" runat="server">
            <div class="payment-errors"></div>
            <div class="form-row">
                <label>Worldpay Order Code</label>
                <input type="text" id="order-code" name="orderCode" value="" />
            </div>
            <asp:Button ID="CancelOrder" runat="server" OnCommand="OnCancelOrder" Text="Cancel Authorised Order" />
        </form>
    </asp:Panel>

    <asp:Panel runat="server" ID="SuccessPanel" Visible="false">
        <h2>Response</h2>
        <p><asp:Literal runat="server" ID="ServerResponse"></asp:Literal></p>
    </asp:Panel>

    <uc:ErrorControl ID="ErrorControl" runat="server"/>

</asp:Content>
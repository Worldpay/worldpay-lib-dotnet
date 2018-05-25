<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetOrder.aspx.cs" Inherits="Worldpay.Sdk.Examples.GetOrder" MasterPageFile="Master.Master" %>

<%@ Register TagPrefix="uc" TagName="ErrorControl" Src="ErrorControl.ascx" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h1>.NET Library Get Order Example</h1>

    <asp:Panel runat="server" ID="RequestPanel" Visible="<%# !IsPostBack %>">
        <form method="post" runat="server">
            <div class="payment-errors"></div>
            <div class="form-row">
                <label>Worldpay Order Code</label>
                <input type="text" id="order-code" name="orderCode" value="" />
            </div>
            <asp:Button ID="BtnRefundOrder" runat="server" OnCommand="OnGetOrder" Text="Get Order" />
        </form>
    </asp:Panel>

    <asp:Panel runat="server" ID="SuccessPanel" Visible="false">
        <h2>Response</h2>
        <pre><asp:Literal runat="server" ID="ServerResponse"></asp:Literal></pre>
    </asp:Panel>
    <uc:ErrorControl ID="ErrorControl" runat="server"/>

</asp:Content>

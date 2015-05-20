<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StoredCard.aspx.cs" Inherits="Worldpay.Sdk.Examples.StoredCard" MasterPageFile="Master.Master" %>

<%@ Register TagPrefix="uc" TagName="ErrorControl" Src="ErrorControl.ascx" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h1>.NET 3.5 Library Stored Card Details Example</h1>

    <asp:Panel runat="server" ID="RequestPanel" Visible="<%# !IsPostBack %>">
        <form method="post" runat="server">
            <div class="payment-errors"></div>
            <div class="form-row">
                <label>Worldpay resuable token</label>
                <input type="text" id="token" name="token" value="" />
            </div>
            <asp:Button ID="ShowCard" runat="server" OnCommand="OnShowCardDetails" Text="Show card details" />
        </form>
    </asp:Panel>

    <asp:Panel runat="server" ID="SuccessPanel" Visible="false">
        <h2>Response</h2>
        <p>Name: <span id="name"><asp:Literal runat="server" ID="ResultName" /></span></p>
        <p>Expiry Month: <span id="expiration-month"><asp:Literal runat="server" ID="ResultMonth" /></span></p>
        <p>Expiry Year: <span id="expiration-year"><asp:Literal runat="server" ID="ResultYear" /></span></p>
        <p>Card Type: <span id="card-type"><asp:Literal runat="server" ID="ResultType" /></span></p>
        <p>Masked Card Number: <span id="masked-card-number"><asp:Literal runat="server" ID="ResultCardNumber" /></span></p>
        <pre><asp:Literal runat="server" ID="ResponseJson" /></pre>
    </asp:Panel>
    <uc:ErrorControl ID="ErrorControl" runat="server"/>

</asp:Content>
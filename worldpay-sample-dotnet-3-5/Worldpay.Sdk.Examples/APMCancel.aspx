<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="APMCancel.aspx.cs" Inherits="Worldpay.Sdk.Examples.APMCancel" MasterPageFile="Master.Master" %>

<%@ Register TagPrefix="uc" TagName="ErrorControl" Src="ErrorControl.ascx" %>

<asp:Content ID="ResponsePanel" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <h1>.NET 3.5 Library Create Order Example</h1>

    <h2>Payment Response</h2>
    <p>
        <asp:Literal runat="server" ID="OrderResponse" ViewStateMode="Disabled"></asp:Literal>
        <uc:ErrorControl ID="ErrorControl" runat="server"/>
    </p>
</asp:Content>
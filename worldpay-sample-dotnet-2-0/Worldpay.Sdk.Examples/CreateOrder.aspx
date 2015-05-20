<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateOrder.aspx.cs" Inherits="Worldpay.Sdk.Examples.CreateOrder" MasterPageFile="Master.Master" %>

<%@ Register TagPrefix="uc" TagName="ErrorControl" Src="ErrorControl.ascx" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script type="text/javascript" src="<%= Session["js_endpoint"] %>"></script>
    <form id="paymentForm" runat="server">
        <h1>.NET 2.0 Library Create Order Example</h1>

        <asp:Panel runat="server" ID="RequestPanel">
            <div class="payment-errors"></div>
            <div class="form-row">
                <label>Name</label>
                <input type="text" id="name" name="name" data-worldpay="name" value="Example Name" />
            </div>

            <div class="form-row">
                <label>Card Number</label>
                <input type="text" id="card" size="20" data-worldpay="number" value="4444333322221111" />

            </div>

            <div class="form-row">
                <label>CVC</label>
                <input type="text" id="cvc" size="4" data-worldpay="cvc" value="321" />
            </div>

            <div class="form-row">
                <label>Expiration (MM/YYYY)</label>
                <select id="expiration-month" data-worldpay="exp-month">
                    <option value="01">01</option>
                    <option value="02">02</option>
                    <option value="03">03</option>
                    <option value="04">04</option>
                    <option value="05">05</option>
                    <option value="06">06</option>
                    <option value="07">07</option>
                    <option value="08">08</option>
                    <option value="09">09</option>
                    <option value="10" selected="selected">10</option>
                    <option value="11">11</option>
                    <option value="12">12</option>
                </select>
                <span> / </span>
                <select id="expiration-year" data-worldpay="exp-year">
                    <option value="2015">2015</option>
                    <option value="2016" selected="selected">2016</option>
                    <option value="2017">2017</option>
                    <option value="2018">2018</option>
                    <option value="2019">2019</option>
                    <option value="2020">2020</option>
                    <option value="2021">2021</option>
                </select>
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
                <label>Address 1</label>
                <input type="text" id="address1" name="address1" value="123 House Road" />
            </div>

            <div class="form-row">
                <label>Address 2</label>
                <input type="text" id="address2" name="address2" value="A village" />
            </div>

            <div class="form-row">
                <label>Address 3</label>
                <input type="text" id="address3" name="address3" value="" />
            </div>

            <div class="form-row">
                <label>City</label>
                <input type="text" id="city" name="city" value="London" />
            </div>

            <div class="form-row">
                <label>Postcode</label>
                <input type="text" id="postcode" name="postcode" value="EC1 1AA" />
            </div>

            <div class="form-row">
                <label>Country Code</label>
                <input type="text" id="country-code" name="countryCode" value="GB" />
            </div>

            <div class="form-row">
                <label>Description</label>
                <input type="text" id="description" name="description" value="My test order" />
            </div>

            <div class="form-row">
                <label>Reusable Token</label>
                <input type="checkbox" id="chkReusable" />
            </div>

            <div class="form-row">
                <label>Use 3DS</label>
                <input type="checkbox" id="chk3Ds" name="3ds" />
            </div>

            <div class="form-row">
                <label>Authorise Only</label>
                <input type="checkbox" id="chkAuthoriseOnly" name="authoriseOnly" />
            </div>
            <input name="env" type="hidden" value=""/>

            <div class="form-row">
                <label>Order Type</label>
                <input type="radio" id="ecom" name="radOrderType" value="ECOM" checked /><label for="ecom" class="radlabel">ECOM</label>
                <input type="radio" id="recurring" name="radOrderType" value="RECURRING" /><label for="recurring" class="radlabel">RECURRING</label>
                <input type="radio" id="moto" name="radOrderType" value="MOTO" /><label for="moto" class="radlabel">MOTO</label>
            </div>
            <div>
                <asp:Button ID="PlaceOrder" runat="server" Text="Place Order" />
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="SuccessPanel" Visible="false">
            <h2>Response</h2>
            <p>Order Code: <span id="order-code"><asp:Literal runat="server" ID="ResponseOrderCode" /></span></p>
            <p>Token: <span id="token"><asp:Literal runat="server" ID="ResponseToken" /></span></p>
            <p>Payment Status: <span id="payment-status"><asp:Literal runat="server" ID="ResponsePaymentStatus" /></span></p>
            <pre><asp:Literal runat="server" ID="ResponseJson" /></pre>
            <asp:Literal runat="server" ID="OrderResponse"></asp:Literal>
        </asp:Panel>
        <uc:ErrorControl ID="ErrorControl" runat="server"/>

    </form>
    <script type="text/javascript">
        Worldpay.setClientKey('<%= Session["client_key"] %>');
        Worldpay.api_path = '<%= Session["apiendpoint"] %>';

        $('#chkReusable').change(function () {
            if ($(this).is(':checked')) {
                Worldpay.reusable = true;
            }
            else {
                Worldpay.reusable = false;
            }
        });

        // This is required as .NET 2.0 doesn't have ClientIDMode="static", so we can't set the form's id to anything
        // other than "aspnetForm"
        var form = document.getElementById('aspnetForm');

        Worldpay.useForm(form, function (status, response) {
            if (response.error) {
                Worldpay.handleError(form, $('.payment-errors')[0], response.error);
            } else {
                var token = response.token;
                Worldpay.formBuilder(form, 'input', 'hidden', 'token', token);
                form.submit();
            }

        });
    </script>
</asp:Content>

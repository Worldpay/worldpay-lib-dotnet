<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecurringPayment.aspx.cs" Inherits="Worldpay.Sdk.Examples.RecurringPayment" MasterPageFile="Master.Master" %>

<%@ Register TagPrefix="uc" TagName="ErrorControl" Src="ErrorControl.ascx" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script type="text/javascript" src="<%= Session["js_endpoint"] %>"></script>
    <form id="aspnetForm" runat="server">
        <h1>.NET Library<br />Recurring Payment Example</h1>

        <asp:Panel runat="server" ID="RequestPanel" Visible="<%# !IsPostBack %>">
            <div class="payment-errors"></div>
            <div class="header">Checkout</div>

            <div class="form-row no-apm">
                <label>Site Code</label>
                <input type="text" id="site-code" name="site-code" value="N/A" />
            </div>

            <div class="form-row">
                <label>Name</label>
                <input type="text" id="name" name="name" placeholder="Example Name" />
            </div>

            <div class="form-row">
                <label>Token</label>
                <input type="text" id="token" data-worldpay="token" value="" />
            </div>

            <div class="form-row">
                <label>CVC</label>
                <input type="text" id="cvc" size="4" data-worldpay="cvc" placeholder="321" />
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
                <label>Settlement Currency</label>
                 <select id="settlement-currency" name="settlement-currency">
                    <option value="" selected></option>
                    <option value="USD">USD</option>
                    <option value="GBP">GBP</option>
                    <option value="EUR">EUR</option>
                    <option value="CAD">CAD</option>
                    <option value="NOK">NOK</option>
                    <option value="SEK">SEK</option>
                    <option value="SGD">SGD</option>
                    <option value="HKD">HKD</option>
                    <option value="DKK">DKK</option>
                </select>
            </div>

            <div class="form-row">
                <label>Order Type</label>
                 <select id="order-type" name="orderType">
                    <option value="ECOM" selected>ECOM</option>
                    <option value="MOTO">MOTO</option>
                </select>
            </div>

            <div class="form-row">
                <label>Use 3DS </label>
                <input type="checkbox" id="chk3Ds" name="3ds" />
            </div>

            <div class="form-row">
                <label>Authorize Only</label>
                <input type="checkbox" id="chkAuthorizeOnly" name="authorizeOnly" />
            </div>

            <div class="header">Billing address</div>

            <div class="form-row">
                <label>
                    Address 1
                </label>
                <input type="text" id="address1" name="address1" value="123 House Road" />
            </div>

            <div class="form-row">
                <label>
                    Address 2
                </label>
                <input type="text" id="address2" name="address2" value="A village" />
            </div>

            <div class="form-row">
                <label>
                    Address 3
                </label>
                <input type="text" id="address3" name="address3" value="" />
            </div>

            <div class="form-row">
                <label>
                    City
                </label>
                <input type="text" id="city" name="city" value="London" />
            </div>

            <div class="form-row">
                <label>
                    Postcode
                </label>
                <input type="text" id="postcode" name="postcode" value="EC1 1AA" />
            </div>

            <div class="form-row">
                <label>
                    Country Code
                </label>
                <input type="text" id="country-code" name="countryCode" value="GB" />
            </div>

            <div class="header">Delivery address</div>

            <div class="form-row">
                <label>
                    First Name
                </label>
                <input type="text" id="delivery-first-name" name="delivery-firstName" value="John" />
            </div>
            <div class="form-row">
                <label>
                    Last Name
                </label>
                <input type="text" id="delivery-last-name" name="delivery-lastName" value="Doe" />
            </div>
            <div class="form-row">
                <label>
                    Address 1
                </label>
                <input type="text" id="delivery-address1" name="delivery-address1" value="123 House Road" />
            </div>

            <div class="form-row">
                <label>
                    Address 2
                </label>
                <input type="text" id="delivery-address2" name="delivery-address2" value="A village" />
            </div>

            <div class="form-row">
                <label>
                    Address 3
                </label>
                <input type="text" id="delivery-address3" name="delivery-address3" value="" />
            </div>

            <div class="form-row">
                <label>
                    City
                </label>
                <input type="text" id="delivery-city" name="delivery-city" value="London" />
            </div>

            <div class="form-row">
                <label>
                    Postcode
                </label>
                <input type="text" id="delivery-postcode" name="delivery-postcode" value="EC1 1AA" />
            </div>

            <div class="form-row">
                <label>
                    Country Code
                </label>
                <input type="text" id="delivery-country-code" name="delivery-countryCode" value="GB" />
            </div>

            <div class="header">Other</div>

            <div class="form-row">
                <label>
                    Description
                </label>
                <input type="text" id="description" name="description" value="My test order" />
            </div>

             <div class="form-row">
                <label>Customer Order Code</label>
                <input type="text" id="customer-order-code" name="customer-order-code" value="" />
            </div>

            <div class="form-row">
                <label>Order Code Prefix</label>
                <input type="text" id="order-code-prefix" name="order-code-prefix" value="" />
            </div>

            <div class="form-row">
                <label>Order Code Suffix</label>
                <input type="text" id="order-code-suffix" name="order-code-suffix" value="" />
            </div>

            <div class="form-row">
                <label>
                    Statement Narrative
                </label>
                <input type="text" id="statement-narrative" maxlength="24" name="statement-narrative" value="Statement Narrative" />
            </div>

            <div class="form-row">
                <label>Shopper Email</label>
                <input type="text" id="shopper-email" name="shopper-email" value="shopper@email.com" />
            </div>
           
             <div class="form-row large">
                <label class='left'>
                    Customer Identifiers (json)
                </label>
                <textarea id="customer-identifiers" rows="6" cols="30" name="customer-identifiers"></textarea>
            </div>

            <div>
                <asp:Button ID="PlaceOrder" runat="server" OnCommand="OnCreateOrder" Text="Place Order" />
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="SuccessPanel" Visible="false">
            <h2>Response</h2>
            <p>Order Code: <span id="order-code"><asp:Literal runat="server" ID="ResponseOrderCode"/></span></p>
            <p>Token: <span id="token"><asp:Literal runat="server" ID="ResponseToken"/></span></p>
            <p>Payment Status: <span id="payment-status"><asp:Literal runat="server" ID="ResponsePaymentStatus"/></span></p>
            <pre><asp:Literal runat="server" ID="ResponseJson"/></pre>
            <asp:Literal runat="server" ID="OrderResponse"></asp:Literal>
        </asp:Panel>
        <uc:ErrorControl ID="ErrorControl" runat="server"/>

    </form>
    <script type="text/javascript">

        // Set client key
        Worldpay.setClientKey('<%= Session["client_key"] %>');
        Worldpay.api_path = '<%= Session["apiendpoint"] %>/';

        // This is required as .NET 2.0 doesn't have ClientIDMode="static", so we can't set the form's id to anything
        // other than "aspnetForm"
        var form = document.getElementById('aspnetForm');

        Worldpay.useForm(form, function (status, response) {
            if (response.error) {
                Worldpay.handleError(form, $('.payment-errors')[0], response.error);
            } else {
                var token = $('#token').val();
                Worldpay.formBuilder(form, 'input', 'hidden', 'token', token);
                form.submit();
            }

        }, true);

    </script>

</asp:Content>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateOrder.aspx.cs" Inherits="Worldpay.Sdk.Examples.CreateOrder" MasterPageFile="Master.Master" %>

<%@ Register TagPrefix="uc" TagName="ErrorControl" Src="ErrorControl.ascx" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <script type="text/javascript" src="<%= Session["js_endpoint"] %>"></script>
    <form id="paymentForm" runat="server">
        <h1>.NET 3.5 Library Create Order Example</h1>
            
        <asp:Panel runat="server" ID="RequestPanel">
            <div class="payment-errors"></div>
            <div class="header">Checkout</div>

            <div class="form-row">
                <label>Order Type</label>
                <select id="orderType" name="orderType">
                    <option value="ECOM" selected="selected">ECOM</option>
                    <option value="RECURRING">RECURRING</option>
                    <option value="MOTO">MOTO</option>
                    <option value="APM">APM</option>
                </select>
            </div>

            <div class="form-row apm" style="display:none;">
                <label>APM</label>
                <select id="apm-name" data-worldpay="apm-name">
                    <option value="paypal" selected="selected">PayPal</option>
                    <option value="giropay">Giropay</option>
                </select>
            </div>

            <div class="form-row">
                <label>Name</label>
                <input type="text" id="name" name="name" data-worldpay="name" value="Example Name" />
            </div>

             <div class="form-row apm apm-url" style="display:none;">
                <label>
                    Success URL
                </label>
                <input type="text" id="success-url" name="success-url" placeholder='<%Response.Write( Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/apmSuccess.aspx");%>'/>
            </div>

             <div class="form-row apm apm-url" style="display:none;">
                <label>
                    Cancel URL
                </label>
                <input type="text" id="cancel-url" name="cancel-url" placeholder='<%Response.Write( Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/apmCancel.aspx");%>'/>
            </div>

             <div class="form-row apm apm-url" style="display:none;">
                <label>
                    Failure URL
                </label>
                <input type="text" id="failure-url" name="failure-url" placeholder='<%Response.Write( Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/apmFailure.aspx");%>'/>
            </div>

             <div class="form-row apm apm-url" style="display:none;">
                <label>
                    Pending URL
                </label>
                <input type="text" id="pending-url" name="pending-url" placeholder='<%Response.Write( Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/apmPending.aspx");%>'/>
            </div>

            <div class="form-row no-apm">
                <label>Card Number</label>
                <input type="text" id="card" size="20" data-worldpay="number" value="4444333322221111" />
            </div>
            
            
            <div class="form-row no-apm">
                <label>CVC</label>
                <input type="text" id="cvc" size="4" data-worldpay="cvc" value="321" />
            </div>

            <div class="form-row no-apm">
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


            <div class="form-row reusable-token-row">
                <label>Reusable Token</label>
                <input type="checkbox" id="chkReusable" />
            </div>

            <div class="form-row no-apm">
                <label>Use 3DS</label>
                <input type="checkbox" id="chk3Ds" name="3ds" />
            </div>

            <div class="form-row no-apm">
                <label>Authorise Only</label>
                <input type="checkbox" id="chkAuthoriseOnly" name="authoriseOnly" />
            </div>

            <div class="header">Billing address</div>

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
                <label>Order Description</label>
                <input type="text" id="description" name="description" value="My test order" />
            </div>

            <div class="form-row">
                <label>
                    Statement Narrative
                </label>
                <input type="text" id="statement-narrative" maxlength="24" name="statement-narrative" value="Statement Narrative" />
            </div>

            <div class="form-row language-code-row">
                <label>Shopper Language Code</label>
                <input type="text" id="language-code" maxlength="2" data-worldpay="language-code" value="EN" />
            </div>

             <div class="form-row">
                <label>Shopper Email</label>
                <input type="text" id="shopper-email" name="shopper-email" value="shopper@email.com" />
            </div>

            <div class="form-row swift-code-row apm" style="display:none">
                <label>
                    Swift Code
                </label>
                <input type="text" id="swift-code" value="NWBKGB21" />
            </div>

            <div class="form-row large">
                <label class='left'>
                    Customer Identifiers (json)
                </label>
                <textarea id="customer-identifiers" rows="6" cols="30" name="customer-identifiers"></textarea>
            </div>

            <div class="apmName apm"></div>

            <input name="env" type="hidden" value=""/>
            <div>
                <asp:Button ID="PlaceOrder" runat="server" Text="Place Order" />
            </div>
        </asp:Panel>

        <asp:Panel runat="server" ID="SuccessPanel" Visible="false">
            <h2>Response</h2>
            <p>Order Code: <span id="order-code"><asp:Literal runat="server" ID="ResponseOrderCode" ViewStateMode="Disabled" /></span></p>
            <p>Token: <span id="token"><asp:Literal runat="server" ID="ResponseToken" ViewStateMode="Disabled" /></span></p>
            <p>Payment Status: <span id="payment-status"><asp:Literal runat="server" ID="ResponsePaymentStatus" ViewStateMode="Disabled" /></span></p>
            <pre><asp:Literal runat="server" ID="ResponseJson" ViewStateMode="Disabled" /></pre>
            <asp:Literal runat="server" ID="OrderResponse" ViewStateMode="Disabled"></asp:Literal>
        </asp:Panel>
        <uc:ErrorControl ID="ErrorControl" runat="server"/>

    </form>
    <script type="text/javascript">
        Worldpay.setClientKey('<%= Session["client_key"] %>');
        Worldpay.api_path = '<%= Session["apiEndpoint"] %>';

        $('#chkReusable').prop('checked', false);
        $('#chkReusable').change(function () {
            if ($(this).is(':checked') && $('#apm-name').val() != 'giropay') {
                Worldpay.reusable = true;
            }
            else {
                Worldpay.reusable = false;
            }
        });

        var form = document.getElementById('paymentForm');

        Worldpay.useForm(form, function (status, response) {
            if (response.error) {
                Worldpay.handleError(form, $('.payment-errors')[0], response.error);
            } else {
                var token = response.token;
                Worldpay.formBuilder(form, 'input', 'hidden', 'token', token);
                form.submit();
            }

        });
        
        $('#orderType').on('change', function () {

            $('.language-code-row').show();

            if ($(this).val() == 'APM') {
                Worldpay.tokenType = 'apm';
                $('.apm').show();
                $('.no-apm').hide();

                //initialize swift code field
                $('#swift-code').removeAttr('data-worldpay-apm');
                $('.swift-code-row').hide();
                $('.reusable-token-row').show();
                $('#language-code').attr('data-worldpay', 'language-code');

                //handle attributes
                $('#card').removeAttr('data-worldpay');
                $('#cvc').removeAttr('data-worldpay');
                $('#expiration-month').removeAttr('data-worldpay');
                $('#expiration-year').removeAttr('data-worldpay');
                $('#country-code').attr('data-worldpay', 'country-code');
            } else {
                Worldpay.tokenType = 'card';
                $('.apm').hide();
                $('.no-apm').show();
                $('#card').attr('data-worldpay', 'number');
                $('#cvc').attr('data-worldpay', 'cvc');
                $('#expiration-month').attr('data-worldpay', 'exp-month');
                $('#expiration-year').attr('data-worldpay', 'exp-year');
                $('#country-code').removeAttr('data-worldpay');
            }

        });

        $('#apm-name').on('change', function () {
            if ($(this).val() == 'giropay') {
                Worldpay.reusable = false;
                $('#swift-code').attr('data-worldpay-apm', 'swiftCode');
                $('.swift-code-row').show();

                //No language code for Giropay
                $('#language-code').removeAttr('data-worldpay');
                $('.language-code-row').hide();

                //Reusable token option is not available for Giropay
                $('.reusable-token-row').hide();

                //Set acceptance currency to EUR
                $('#currency').val('EUR');
            }
            else {
                //we don't want to send swift code to the api if the apm is not Giropay
                $('#swift-code').removeAttr('data-worldpay-apm');
                $('.swift-code-row').hide();
                $('.reusable-token-row').show();

                //language code enabled by default
                $('#language-code').attr('data-worldpay', 'language-code');
                $('.language-code-row').show();

                //Set acceptance currency to GBP
                $('#currency').val('GBP');
            }
        });

    </script>
</asp:Content>

<script>
    $(function() {
        $('#settings-refresh').click(function() {
            var obj = {};
            $('.config_input').each(function(i, value) {
                var input_name = $(value).attr('id');
                var input_value = $(value).val();
                obj[input_name] = input_value;
            });
            var formData = 'apiEndpoint=' + obj.endpoint;
            formData += '&jsEndpoint=' + obj.js_endpoint;
            formData += '&serviceKey=' + obj.service_key;
            formData += '&clientKey=' + obj.client_key;
            $.ajax({
                url: '<%Response.Write(Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/') + "/ConfigurationService.asmx/Test");%>',
                type: 'POST',
                dataType: 'text',
                data: formData,
                success: function() {
                    location.reload(true);
                }
            });
        });
    });
</script>
<style>
    #config-bar {
        background-color: #cccccc;
        border-bottom: 1px solid #808080;
        height: 50px;
        left: -20px;
        margin-bottom: 0;
        padding: 5px;
        position: relative;
        top: -20px;
        width: 830px;
    }

    #config-bar .row {
        height: 25px;
        width: 100%;
    }

    #config-bar .config-elem {
        float: left;
        font-size: 14px;
        width: 390px;
    }

    #config-bar .config-elem input {
        float: right;
        margin-right: 20px;
        width: 270px;
    }

    #config-bar .refresh-btn {
        float: right;
        position: absolute;
        right: 6px;
        top: 18px;
        width: 60px;
    }
</style>

<div id='config-bar'>
    <div class='row'>
        <div class="config-elem">
            <label>Endpoint:</label>
            <input type="text" id="endpoint" value="<%= Session["apiEndpoint"] %>" class='config_input'/>
        </div>
        <div class="config-elem">
            <label>JS Endpoint:</label>
            <input type="text" id="js_endpoint" value="<%= Session["js_endpoint"] %>" class='config_input'/>
        </div>
    </div>
    <div class='row'>
        <div class="config-elem">
            <label>Service Key:</label>
            <input type="text" id="service_key" value="<%= Session["service_key"] %>" class='config_input'/>
        </div>
        <div class="config-elem">
            <label>Client Key:</label>
            <input type="text" id="client_key" value="<%= Session["client_key"] %>" class='config_input'/>
        </div>
    </div>

    <button type='submit' id="settings-refresh" class='refresh-btn'>Refresh</button>
</div>
<ul id="top-nav">
    <li><a href="CreateOrder.aspx">Create Order</a></li>
    <li><a href="RecurringPayment.aspx">Create Order (CardOnFile)</a></li>
    <li><a href="CaptureAuthorizedOrder.aspx">Capture Authorised Order</a></li>
    <li><a href="CancelAuthorizedOrder.aspx">Cancel Authorised Order</a></li>
    <li><a href="RefundOrder.aspx">Refund</a></li>
    <li><a href="PartiallyRefundOrder.aspx">Partial Refund</a></li>
    <br />
    <li><a href="StoredCard.aspx">Stored Cards</a></li>
    <li><a href="GetOrder.aspx">Get Order</a></li>
</ul>
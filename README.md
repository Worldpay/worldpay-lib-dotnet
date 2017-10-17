# worldpay-lib-dotnet

This repository consists of four related projects:
* worldpay-lib-dotnet-3-5 and worldpay-lib-dotnet-2-0, the SDKs for .NET 3.5+ and .NET 2.0
* worldpay-sample-dotnet-3-5 and worldpay-sample-dotnet-2-0, the sample applications for the SDKs

Each of these is contained in a separate directory / VS solution.

#### Issues
Please see our [support contact information]( https://developer.worldpay.com/jsonapi/faq/articles/how-can-i-contact-you-for-support) to raise an issue.

worldpay-lib-dotnet-3-5 & 2-0
-------------------

DotNet Library for Worldpay REST API (.NET 3.5+, .NET 2.0)

## Usage

Initialize the REST client with the default URL and the specified service key and then use the required service:
```c#

WorldpayRestClient restClient = new WorldpayRestClient("https://api.worldpay.com/v1", "YOUR_SERVICE_KEY");

var orderRequest = new OrderRequest()
{
    amount = 1999,
    currencyCode = CurrencyCode.GBP,
    name = "Joe Bloggs",
    orderDescription = "Order description"
};

var address = new Address()
{
    address1 = "line 1",
    address2 = "line 2",
    city = "city",
    countryCode = CountryCode.GB,
    postalCode = "AB1 2CD"
};

orderRequest.billingAddress = address;

try {
    OrderResponse orderResponse = restClient.GetOrderService().Create(orderRequest);
    Console.WriteLine("Order code: " + orderResponse.orderCode);
} catch (WorldpayException e) {
	Console.WriteLine("Error code:" + e.apiError.customCode);
    Console.WriteLine("Error description: " + e.apiError.description);
    Console.WriteLine("Error message: " + e.apiError.message);
}

switch (orderResponse.paymentStatus)
{
    case OrderStatus.SUCCESS:
        // Handle successful payment
        break;
	
    case OrderStatus.FAILED:
        // Handle failed payment
        break;
	
    // Handle other statuses...
}
```

worldpay-sample-dotnet-3-5 & 2-0
-------------------

C# ASP .NET sample application which demonstrates integration with Worldpay API.

### Prerequisites

- A .NET-enabled development environment, such as Visual Studio or SharpDevelop. These below instructions assume you're using Visual Studio.
- .NET Framework 3.5

### Instructions

- Clone the sample source code from the Github repository at https://github.com/Worldpay/worldpay-lib-dotnet and open the solution file Worldpay.Sdk.Samples.sln in your IDE.
- Create a Worldpay account at https://online.worldpay.com/.
- In your account dashboard, navigate to Settings and API Keys and update the Web.config file in your solutions route folder with the corresponding value.
- Also in Web.config, set OrderLog to a location on your server which has read/write access permissions for your web server. In IIS on Windows, this usually means granting access to IUSR and IIS_IUSRS via the Windows Explorer folder properties dialog.
- Visual Studio users can now be able to run the application simply by opening the page 'CreateOrder.aspx' and clicking the 'run' button from the toolbar.
- To test credit card transactions via the IDE, simply fill out the details on the page and submit.

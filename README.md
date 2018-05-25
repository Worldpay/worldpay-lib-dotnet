worldpay-lib-dotnet
===================

This repository consists of following related projects:
* worldpay-lib-dotnet-3-5 for .NET 3.5 and sample application worldpay-sample-dotnet-3-5
* worldpay-lib-dotnet-4-0 for .NET 4.0 and sample application worldpay-sample-dotnet-4-0
* worldpay-lib-dotnet-4-6 for .NET 4.6 and sample application worldpay-sample-dotnet-4-6

Each is a VS solution you can open separately.

TLS v1.2 support
----------------

TLS version 1.0 and 1.1 are no longer supported by this SDK from 4th June, 2018. 
Any customers continuing to use TLS 1.0 or 1.1 will be unable to transact. 

Please follow the instructions below to update your application to ensure you are using TLS 1.2. 

.NET 2.0 is no longer supported due to this change. Please update to .NET 3.5 or later to be compatible.

To test your integration, we have created an endpoint and please use: ```https://api-test.worldpay.com/v1``` instead.  

### .NET 3.5

#### Step 1: Install Patch
.NET 3.5 did not initially support TLS 1.2. However, there has been a recent patch available which enables TLS 1.2 support.
Please ensure the appropriate patch below is installed in your application environment: 

| OS                        | Patch                                			      |
|---------------------------|-----------------------------------------------------|
| Win7 SP1/Win 2008 R2 SP1 	| KB3154518 - Reliability Rollup HR-1605 – NDP 2.0 SP2|
| Win8 RTM/Win 2012 RTM 	| KB3154519 - Reliability Rollup HR-1605 – NDP 2.0 SP2|
| Win8.1RTM/Win 2012 R2 RTM | KB3154520 - Reliability Rollup HR-1605 – NDP 2.0 SP2|
| Windows 10				| KB3156421 - 1605 HotFix Rollup through Windows Update|

####   Step 2: Replace DLL
You should replace your current ```Worldpay.Sdk.dll``` with the new version 1.2.0.1 for .NET 3.5.

####   Step 3: Add line to code base
The following line should be added to your code. This line explicitly sets the program to use TLS1.2.

```ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;```

### .NET 4.0

#### Step 1: Ensure .NET 4.5 is installed
.NET 4.0 does not support TLS 1.2, but if you have .NET 4.5 (or above) installed on your system you can use TLS 1.2 even if the application framework your are using does not support it.
Please ensure you install .NET 4.5 or above. 

####   Step 2: Replace DLL
You should replace you current ```Worldpay.Sdk.dll``` with the new version 1.2.0.1 for .NET 4.0.

####   Step 3: Add line to code base
The following line should be added to your code. This line explicitly sets the program to use TLS1.2.

```ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;```

### .NET 4.6 and above

#### Step 1: Replace DLL
You should replace your current ```Worldpay.Sdk.dll``` with the new version 1.2.0.1 for .NET 4.6.

#### Step 2: Make TLS 1.2 default
.NET 4.6 and above supports TLS 1.2, but it is not a default protocol. You will need to add the following line to your code base to ensure the connection uses TLS 1.2.

```ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12```

worldpay-lib-dotnet
-------------------

DotNet Library for Worldpay REST API (.NET 3.5+)

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
```

worldpay-sample-dotnet
-------------------

C# ASP .NET sample application which demonstrates integration with Worldpay API.

### Prerequisites

- A .NET-enabled development environment, such as Visual Studio or SharpDevelop. These below instructions assume you're using Visual Studio.
- .NET Framework 3.5+

### Instructions

- Clone the sample source code from the Github repository at https://github.com/Worldpay/worldpay-lib-dotnet and open the solution file Worldpay.Sdk.Samples.sln in your IDE.
- Create a Worldpay account at https://online.worldpay.com/.
- In your account dashboard, navigate to Settings and API Keys and update the Web.config file in your solutions route folder with the corresponding value.
- Also in Web.config, set OrderLog to a location on your server which has read/write access permissions for your web server. In IIS on Windows, this usually means granting access to IUSR and IIS_IUSRS via the Windows Explorer folder properties dialog.
- Visual Studio users can now be able to run the application simply by opening the page 'CreateOrder.aspx' and clicking the 'run' button from the toolbar.
- To test credit card transactions via the IDE, simply fill out the details on the page and submit.

Issues
------
Please see our [support contact information]( https://developer.worldpay.com/jsonapi/faq/articles/how-can-i-contact-you-for-support) to raise an issue.

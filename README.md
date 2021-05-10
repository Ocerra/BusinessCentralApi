# OData interface for Microsoft Dynamics 365 Business Central
Microsoft Business Central Dynamic 365 OData API 2.0

Retrieve contacts from Business Central using OData:
```csharp
var odata = new BusinessCentralOData(url, accessToken);

var response = odata.Contacts.Take(3).ToList();
```

Create Purchase Invoices in Business Central:
```csharp
var odata = new BusinessCentralOData(url, accessToken);

//See documentation here: https://docs.microsoft.com/en-us/dotnet/framework/data/wcf/how-to-add-modify-and-delete-entities-wcf-data-services 
var purchaseInvoice = new PurchaseInvoice
{
    CurrencyCode = "NZD",
    DueDate = DateTime.Now.Date.AddDays(7),
    InvoiceDate = DateTime.Now.Date,
    PostingDate = DateTime.Now.Date,
    VendorId = new Guid("00000000-0000-0000-0000-000000000000"), //Use vendor id from a Contact list
    VendorInvoiceNumber = "INV-0001"    
};

odata.AddToPurchaseInvoices(purchaseInvoice);

odata.SaveChanges();
```

If you want to learn more about [AP Automation for Business Central](https://www.ocerra.com/business-central) click here.

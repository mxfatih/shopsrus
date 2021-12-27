# ShopsRUs

ShopsRUs is a demo Restfull Application project for a retail market.
Has calculation Discount and preparing Invoice abilities for the given BillId.
By sending the any currency, you can get Invoice or Discount data in any currency.
It's platform independent.(Windows, Linux, IOS)

# Installation

You need "dotnet" to publish any paltform
Can publish to windows environment with:
```bash
dotnet publish "\\your-environment\ShopsRUs.csproj" -c Release -r win10-x64 --self-contained -o "\\your-hosting-environment"
```

# Development

Its a .Net Core WebAPI project coded in SOLID Principles.

# Language

C#

# Usage

After installation, application will listen at http://yourdomain/discount

Because this is a demo project, no Authorization or Authentication mechanism applied
and the sample data is hard coded.

## Sample Data
```bash
  //  Users
  1 => Employee
  {
      Name = "Adam",
      SurName = "Employee"
  },
  2 => Customer //  Member for 3 years
  {
      Name = "Adam",
      SurName = "Customer"
  },
  3 => Affiliate
  {
      Name = "Adam",
      SurName = "Affiliate"
  }
```

```bash
  //  Bills
  Employee's bill:
      Id = 1,
      Products = new List<Product>
      {
          "Product1", 100$, Clothing,
          "Product2", 150$, Electronic,
          "Product3", 80$, Electronic,
          "Product4", 90$, Grocery,
          "Product5", 50$, Clothing ,
          "Product6", 60$, Grocery,
          "Product7", 70$, Clothing
      }
      
  Customer's bill:
      Id = 2,
      Products = new List<Product>
      {
          "Product1", 200$, Clothing,
          "Product2", 300$, Electronic,
          "Product3", 160$, Electronic,
          "Product4", 180$, Grocery,
          "Product5", 100$, Clothing ,
          "Product6", 120$, Grocery,
          "Product7", 140$, Clothing
      }
      
  Affiliate's bill:
      Id = 3,
      Products = new List<Product>
      {
          "Product1", 300$, Clothing,
          "Product2", 450$, Electronic,
          "Product3", 240$, Electronic,
          "Product4", 270$, Grocery,
          "Product5", 150$, Clothing ,
          "Product6", 180$, Grocery,
          "Product7", 210$, Clothing
      }
```

```bash
Currency
{
    TRY = 1,
    Dollar = 2,
    Euro = 3
}
```

You can get an Invoice for a bill:
```bash
http://yourdomain/discount/GetInvoice?billid=3&currency=1 -GET
```

You can get Discount for a bill:
```bash
http://yourdomain/discount/GetBillDiscount?billid=3&currency=1 -GET
```


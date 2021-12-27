# ShopsRUs

ShopsRUs is a demo project for a retail market to calculate discount and prepare invoice for the given BillId.

# Development

Its a .Net Core WebAPI project coded in SOLID Principles.

# Language

C#

# Usage

After installation application will listen at http://yourdomain/discount

Becouse of a demo project no Authorization or Authentication mechanism applied.
The sample data is hard coded.
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



You can get 

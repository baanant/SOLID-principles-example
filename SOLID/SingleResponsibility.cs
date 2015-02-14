using System;

namespace SOLID.SingleResponsibilityPrinciple
{
    /// These classes are written according to the first principle of SOLID.
    /// It's calle single responsibility principle and it means that one class should 
    /// have only one responsibility. In this case, Product class is in charge of product details,
    /// and Country class is in charge of country specific details. 

    public class Product : IProduct
    {
        public Product() 
        {
            this.PID = Guid.NewGuid();
        }

        public Product(string name, string description):this()
        {
            this.Name = name;
            this.Description = description;
        }

        public Guid PID { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICountry ProductionCountry { get; set; }

    }

    interface IProduct
    {
        string Description { get; set; }
        string Name { get; set; }
        Guid PID { get; }

        ICountry ProductionCountry { get; set; }
    }

    public class Country : ICountry 
    {
        public string EnglishName { get; set; }

        public string CountryCodeISOa2 { get; set; }

        public string CountryCodeISOa3 { get; set; }

    }

    public interface ICountry
    {
        string CountryCodeISOa2 { get; set; }
        string CountryCodeISOa3 { get; set; }
        string EnglishName { get; set; }
    }


    ///The example below describes how you should NOT create these two classes as one.
    ///The code cannot be easily mantained, the lack of separation is unnatural and it is not clean.
    ///If we now have to add for example property LocalName to the country, the existing code could 
    ///easily get broken.
    public class ProductCountry : IProductCountry
    {
        public ProductCountry() 
        {
            this.PID = Guid.NewGuid();
        }

        public ProductCountry(string name, string description, string countryName, string countryCodeA2, string countryCodeA3):this()
        {
            this.Name = name;
            this.Description = description;
            this.EnglishName = countryName;
            this.CountryCodeISOa2 = countryCodeA2;
            this.CountryCodeISOa3 = countryCodeA3; 
        }

        public Guid PID { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string EnglishName { get; set; }

        public string CountryCodeISOa2 { get; set; }

        public string CountryCodeISOa3 { get; set; }
    }

    public interface IProductCountry
    {
        string CountryCodeISOa2 { get; set; }
        string CountryCodeISOa3 { get; set; }
        string Description { get; set; }
        string EnglishName { get; set; }
        string Name { get; set; }
        Guid PID { get; }
    }
 
}

using System;
using System.Collections.Generic;
using EntityApi.Models; 
namespace EntityApi
{
    public static class MockData
    {
        public static List<Entity> Entities = new List<Entity>
        {
            new Entity
            {
                Id = "1",
                Addresses = new List<Address>
                {
                    new Address
                    {
                        AddressLine = "123 Main St",
                        City = "Anytown",
                        Country = "USA"
                    }
                },
                Dates = new List<Date>
                {
                    new Date
                    {
                        DateType = "Birthdate",
                        DateValue = new DateTime(1990, 5, 15)
                    }
                },
                Deceased = false,
               
                Names = new List<Name>
                {
                    new Name
                    {
                        FirstName = "John",
                        Surname = "Doe"
                    }
                }
            },
            new Entity
            {
                Id = "2",
                Addresses = new List<Address>
                {
                    new Address
                    {
                        AddressLine = "456 Oak St",
                        City = "Smallville",
                        Country = "USA"
                    }
                },
                Dates = new List<Date>
                {
                    new Date
                    {
                        DateType = "Birthdate",
                        DateValue = new DateTime(1985, 8, 20)
                    }
                },
                Deceased = false,
               
                Names = new List<Name>
                {
                    new Name
                    {
                        FirstName = "Jane",
                        Surname = "Smith"
                    }
                }
            },
           new Entity
{
    Id = "3",
    Addresses = new List<Address>
    {
        new Address
        {
            AddressLine = "789 Elm St",
            City = "Metro City",
            Country = "USA"
        }
    },
    Dates = new List<Date>
    {
        new Date
        {
            DateType = "Birthdate",
            DateValue = new DateTime(1978, 3, 10)
        }
    },
    Deceased = true,
    
    Names = new List<Name>
    {
        new Name
        {
            FirstName = "Michael",
            Surname = "Johnson"
        }
    }
},
new Entity
{
    Id = "4",
    Addresses = new List<Address>
    {
        new Address
        {
            AddressLine = "987 Pine St",
            City = "Hilltown",
            Country = "USA"
        }
    },
    Dates = new List<Date>
    {
        new Date
        {
            DateType = "Birthdate",
            DateValue = new DateTime(1995, 12, 5)
        }
    },
    Deceased = false,
   
    Names = new List<Name>
    {
        new Name
        {
            FirstName = "Emily",
            Surname = "Williams"
        }
    }
},
new Entity
{
    Id = "5",
    Addresses = new List<Address>
    {
        new Address
        {
            AddressLine = "321 Cedar St",
            City = "Villageville",
            Country = "USA"
        }
    },
    Dates = new List<Date>
    {
        new Date
        {
            DateType = "Birthdate",
            DateValue = new DateTime(1980, 9, 25)
        }
    },
    Deceased = false,
   
    Names = new List<Name>
    {
        new Name
        {
            FirstName = "David",
            Surname = "Brown"
        }
    }
}

        };
    }
}


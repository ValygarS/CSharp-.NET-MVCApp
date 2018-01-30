using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CA1_MVCApp.Models
{
    public static class MockDB
    {
        private static List<Person> pList = new List<Person>
        {
            new Person {FirstName = "Gwen", LastName = "Martins", AreaCode = "086", PhoneNumber = "1236782"},
            new Person {FirstName = "Jayson", LastName = "Pan", AreaCode = "087", PhoneNumber = "1671655"},
            new Person {FirstName = "Kiara", LastName = "Davis", AreaCode = "085", PhoneNumber = "1891234"},
            new Person {FirstName = "William", LastName = "McConnell", AreaCode = "085", PhoneNumber = "1315508"},
            new Person {FirstName = "Tom", LastName = "Bradford", AreaCode = "083", PhoneNumber = "1451528"},
            new Person {FirstName = "Katherine", LastName = "McGuire", AreaCode = "089", PhoneNumber = "1652907"},
            new Person {FirstName = "Andrew", LastName = "Johnson", AreaCode = "089", PhoneNumber = "1668913"},
            new Person {FirstName = "Micheal", LastName = "Marsden", AreaCode = "087", PhoneNumber = "1216742"},
            new Person {FirstName = "Ben", LastName = "OLeary", AreaCode = "085", PhoneNumber = "1885666"},
            new Person {FirstName = "Jolie", LastName = "Plaskett", AreaCode = "085", PhoneNumber = "1752417"}
        };

        public static List<Person> getContacts()
        {
            return pList;
        }




        
    }
}
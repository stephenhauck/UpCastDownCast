using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace UpCastDownCast
{
    class Program
    {
        static void Main(string[] args)
        {
            //First make an instance
            var employeeWithCityState = new EmployeeWithCityState()
            {
                Name = "Bob Jones",
                Salary = 2000,
                Department = "Human resources",
                City = "San Diego",
                State = "CA"
            };

            //From the Netonsoft docs...
            //The JsonSerializer converts.NET objects into their JSON equivalent and back again by
            //mapping the .NET object property names to the JSON property names and copies the values for you.



           //Serialize it
           var serializedEmployeeWithCityState = JsonConvert.SerializeObject(employeeWithCityState);
            //What it looks like as JSON
            //{
            //    "City": "San Diego",
            //    "State": "CA",
            //    "Name": "Bob Jones",
            //    "Salary": 2000,
            //    "Department": "Human resources"
            //}



            //Downcast it 
            var employee = JsonConvert.DeserializeObject<Employee>(serializedEmployeeWithCityState);
            var serializedEmployee = JsonConvert.SerializeObject(employee);
            //Heres what it looks like 
            //{
            //    "Name": "Bob Jones",
            //    "Salary": 2000,
            //    "Department": "Human resources"
            //}


            //Upcast it 
            var employeeWithCountry = JsonConvert.DeserializeObject<EmployeeWithCountry>(serializedEmployeeWithCityState);
            var serializedEmployeeWithCountry = JsonConvert.SerializeObject(employeeWithCountry);
            //What it looks like 
            //{
            //    "Country": null,
            //    "City": "San Diego",
            //    "State": "CA",
            //    "Name": "Bob Jones",
            //    "Salary": 2000,
            //    "Department": "Human resources"
            //}

            //Note that country is null because it is not a property in EmployeeWithCityState or Employee
            //but the property is there 
            employeeWithCountry.Country = "United States";
            serializedEmployeeWithCountry = JsonConvert.SerializeObject(employeeWithCountry);
            //What it looks like 
            //{
            //    "Country": "United States",
            //    "City": "San Diego",
            //    "State": "CA",
            //    "Name": "Bob Jones",
            //    "Salary": 2000,
            //    "Department": "Human resources"
            //}


            //if you need to map fields with differing names you can accomplish that with annotations



        }
    }

    public class Employee
    {
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Department { get; set; }
    }

    public class EmployeeWithCityState : Employee
    {
        public string City { get; set; }
        public string State { get; set; }
    }


    public class EmployeeWithCountry : EmployeeWithCityState
    {
        public string Country { get; set; }
    }

}

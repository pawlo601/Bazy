﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Client
{
    public class Address
    {
        public string Street { get; set; }
        public string NumberOfBuilding { get; set; }
        public string City { get; set; }
        public string Code { get; set; }
        public string Country { get; set; }
        public Address()
        {
            Street = "Ulica";
            NumberOfBuilding = "Numer";
            City = "Miasto";
            Code = "12-345";
            Country = "Państwo";
        }
        public Address(String street, String number, 
                        String city, String code, 
                        String country)
        {
            Street = street;
            NumberOfBuilding = number;
            City = city;
            Code = code;
            Country = country;
        }
        public override string ToString()
        {
            return "Ulica: " + Street + " " + NumberOfBuilding + "\n" +
                    "Miejscowość: " + City + " " + Code + "\n" +
                    "Państwo: " + Country + "\n";
                    
        }

    }
}

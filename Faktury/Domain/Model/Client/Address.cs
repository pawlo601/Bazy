using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Client
{
    public class Address
    {
        public virtual int IDAdres { get; set; }
        public virtual string Street { get; set; }
        public virtual string NumberOfBuilding { get; set; }
        public virtual string City { get; set; }
        public virtual string Code { get; set; }
        public virtual string Country { get; set; }

        public Address()
        {
            IDAdres = -1;
            Street = "asdfa";
            NumberOfBuilding = "asdfasdfasdf";
            City = "asdfadf";
            Code = "12-345";
            Country = "Psfo";
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

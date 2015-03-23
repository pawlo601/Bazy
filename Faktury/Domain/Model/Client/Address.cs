using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Client
{
    public class Address
    {
        public String Street { get; set; }
        public String NumberOfBuilding { get; set; }
        public String City { get; set; }
        public String Code { get; set; }
        public String Country { get; set; }

        public Address(String street, String number, String city, String code, String country);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Client
{
    public class PersonalData
    {
        public String Name { get; set; }
        public String SurName { get; set; }
        public String NameOfCompany { get; set; }

        public PersonalData(String name, String surname, String com);
    }
}

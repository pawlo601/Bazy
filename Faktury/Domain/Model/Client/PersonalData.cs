using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Client
{
    public class PersonalData
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string NameOfCompany { get; set; }
        public PersonalData(string com)
        {
            Name = "-";
            SurName = "-";
            NameOfCompany = com;
        }
        public PersonalData(string name, string surname)
        {
            Name = name;
            SurName = surname;
            NameOfCompany = "-";
        }
        public PersonalData(string name, string surname, string com)
        {
            Name = name;
            SurName = surname;
            NameOfCompany = com;
        }
        public override string ToString() 
        {
            string text = "";
            if (NameOfCompany != "-")
                text += "Firma: " + NameOfCompany;
            else
                text += "Imie: " + Name + "\n" +
                    "Nazwisko: " + SurName;
            return text;
        }
    }
}

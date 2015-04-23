using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Client
{
    public enum Typ { Firma, KlientPrywatny };
    public class PersonalData
    {
        public virtual string Name { get; set; }
        public virtual string SurName { get; set; }
        public virtual string NameOfCompany { get; set; }
        public virtual Typ Type { get; set; }

        public PersonalData()
        {
            Random rand = new Random();
            if(rand.Next(0,100)%2==0)
            {
                Name = "-";
                SurName = "-";
                NameOfCompany = "Nazwa firmy";
                NameOfCompany += rand.Next(1, 2000000).ToString();
                Type = Typ.Firma;
            }
            else
            {
                Name = "Imie" + rand.Next(1, 2000000).ToString();
                SurName = "Nazwisko"+rand.Next(1, 2000000).ToString();
                NameOfCompany = "-";
                Type = Typ.KlientPrywatny;
            }
            
        }
        public PersonalData(string com)
        {
            Name = "-";
            SurName = "-";
            NameOfCompany = com;
            Type = Typ.Firma;
        }
        public PersonalData(string name, string surname)
        {
            Name = name;
            SurName = surname;
            NameOfCompany = "-";
            Type = Typ.KlientPrywatny;
        }
        public override string ToString() 
        {
            string text = "";
            if (Type.Equals(Typ.Firma))
                text += "Firma: " + NameOfCompany;
            else
                text += "Imie: " + Name + "\n" +
                    "Nazwisko: " + SurName;
            return text;
        }
        public void ChangeToCompany(string name)
        {
            Type = Typ.Firma;
            NameOfCompany = name;
            Name = SurName = null;
        }
        public void ChangeToPrivate(string name, string surname)
        {
            Type = Typ.KlientPrywatny;
            Name = name;
            SurName = surname;
            NameOfCompany = null;
        }
    }
}

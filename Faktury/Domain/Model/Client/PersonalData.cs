﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Client
{
    public enum Typ { Firma, KlientPrywatny };
    public class PersonalData
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string NameOfCompany { get; set; }
        public Typ Type { get; private set; }
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

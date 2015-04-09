using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Client
{
    public abstract class IdentificationNumber
    {
        protected string Number;
        public IdentificationNumber()
        {
            Number = "Przykładowy";
        }
        public IdentificationNumber(string num)
        {
            Number = num;
        }
        public virtual string GetNumber()
        {
            return Number;
        }
        public string ToString()
        {
            return "Numer: " + Number;
        }
    }
}

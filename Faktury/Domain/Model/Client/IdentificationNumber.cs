using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Client
{
    public abstract class IdentificationNumber
    {
        protected virtual string Number { get; set; }
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
        public override string ToString()
        {
            return "Numer: " + Number;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Client
{
    public abstract class IdentificationNumber
    {
        private String Number;
        public IdentificationNumber(string num)
        {
            Number = num;
        }
        public String GetNUmber();
        public String ToString();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Client
{
    public class Phone : IdentificationNumber
    {
        private String Prefix;
        public extern String GetNumber();
    }
}

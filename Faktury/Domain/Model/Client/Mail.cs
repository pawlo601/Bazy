using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Client
{
    public class Mail : IdentificationNumber
    {
        private String NameOfServer;
        public extern String GetNumber();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Client
{
    public class NIP : IdentificationNumber
    {
        public NIP(string number)
            :base(number)
        {

        }
    }
}

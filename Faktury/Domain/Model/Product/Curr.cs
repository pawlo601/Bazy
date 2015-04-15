using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Product
{
    public class Curr
    {
        public virtual Waluta Name { get; set; }
        public virtual double ExchangeInTheRelationToPLN { get; set; }//X PLN=1 Waluta
    }
}

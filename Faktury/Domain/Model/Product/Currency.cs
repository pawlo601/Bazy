using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Product
{
    public class Currency
    {
        public virtual int ID { get; set; }
        public virtual Waluta Name { get; set; }
        public virtual double ExchangeInTheRelationToPLN { get; set; }//X PLN=1 Waluta
        public Currency()
        {
            ID = -1;
            Name = Waluta.PLN;
            ExchangeInTheRelationToPLN = 1.0123f;
        }
        public override string ToString()
        {
            return String.Format("ID: {0}\nWaluta: {1}\nExchange: {2}", ID.ToString(), Name.ToString(), ExchangeInTheRelationToPLN.ToString());
        }
    }
}

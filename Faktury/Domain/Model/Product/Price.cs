using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Product
{
    public class Price
    {
        private Money NetPrice;
        public float VAT { get; set; }
        public Price(Money a, float vat);
        public Price(long val, String waluta, float vat)
        {
            this.NetPrice = new Money(val, waluta);
            this.VAT = vat;
        }
        public Money GetGross();
        public Money GetNet();
    }
}

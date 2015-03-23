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
        public Money GetGross(String curr);
        public Money GetNet();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Product
{
    public class Price
    {
        public Money NetPrice { get; private set; }
        public float VAT { get; set; }
        public Price(Money a, float vat)
        {
            NetPrice = a;
            if (vat >= 0.0f && vat < 1.0f)
                VAT = vat;
            else
            {
                VAT=0.0f;
                throw new Exception("Zła wartośc VAT, ustawiono na 0%");
            } 
        }
        public Price(long val, String waluta, float vat)
        {
            try
            {
                this.NetPrice = new Money(val, waluta);
            }
            catch(Exception e)
            {
                throw e;
            }
            if (vat >= 0.0f && vat < 1.0f)
                VAT = vat;
            else
            {
                VAT = 0.0f;
                throw new Exception("Zła wartośc VAT, ustawiono na 0%");
            } 
        }
        public Money GetGross()
        {
            return new Money(VAT*NetPrice.Value,NetPrice.NameOfCurrency.ToString());
        }
    }
}

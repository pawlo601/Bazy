using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Product
{
    public class Price
    {
        public virtual Money NetPrice { get; set; }
        public virtual float VAT { get; set; }
        public Price()
        {
            NetPrice = new Money();
            VAT = 0.19f;
        }
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
        public Price(float val, Waluta waluta, float vat)
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
            return new Money(VAT*NetPrice.Value,NetPrice.NameOfCurrency);
        }
        public void ChangeCurrency(Waluta nowa)
        {
            Money a = new Money(NetPrice.GetValueIn(nowa),nowa);
            NetPrice = a;
        }
        public override string ToString()
        {
            string a = String.Format("Cena netto :{0}{3}Cena brutto :{1}{3}Vat: {2}%",
                                    NetPrice.ToString(), this.GetGross().ToString(), VAT, Environment.NewLine);
            return a;
        }
    }
}

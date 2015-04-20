using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Product
{
    public enum Waluta {PLN,EUR,USD };
    public class Money
    {
        public virtual float Value { get; set; }
        public virtual Waluta NameOfCurrency { get; set;  }
        public Currencies Curr;
        public Money()
        {
            Value = 0.00f;
            NameOfCurrency = Waluta.PLN;
            Curr = Currencies.GetInstance();
        }
        public Money(float val, Waluta waluta)
        {
            NameOfCurrency = waluta;
            if (val < 0.0f)
                throw new Exception("Zła wartość.\n");
            else 
            {
                Value = val;
                Curr = Currencies.GetInstance();
            }
        }
        public void RefreshValue()
        {
            this.Curr.Refresh();
        }
        public void ChengeCurrency(Waluta curr)
        {
            try
            {
                Value = GetValueIn(curr);
                NameOfCurrency = curr;
            }
            catch (Exception e)
            {
                throw e;
            }            
        }
        public float GetValueIn(Waluta waluta)
        {
            if (waluta == NameOfCurrency)
                return Value;
            else
            {
                try
                {
                    return (float)(Curr.Swap(NameOfCurrency, waluta)) * Value;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
        public override string ToString()
        {
            string a = String.Format("{0}{1}", Value, NameOfCurrency);
            return a;
        }
    }
}

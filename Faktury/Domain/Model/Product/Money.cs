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
        public Currencies Curr { get; private set; }
        public Money()
        {
            Random rand = new Random();
            Value = float.MaxValue * (float)(rand.NextDouble());
            int a = rand.Next(0, 2);
            switch(a)
            {
                case 0:
                    NameOfCurrency = Waluta.PLN;
                    break;
                case 1:
                    NameOfCurrency = Waluta.EUR;
                    break;
                case 2:
                    NameOfCurrency = Waluta.USD;
                    break;
                default:
                    NameOfCurrency = Waluta.PLN;
                    break;
            }
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
            return String.Format("{0}{1}", Value, NameOfCurrency);
        }
    }
}

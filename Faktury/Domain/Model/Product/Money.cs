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
        public float Value { get; set; }
        public Waluta NameOfCurrency { get; private set; }
        private static Currency Curr = Currency.GetInstance();


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
                catch(Exception e)
                {
                    throw e;
                }
            }
        }
        public Money(float val, string waluta)
        {
            bool Flags = true;
            foreach(Waluta a in Enum.GetValues(typeof(Waluta)))
            {
                if (a.ToString() == waluta)
                {
                    Flags = false;
                    NameOfCurrency = a;
                }
            }
            if (Flags)
                throw new Exception("Zła nazwa waluty.\n");
            if (val < 0.0f)
                throw new Exception("Zła wartość.\n");
            else
                Value = val;
        }

        public static void RefreshValue()
        {
            Curr.Refresh();
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
    }
}

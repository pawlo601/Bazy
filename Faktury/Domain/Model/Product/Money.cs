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
        public long Value{ get; set; }
        private Waluta NameOfCurrency;
        private static Currency Curr;

        public String GetCurrency();
        public long GetValueIn(String waluta);
        public Money(long val, string waluta)
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
            if (val < 0L)
                throw new Exception("Zła wartość.\n");
            else
                Value = val;
        }
        public void RefreshValue();
        public void ChengeCurrency(String curr);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Product
{
    public class Money
    {
        public long Value{ get; set; }
        private String NameOfCurrency;
        private static Currency Curr;

        public String GetCurrency();
        public long GetValueIn(String waluta);
        public Money(long val, String waluta);
        public void RefreshValue();
        public void ChengeCurrency(String curr);
    }
}

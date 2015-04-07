using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Product
{
    public struct Curr
    {
        private Waluta Name;
        private double ExchangeInTheRelationToPLN;
    }
    public class Currency
    {
        private static List<Curr> ListOfCurrency;
        private static Currency instance;
        private Currency() 
        {
            ListOfCurrency = new List<Curr>();
        }
        public double GetExchange(Waluta name)
        {
            if(instance==null)
            {
                instance = new Currency();
            }
            double pomocnicza = instance.Find(name);
            if (pomocnicza == -1.0f)
                throw new Exception("Nie znaleziono waluty.\n");
            else
                return pomocnicza;

        }
        private double Find(Waluta Name)
        {
            foreach ( Curr a in ListOfCurrency)
            {
                if (a.Name == Name)
                    return a.ExchangeInTheRelationToPLN;
            }
            return -1.0f;
        }
        public void Refresh()
        {//implementacja potrzebna
        }
    }
}

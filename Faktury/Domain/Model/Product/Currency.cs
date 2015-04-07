using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Product
{
    public struct Curr
    {
        public Waluta Name;
        public double ExchangeInTheRelationToPLN;//X PLN=1 Waluta
    }
    public class Currency
    {
        private static List<Curr> ListOfCurrency;
        private static Currency instance=new Currency();
        public static Currency GetInstance()
        {
            return instance;
        }
        private Currency() 
        {
            ListOfCurrency = new List<Curr>();
            Refresh();
        }
        public double GetExchange(Waluta name)
        {
            double pomocnicza = instance.Find(name);
            if (pomocnicza == -1.0f)
                throw new Exception("Nie znaleziono waluty.\n");
            else
                return pomocnicza;
        }
        public double Find(Waluta Name)
        {
            foreach ( Curr a in ListOfCurrency)
            {
                if (a.Name == Name)
                    return a.ExchangeInTheRelationToPLN;
            }
            return -1.0f;
        }
        public double Swap(Waluta from, Waluta to)
        {
            double przelicznik=0.0f;
            double xfrom = Find(from);
            double xto = Find(to);
            if (xfrom == -1.0f || xto == -1.0f)
                throw new Exception("Nie ma informacji to tej walucie.\n");
            przelicznik = xfrom / xto;
            return przelicznik;
        }
        public void Refresh()
        {//implementacja potrzebna
        }
    }
}

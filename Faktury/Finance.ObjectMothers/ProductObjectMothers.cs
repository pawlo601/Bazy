using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Product;

namespace Finance.ObjectMothers
{
    public class ProductObjectMothers
    {
        public static Product CreateProductPrzedmiotPLN( )
        {
            Money mon = new Money(5000.0f, Waluta.PLN);
            Price pr = new Price(mon, 0.19f);
            Product a = new Product("Laptop1", TypProduktu.Przedmiot, pr);
            return a;
        }
        public static Product CreateProductPrzedmiotEUR()
        {
            Money mon = new Money(5000.0f, Waluta.EUR);
            Price pr = new Price(mon, 0.19f);
            Product a = new Product("Laptop1", TypProduktu.Przedmiot, pr);
            return a;
        }
        public static Product CreateProductUslugaPLN()
        {
            Money mon = new Money(5000.0f, Waluta.PLN);
            Price pr = new Price(mon, 0.19f);
            Product a = new Product("Laptop1", TypProduktu.Usługa, pr);
            return a;
        }
        public static Product CreateProductUslugaUSD()
        {
            Money mon = new Money(5000.0f, Waluta.USD);
            Price pr = new Price(mon, 0.19f);
            Product a = new Product("Laptop1", TypProduktu.Usługa, pr);
            return a;
        }
        public static Price CreatePricePLN()
        {
            Price pr = new Price(12.04f, Waluta.PLN, 0.20f);
            return pr;
        }
        public static Price CreatePriceUSD()
        {
            Price pr = new Price(12.04f, Waluta.USD, 0.20f);
            return pr;
        }
        public static Currencies CreateCurrency()
        {
            Currencies cu = Currencies.GetInstance();
            return cu;
        }
        public static Money CreateMoneyPLN()
        {
            Money mon = new Money(123.70f, Waluta.PLN);
            return mon;
        }
        public static Money CreateMoneyUSD()
        {
            Money mon = new Money(123.70f, Waluta.USD);
            return mon;
        }
        public static Money CreateMoneyEUR()
        {
            Money mon = new Money(123.70f, Waluta.EUR);
            return mon;
        }
    }
}

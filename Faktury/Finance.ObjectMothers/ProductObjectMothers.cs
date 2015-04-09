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
        public static Product CreateProductUslugaPLN()
        {
            Money mon = new Money(50.0f,Waluta.PLN);
            Price pr = new Price(mon,0.19f);
            Product a = new Product("Czyszczenie Laptopa", TypProduktu.Usługa, pr);
            return a;
        }
        public static Product CreateProductPrzedmiotPLN()
        {
            Money mon = new Money(5000.0f, Waluta.PLN);
            Price pr = new Price(mon, 0.19f);
            Product a = new Product("Laptop1", TypProduktu.Przedmiot, pr);
            return a;
        }
        public static Product CreateProductPrzedmiotUSD()
        {
            Money mon = new Money(1000.0f, Waluta.USD);
            Price pr = new Price(mon, 0.19f);
            Product a = new Product("Laptop2", TypProduktu.Przedmiot, pr);
            return a;
        }
    }
}

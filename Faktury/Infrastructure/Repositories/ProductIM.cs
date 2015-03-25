using Domain.Model.Product;
using Domain.Model.Product.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductIM : IProductRepositories
    {
        private List<Product> products=new List<Product>();
        private List<Curr> curr;

        public ProductIM()
        {
            Product a1 = new Product("Pierwsza rzecz", "Usługa", "Komentarz");
            Price c1 = new Price(10,"PLN",19.0f);
            a1.SetPrice(c1);
            products.Add(a1);
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Product a2 = new Product("Druga rzecz", "Produkt", "Komentarz2");
            Price c2 = new Price(20, "EUR", 8.0f);
            a2.SetPrice(c2);
            products.Add(a2);
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Product a3 = new Product("Trzecia rzecz", "Usługa", "Komentarz3");
            Price c3 = new Price(100, "USD", 1.0f);
            a3.SetPrice(c3);
            products.Add(a3);
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Product a4 = new Product("Druga rzecz", "Produkt", "Komentarz4");
            Price c4 = new Price(5, "GBD", 20.0f);
            a4.SetPrice(c4);
            products.Add(a4);
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        }
        public void Insert(Product product)
        {
            products.Add(product);
        }
        public void Delete(string Id)
        {
            foreach (var a in products)
            {
                if (a.GetId() == Id)
                    products.Remove(a);
            }
        }
        public Product Find(string Id)
        {
            foreach (var a in products)
            {
                if (a.GetId() == Id)
                    return a;
            }
            return null;
        }
        public List<Curr> GetCurrency()
        {
            return curr;
        }
        public void SaveCurrency(List<Curr> list)
        {
            curr = list;
        }
        public List<Product> FindAll()
        {
            return products;
        }
    }
}

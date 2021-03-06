﻿using Domain.Model.Product;
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
        private List<Currency> curr=new List<Currency>();

        public ProductIM()
        {
            Price c1 = new Price(10, Waluta.PLN, 19.0f);
            Product a1 = new Product("Pierwsza rzecz", TypProduktu.Usługa,c1);
            products.Add(a1);
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Price c2 = new Price(20, Waluta.EUR, 8.0f);
            Product a2 = new Product("Druga rzecz", TypProduktu.Przedmiot, c2);
            products.Add(a2);
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Price c3 = new Price(100, Waluta.USD, 1.0f);
            Product a3 = new Product("Trzecia rzecz", TypProduktu.Usługa, c3);
            products.Add(a3);
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            Price c4 = new Price(5, Waluta.EUR, 20.0f);
            Product a4 = new Product("Druga rzecz", TypProduktu.Przedmiot, c4);
            products.Add(a4);
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        }
        public void Insert(Product product)
        {
            products.Add(product);
        }
        public void Delete(int Id)
        {
            foreach (var a in products)
            {
                if (a.IDProduct == Id)
                    products.Remove(a);
            }
        }
        public Product Find(int Id)
        {
            foreach (var a in products)
            {
                if (a.IDProduct == Id)
                    return a;
            }
            return null;
        }
        public List<Currency> FindAllCurrency()
        {
            return curr;
        }
        public void SaveCurrency(List<Currency> list)
        {
            curr = list;
        }
        public List<Product> FindAll()
        {
            return products;
        }
        public void Delete(string name)
        {
            foreach (var a in products)
            {
                if (a.NameOfProduct == name)
                    products.Remove(a);
            }
        }
        public Product Find(string name)
        {
            foreach (Product a in products)
            {
                if (a.NameOfProduct == name)
                    return a;
            }
            return null;
        }
        public void Insert(Currency cuurr)
        {
            curr.Add(cuurr);
        }
    }
}

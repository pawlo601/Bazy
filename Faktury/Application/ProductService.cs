using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Product.Repositories;
using Domain.Model.Product;
using Infrastructure.Repositories;
using System.IO;


namespace Application
{
    public class ProductService:IProductService
    {
        private IProductRepositories repo;

        public ProductService()
        {
            repo = new ProductIM();
        }
        public ProductService(IProductRepositories re)
        {
            repo = re;
        }
        public void CreateDoc(string nameOfProduct)
        {
            Product a = repo.Find(nameOfProduct);
            string path = @"c:\bazy\";
            path += a.NameOfProduct + ".txt";
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine(a.ToString());
                }
            }
        }
        public Money Exchange(Money pieniadz, Waluta wal)
        {
            Money a = new Money(pieniadz.Value,pieniadz.NameOfCurrency);
            a.ChengeCurrency(wal);
            return a;
        }
        public List<Curr> GetCurrency()
        {
            Money a = new Money();
            return a.Curr.ListOfCurrency;
        }
    }
}

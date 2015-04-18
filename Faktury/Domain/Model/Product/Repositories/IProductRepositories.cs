using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Product.Repositories
{
    public interface IProductRepositories
    {
        void Insert(Product product);
        void Insert(Currency cuurr);
        void Delete(int Id);
        Product Find(int Id);
        void Delete(string name);
        Product Find(string name);
        List<Currency> FindAllCurrency();
        List<Product> FindAll();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Product.Repositories
{
    public interface IProductRepositories
    {
        void Insert(Product client);
        void Delete(Guid Id);
        Product Find(Guid Id);
        void Delete(string name);
        Product Find(string name);
        List<Curr> GetCurrency();
        List<Product> FindAll();
    }
}

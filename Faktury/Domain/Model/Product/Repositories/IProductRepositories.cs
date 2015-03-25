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
        void Delete(String Id);
        Product Find(String Id);
        List<Curr> GetCurrency();
        List<Product> FindAll();
    }
}

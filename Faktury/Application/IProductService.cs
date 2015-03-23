using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Product;


namespace Application
{
    public interface IProductService
    {
        void CreateDoc(Product p);
        Money Exchange(String wala, String walb);
    }
}

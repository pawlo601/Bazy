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
        void CreateDoc(string nameOfProduct);
        Money Exchange(Money pieniadz, Waluta wal);
    }
}

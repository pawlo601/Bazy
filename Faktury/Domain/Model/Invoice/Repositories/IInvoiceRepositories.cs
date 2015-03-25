using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Invoice.Repositories
{
    public interface IInvoiceRepositories
    {
        void Insert(Invoice client);
        void Delete(String Id);
        Invoice Find(String Id);
        List<Invoice> FindAll();
        List<Invoice> FindAllPerContractor(String idOfContractor);
        List<Invoice> FindAllPerData(DateTime date);
        List<Invoice> FindAllPerProduct(String IDProduct);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Client;

namespace Domain.Model.Invoice
{
    public class Invoice
    {
        private String IdInvoice;
        private String Title;
        private DateTime DateOfCreate;
        private Domain.Model.Client.Client Contractor;
        private List<Item> ListOfProducts;
        public String Comments;

        public Invoice(String title, DateTime date, Domain.Model.Client.Client contractor, List<Item> list, String comm = "");
        public String GetId();
        public void ChengeTitle(String title);
        public void ChengeDate(DateTime date);
        public void ChengeContractor(Domain.Model.Client.Client contractor);
        public void AddProduct(Domain.Model.Product.Product product);
        public Item GetItem(String IdProduct);
    }
}

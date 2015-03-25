using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Product
{
    public class Product
    {
        private string IDProduct;
        public string NameOfProduct;
        public string Type;
        private Price PriceOfProduct;
        private string Comments;

        public Product(string name, string type, string comm)
        {
            this.IDProduct = SetId(name);
            this.NameOfProduct = name;
            if (type == "Usługa" || type == "Produkt")
                this.Type = type;
            else
                throw new ArgumentException("Zły argument,type.\n");
            this.Comments = comm;
        }
        public Price GetPrice();
        public void SetPrice(Price a);
        public void SetComments(string comm);
        public void ChengeName(string name);
        public string GetId();
        private string SetId(string name)
        {
            return "Kod:" + name;
        }
    }
}

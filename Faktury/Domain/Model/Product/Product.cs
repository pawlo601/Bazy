using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Product
{
    public class Product
    {
        private String IDProduct;
        public String NameOfProduct;
        public string Type;
        private Price PriceOfProduct;
        private String Comments;

        public Product(String name, String type, String comm="Wstawiłąem sobie tekst"){}
        public Price GetPrice();
        public void SetPrice(Price a);
        public void SetComments(String comm);
        public void ChengeName(String name);
        public String GetId();

    }
}

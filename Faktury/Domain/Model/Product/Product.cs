using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Product
{
    public enum TypProduktu { Przedmiot, Usługa};
    public class Product
    {
        public Guid IDProduct { get; private set; }
        public string NameOfProduct { get; set; }
        public TypProduktu Type { get; set; }
        public Price PriceOfProduct { get; set; }
        public string Comments { get; private set; }

        public Product(string name, TypProduktu type, Price price)
        {
            this.IDProduct = Guid.NewGuid();
            this.NameOfProduct = name;
            this.Type = type;
            this.PriceOfProduct = price;
            Comments = "";
        }
        public void SetComments(string comm)
        {
            if (comm.Length < 250)
                this.Comments = comm.Substring(0, 250);
            else
                this.Comments = comm;
        }
    }
}

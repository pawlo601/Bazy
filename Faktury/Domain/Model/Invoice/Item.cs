using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Invoice
{
    public class Item
    {
        private Domain.Model.Product.Product Thing;
        private int Volume;
        private Domain.Model.Product.Money Cost;
        public Item(Domain.Model.Product.Product product, int vol, Domain.Model.Product.Money money);
        public void ChangeVolume(int vol);
        public void ChangeCost(Domain.Model.Product.Money cost);
    }
}

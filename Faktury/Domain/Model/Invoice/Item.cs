using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Invoice
{
    public class Item
    {
        public Product.Product Thing { get; private set; }
        public int Volume { get; private set; }
        public Product.Money Cost { get; private set; }
        public Item(Product.Product product, int vol)
        {
            this.Thing = product;
            ChangeVolume(vol);
            Cost = new Product.Money(0.0f, Product.Waluta.PLN);
        }
        public void ChangeVolume(int vol)
        {
            if (vol < 0)
                throw new Exception("Zła ilość produktów.\n");
            else
                this.Volume = vol;
        }
        public void Count()
        {
            Cost = Thing.PriceOfProduct.GetGross();
            Cost.Value *= Volume;
        }
        public void Count(Client.Discount dis)
        {
            if (Thing.IDProduct == dis.IdProduct)
            {
                if (dis.Type == Client.Bonus.Netto)
                {
                    Cost = Thing.PriceOfProduct.NetPrice;
                    Cost.Value *= Volume;
                }
                if(dis.Type == Client.Bonus.Zniżka)
                {
                    Cost = Thing.PriceOfProduct.NetPrice;
                    Cost.Value *= Volume;
                    Cost.Value *= (float)(1.0f - dis.ValueOfBonus);
                }
            }
            else
                throw new Exception("Nie ta zniżka.\n");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Invoice
{
    public class Item
    {
        public  int IdProdukt { get; set; }
        public Product.Product Thing;
        public  int Volume { get;  set; }
        public float Value { get; set; }
        public Product.Waluta NameOfCurrency { get; set; }
        public Product.Money Cost;

        public Item()
        {
            Cost = new Product.Money();
            Thing = new Product.Product();
            Volume = 10;
            IdProdukt = Thing.IDProduct;
            Value = Cost.Value;
            NameOfCurrency = Cost.NameOfCurrency;
        }

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
            Value = Cost.Value;
            NameOfCurrency = Cost.NameOfCurrency;
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
                Value = Cost.Value;
                NameOfCurrency = Cost.NameOfCurrency;
            }
            else
                throw new Exception("Nie ta zniżka.\n");
        }
    }
}

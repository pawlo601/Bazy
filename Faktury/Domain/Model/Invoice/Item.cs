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
        private int _volume;
        public  int Volume 
        { 
            get
            {
                return _volume;
            }  
            set
            {
                ChangeVolume(value);
            }
        }
        public float Value { get; set; }
        public Product.Waluta NameOfCurrency { get; set; }

        public Product.Money Cost;
        public Product.Product Thing;

        public Item()
        {
            Random rand = new Random();
            Cost = new Product.Money();
            Thing = null;
            Volume = rand.Next(1,100);
            IdProdukt = -1;
            Value = Cost.Value;
            NameOfCurrency = Cost.NameOfCurrency;
        }
        public Item(Product.Product product, int vol)
        {
            this.Thing = product;
            ChangeVolume(vol);
            Cost = new Product.Money(0.0f, Product.Waluta.PLN);
            Value = Cost.Value;
            NameOfCurrency = Cost.NameOfCurrency;
            IdProdukt = Thing.IDProduct;
        }
        public void ChangeVolume(int vol)
        {
            if (vol < 0)
                throw new Exception("Zła ilość produktów.\n");
            else
                this._volume = vol;
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
        public override string ToString()
        {
            string nazwaProduktu = "";
            if (Thing != null)
                nazwaProduktu = Thing.NameOfProduct;
            string text = "Id produktu: " + IdProdukt.ToString() + "\n" +
                           "Nazwa produktu: " + nazwaProduktu + "\n" +
                           "Ilość: " + Volume.ToString() + "\n" +
                           "Wartość: " + Value.ToString() + NameOfCurrency.ToString() + "\n";
            return text;
        }
    }
}

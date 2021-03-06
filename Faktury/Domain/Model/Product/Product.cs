﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model.Product
{
    public enum TypProduktu { Przedmiot, Usługa};
    public class Product
    {
        public virtual int IDProduct { get; set; }
        public virtual string NameOfProduct { get; set; }
        public virtual TypProduktu Type { get; set; }
        public virtual Price PriceOfProduct { get; set; }

        private string _comments;
        public virtual string Comments 
        { 
            get 
            {
                return this._comments;
            }
            set 
            { 
                this.SetComments(value); 
            } 
        }
        public Product()
        {
            IDProduct = -1;
            NameOfProduct = "Nazwa Produktu";
            Random rand = new Random();
            NameOfProduct += rand.Next(1, 20000).ToString();
            switch(rand.Next(0,2))
            {
                case 0:
                    Type = TypProduktu.Przedmiot;
                    break;
                case 1:
                    Type = TypProduktu.Usługa;
                    break;
                default:
                    Type = TypProduktu.Usługa;
                    break;
            }
            PriceOfProduct = new Price();
            Comments = "Brak komentarza";
        }
        public Product(string name, TypProduktu type, Price price)
        {
            this.IDProduct = -1;
            this.NameOfProduct = name;
            this.Type = type;
            this.PriceOfProduct = price;
            Comments = "Brak komentarza";
        }
        public void SetComments(string comm)
        {
            if (comm.Length > 250)
                this._comments = comm.Substring(0, 250);
            else
                this._comments = comm;
        }
        public Waluta GetCurrency()
        {
            return PriceOfProduct.NetPrice.NameOfCurrency;
        }
        public void ChangeCurrency(Waluta a)
        {
            PriceOfProduct.ChangeCurrency(a);
        }
        public override string ToString()
        {
            string a = String.Format("Produkt: {0}{4}{4}Typ: {1}{4}{4}Cena:{4}{2}{4}{4}Komentarz:{4}{3}",
                                        NameOfProduct, Type, PriceOfProduct.ToString(), Comments, Environment.NewLine);
            return a;
        }
    }
}

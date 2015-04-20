using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iesi.Collections.Generic;
using Domain.Model.Client;
using Iesi.Collections;

namespace Domain.Model.Invoice
{
    public class Invoice
    {
        public string IdInvoice { get; set; }
        public string Title { get; set; }
        public DateTime DateOfCreate { get; set; }
        public int IdClient { get; set; }
        public Client.Client Contractor;
        public Iesi.Collections.Generic.ISet<Item> ListOfProducts { get; set; }
        public string Comments { get; set; }

        private bool CalcDis = false;

        public Invoice()
        {
            DateOfCreate=DateTime.Now;
            IdInvoice = "FAK/" + DateOfCreate.DayOfYear.ToString() + "/" +
                DateOfCreate.Hour.ToString() + "/" + DateOfCreate.Minute.ToString() +
                "/" + DateOfCreate.Second.ToString();
            Title = "Tytul";
            Contractor = new Client.Client();
            IdClient = Contractor.IdClient;
            ListOfProducts = new HashedSet<Item>();
            Comments = "Brak komentarza";
        }
        public Invoice(string title, Client.Client contractor)
        {
            DateOfCreate=DateTime.Now;
            IdInvoice = "FAK/" + DateOfCreate.DayOfYear.ToString() + "/" +
                DateOfCreate.Hour.ToString() + "/" + DateOfCreate.Minute.ToString() +
                "/" + DateOfCreate.Second.ToString();
            ChengeTitle(title);
            this.Contractor = contractor;
            ListOfProducts = new HashedSet<Item>();
            Comments = "Brak komentarza";
        }
        public void ChengeTitle(string title)
        {
            if (title.Length < 20)
                this.Title = title;
            else
                this.Title = title.Substring(0, 20);
        }
        public void ChengeDate(DateTime date)
        {
            DateOfCreate = date;
        }
        public void ChengeContractor(Client.Client contractor)
        {
            this.Contractor = contractor;
        }
        public void AddProduct(Product.Product product, int volume)
        {
            ListOfProducts.Add(new Item(product, volume));
        }
        public void AddItem(Item a)
        {
            ListOfProducts.Add(a);
        }
        public Item GetItem(int IdProduct)
        {
            foreach(Item a in ListOfProducts)
            {
                if (a.Thing.IDProduct == IdProduct)
                    return a;
            }
            return null;
        }
        public Item GetItem(string name)
        {
            foreach (Item a in ListOfProducts)
            {
                if (a.Thing.NameOfProduct == name)
                    return a;
            }
            return null;
        }
        public void CalculateDiscount()
        {
            foreach(Item a in ListOfProducts)
            {
                bool Flag=true;
                foreach(Client.Discount b in Contractor.ListOfDiscount)
                {
                    if (b.IdProduct == a.Thing.IDProduct)
                    {
                        a.Count(b);
                        Flag = false;
                    }
                }
                if (Flag)
                    a.Count();
            }
            CalcDis = true;
        }
        public List<Product.Money> Podsumowanie()
        {
            if (!CalcDis)
                CalculateDiscount();
            List<Product.Money> lista = new List<Product.Money>();
            foreach(Item a in ListOfProducts)
            {
                lista.Add(a.Cost);
            }
            return lista;
        }
        private void Dodaj(List<Product.Money> lista, Product.Money cost)
        {
            bool flag = true;
            foreach(Product.Money a in lista)
            {
                if(a.NameOfCurrency.Equals(cost.NameOfCurrency))
                {
                    a.Value += cost.Value;
                    flag = false;
                }
            }
            if (flag)
                lista.Add(cost);
        }
        public string ListOfProduct()
        {
            string text = "";
            foreach(Item a in ListOfProducts)
            {
                text += a.Thing.NameOfProduct;
            }
            return text;
        }
        public override string ToString()
        {
            string pr = "";
            foreach (Item a in ListOfProducts)
                pr += a.ToString();
            string text = String.Format("ID: {1}{0}Title: {2}{0}Date of create: {3}{0}Właściciel:{0}{0}{4}{0}List of Productds:{0}{0}{5}{0}Comments:{0}{6}",
                Environment.NewLine,IdInvoice,Title,DateOfCreate.ToString(),Contractor.ToString(),pr,Comments);
            return text;
        }
    }
}

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
        private string _title;
        public string Title 
        {
            get 
            {
                return _title;
            }
            set
            {
                ChengeTitle(value);
            }
        }
        public DateTime DateOfCreate { get; set; }
        public int IdClient { get; set; }
        public Iesi.Collections.Generic.ISet<Item> ListOfProducts { get; set; }
        private string _comments;
        public string Comments 
        {
            get
            {
                return _comments;
            }
            set
            {
                SetComments(value);
            }
        }

        private bool CalcDis = false;
        public Client.Client Contractor;

        public Invoice()
        {
            Random rand = new Random();
            DateOfCreate=DateTime.Now;
            IdInvoice = "FAK/" + DateOfCreate.DayOfYear.ToString() + "/" +
                DateOfCreate.Hour.ToString() + "/" + DateOfCreate.Minute.ToString() +
                "/" + DateOfCreate.Second.ToString();
            Title = "Tytul" + rand.Next(1, 100000).ToString();
            Contractor = null;
            IdClient = -1;
            ListOfProducts = new HashedSet<Item>();
            Comments = "Brak komentarza"+rand.Next(1,10000).ToString();
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
        public void SetComments(string comm)
        {
            if (comm.Length > 250)
                this._comments = comm.Substring(0, 250);
            else
                this._comments = comm;
        }
        public virtual void AddSomeItems()
        {
            Random rand = new Random();
            int j = rand.Next(1, 3);
            for (int i = 0; i < j; i++)
            {
                ListOfProducts.Add(new Item());
            }
        }
        public void ChengeTitle(string title)
        {
            if (title.Length < 30)
                this._title = title;
            else
                this._title = title.Substring(0, 30);
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
                text += a.Thing.NameOfProduct+"\n";
            }
            return text;
        }
        public override string ToString()
        {
            string stringCon="---";
            if (Contractor != null)
                stringCon = Contractor.ToString();
            string pr = "";
            foreach (Item a in ListOfProducts)
                pr += a.ToString()+"\n";
            string text = String.Format("ID: {1}{0}Title: {2}{0}Date of create: {3}{0}Właściciel:{0}{0}{4}{0}List of Productds:{0}{0}{5}{0}Comments:{0}{6}",
                Environment.NewLine, IdInvoice, Title, DateOfCreate.ToString(), stringCon, pr, Comments);
            return text;
        }
    }
}

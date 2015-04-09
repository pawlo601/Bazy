using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Client;

namespace Domain.Model.Invoice
{
    public class Invoice
    {
        public String IdInvoice { get; private set; }
        public String Title { get; private set; }
        public DateTime DateOfCreate { get; private set; }
        public Client.Client Contractor { get; private set; }
        public List<Item> ListOfProducts { get; private set; }
        public string Comments { get; private set; }
        private bool CalcDis = false;

        public Invoice(string title, Client.Client contractor)
        {
            DateOfCreate=DateTime.Now;
            IdInvoice = "FAK/" + DateOfCreate.DayOfYear.ToString() + "/" +
                DateOfCreate.Hour.ToString() + "/" + DateOfCreate.Minute.ToString() +
                "/" + DateOfCreate.Second.ToString();
            ChengeTitle(title);
            this.Contractor = contractor;
            ListOfProducts = new List<Item>();
            Comments = "";
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
        public Item GetItem(Guid IdProduct)
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
                Dodaj(lista, a.Cost);
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
    }
}

using Domain.Model.Invoice;
using Domain.Model.Invoice.Repositories;
using Domain.Model.Client;
using Domain.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class InvoiceIM : IInvoiceRepositories
    {
        private List<Invoice> invoices = new List<Invoice>();
        public InvoiceIM()
        {
            PersonalData per1 = new PersonalData("A", "B");
            Address ad1 = new Address("S1", "12", "Wrocław", "12-456", "Poland");
            Regon a1 = new Regon("2346789");
            NIP a2 = new NIP("123123");
            Client b=new Client(per1, ad1, a1, a2);
            Price c3 = new Price(10, Waluta.PLN, 19.0f);
            Product a3 = new Product("Pierwsza rzecz", TypProduktu.Usługa, c3);
            Money a4 = new Money(123,Waluta.PLN);
            Item e = new Item(a3,12);
            List<Item> d = new List<Item>();
            d.Add(e);
            Invoice a = new Invoice("Faktura", b);
            invoices.Add(a);
        }
        public void Insert(Invoice invoice)
        {
            invoices.Add(invoice);
        }
        public void Delete(string Id)
        {
            foreach (var a in invoices)
            {
                if (Id == a.IdInvoice)
                {
                    invoices.Remove(a);
                }
            }
        }
        public Invoice Find(string Id)
        {
            foreach (var a in invoices)
            {
                if (Id == a.IdInvoice)
                {
                    return a;
                }
            }
            return null;
        }
        public List<Invoice> FindAll()
        {
            return invoices;
        }
        public List<Invoice> FindAllPerContractor(Guid idOfContractor)
        {
            List<Invoice> lista = new List<Invoice>();
            foreach (var a in invoices)
            {
                if (idOfContractor == a.Contractor.IdClient)
                {
                    lista.Add(a);
                }
            }
            return lista;
        }
        public List<Invoice> FindAllPerContractor(PersonalData per)
        {
            List<Invoice> lista = new List<Invoice>();
            foreach (var a in invoices)
            {
                if (per == a.Contractor.Data)
                {
                    lista.Add(a);
                }
            }
            return lista;
        }
        public List<Invoice> FindAllPerData(DateTime date)
        {
            List<Invoice> lista = new List<Invoice>();
            foreach (var a in invoices)
            {
                if (date == a.DateOfCreate)
                {
                    lista.Add(a);
                }
            }
            return lista;
        }
        public List<Invoice> FindAllPerProduct(Guid IDProduct)
        {
            List<Invoice> lista = new List<Invoice>();
            foreach (var a in invoices)
            {
                if (a.GetItem(IDProduct)!=null)
                {
                    lista.Add(a);
                }
            }
            return lista;
        }
        public List<Invoice> FindAllPerProduct(string name)
        {
            List<Invoice> lista = new List<Invoice>();
            foreach (var a in invoices)
            {
                if (a.GetItem(name)!=null)
                {
                    lista.Add(a);
                }
            }
            return lista;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using NHibernate;
using NHibernate.Cfg;
using System.Reflection;
using Domain.Model.Product;
using Domain.Model.Invoice;
using Domain.Model.Client;
using Domain.Model.Invoice.Repositories;
using Iesi.Collections.Generic;
using Iesi.Collections;
using System.Collections;

/*
 *
    create table Invoice
(
	IdInvoice varchar(30) primary key,
	Title varchar(30),
	DateOfCreate datetime,
    IdClient int,
    Comments varchar(250)
)
go

create table ListOfProducts
(
	ID_Invoice varchar(30),
	IdProdukt int,
	Volume int,
	Value float,
	NameOfCurrency varchar(10)
)
go
 */
namespace Infrastructure.DataBase
{
    public class InvoiceDataBaseIM:IInvoiceRepositories
    {
        public void Insert(Invoice invoice)
        {
            using (ISession s = OpenSession())
            {
                using (ITransaction t = s.BeginTransaction())
                {
                    Invoice b = new Invoice();
                    Item c = new Item();
                    b.AddItem(c);
                    s.Save(b);
                    s.Flush();
                }
            }
        }
        public void Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public Invoice Find(string Id)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> FindAll()
        {
            throw new NotImplementedException();
        }

        public List<Invoice> FindAllPerContractor(int idOfContractor)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> FindAllPerContractor(PersonalData per)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> FindAllPerData(DateTime date)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> FindAllPerProduct(int IDProduct)
        {
            throw new NotImplementedException();
        }

        public List<Invoice> FindAllPerProduct(string name)
        {
            throw new NotImplementedException();
        }
        static ISession OpenSession()
        {
            return new Configuration().Configure().BuildSessionFactory().OpenSession();
        }
        /*public static void Main()
        {
            using (var s = OpenSession())
            {
                InvoiceDataBaseIM b = new InvoiceDataBaseIM();
                Invoice a = new Invoice();
                a.AddSomeItems();
                b.Insert(a);
                s.Save(a);
                s.Flush();
            }
           // Console.ReadKey();
        }*/
    }
}

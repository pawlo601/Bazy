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
using Domain.Model.Product.Repositories;
using Domain.Model.Client;
using Domain.Model.Client.Repositories;
using Domain.Model.Invoice;
using Domain.Model.Invoice.Repositories;

namespace Infrastructure.DataBase
{
    public class DataBase
    {
        public void AddProducts(int HowMany)
        {
            ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
            using (IStatelessSession statelessSession = sessionFactory.OpenStatelessSession())
            using (ITransaction transaction = statelessSession.BeginTransaction())
            {
                for(int i=0;i<HowMany;i++)
                {
                    statelessSession.Insert(new Product());
                }
                transaction.Commit();
            }
        }
        public void AddClients(int HowMany)
        {
            Client c;
            ClientDataBaseIM a = new ClientDataBaseIM();
            for (int i = 0; i < HowMany; i++)
            {
                  c = new Client();
                  c.AddSomeDiscounts();
                  a.Insert(c);
                  System.Threading.Thread.Sleep(50);
            }
        }
        public void AddCurrencies()
        {
            ISessionFactory sessionFactory = new Configuration().Configure().BuildSessionFactory();
            using (IStatelessSession statelessSession = sessionFactory.OpenStatelessSession())
            using (ITransaction transaction = statelessSession.BeginTransaction())
            {
                statelessSession.Insert(new Currency() { Name = Waluta.PLN, ExchangeInTheRelationToPLN = 1.0f});
                statelessSession.Insert(new Currency() { Name = Waluta.EUR, ExchangeInTheRelationToPLN = 4.00230457f });
                statelessSession.Insert(new Currency() { Name = Waluta.USD, ExchangeInTheRelationToPLN = 3.69914143f });
                transaction.Commit();
            }
        }
        public void AddInvoices(int HowMany)
        {
            Invoice[] b = new Invoice[HowMany];
            for (int j = 0; j < HowMany; j++)
            {
                b[j] = new Invoice();
                b[j].AddSomeItems();
                System.Threading.Thread.Sleep(50);
            }
            InvoiceDataBaseIM f = new InvoiceDataBaseIM();
            for (int i = 0; i < HowMany; i++)
            {
                f.Insert(b[i]);
            }
        }
        public static void Main()
        {
            DataBase a = new DataBase();
            a.AddCurrencies();
            a.AddProducts(100);
            a.AddInvoices(100);
            a.AddClients(100);
        }
    }
}

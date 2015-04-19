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
using Domain.Model.Client;
using Domain.Model.Client.Repositories;

namespace Infrastructure.DataBase
{
    public class ClientDataBaseIM : IClientRepositories
    {
        public void Insert(Client client)
        {
            using (ISession s = OpenSession())
            {
                using (ITransaction t = s.BeginTransaction())
                {
                    s.Save(client);

                    foreach (Discount a in client.ListOfDiscount)
                    {
                        a.IdClient = client.IdClient;
                        s.Save(a);
                    }
                    t.Commit();
                }
            }
        }
        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }
        public Client FindID(int Id)
        {
            throw new NotImplementedException();
        }
        public Client FindNIP(NIP nip)
        {
            throw new NotImplementedException();
        }
        public Client FindPD(PersonalData pd)
        {
            throw new NotImplementedException();
        }
        public Client FindREGON(Regon regon)
        {
            throw new NotImplementedException();
        }
        public List<Client> FindAll()
        {
            List<Client> result2 = new List<Client>();
            using (ISession s = OpenSession())
            {
                IQuery q = s.CreateQuery("from Client as j");
                IList<Client> result = q.List<Client>();
                foreach (Client a in result)
                {
                    result2.Add(a);
                }
                foreach(Client a in result2)
                {
                    List<Discount> result3 = new List<Discount>();
                    q = s.CreateQuery("FROM Discount D WHERE D.IdClient = :IdClient");
                    q.SetParameter("IdClient", a.IdClient);
                    IList<Discount> result4 = q.List<Discount>();
                    foreach (Discount b in result4)
                    {
                        result3.Add(b);
                    }
                    a.ListOfDiscount = result3;
                }
            }
            return result2;
        }
        public List<Discount> GetAllDiscount(int IdClient)
        {
            throw new NotImplementedException();
        }
        static ISession OpenSession()
        {
            return new Configuration().Configure().BuildSessionFactory().OpenSession();
        }
        public static void Main()
        {
            ClientDataBaseIM a = new ClientDataBaseIM();
            Client j1 = new Client();
            a.Insert(j1);
            List<Client> b = a.FindAll();
            Console.WriteLine("Znaleziono: {0}\n", b.Count);
            foreach (Client c in b)
                Console.WriteLine("{0}\n", c.ToString());

            Console.ReadKey();
        }
    }
}

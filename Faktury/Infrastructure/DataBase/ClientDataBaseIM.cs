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
                s.Save(client);
                s.Flush();
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
            throw new NotImplementedException();
        }
        public ISet<Discount> GetAllDiscount(int IdClient)
        {
            throw new NotImplementedException();
        }
        static ISession OpenSession()
        {
            return new Configuration().Configure().BuildSessionFactory().OpenSession();
        }
        public static void Main()
        {
            ClientDataBaseIM c = new ClientDataBaseIM();
            Client a = new Client();
            Discount b = new Discount();
            a.AddDiscount(b);
            c.Insert(a);
        }
    }
}

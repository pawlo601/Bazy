using System;
using Iesi.Collections.Generic;
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
            using (var session = OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var queryString = string.Format("delete {0} where IdClient = :id", typeof(Client));
                session.CreateQuery(queryString)
                       .SetParameter("id", Id)
                       .ExecuteUpdate();
                transaction.Commit();
            }
        }
        public Client FindID(int Id)
        {
            using (ISession s = OpenSession())
            {
                IQuery q = s.CreateQuery("FROM Client P WHERE P.IdClient = " + Id.ToString());
                System.Collections.Generic.IList<Client> result = q.List<Client>();
                if (result.Count == 0)
                    return null;
                else
                {
                    foreach (Client a in result)
                        return a;
                }
            }
            return null;
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
        public System.Collections.Generic.List<Client> FindAll()
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
    }
}

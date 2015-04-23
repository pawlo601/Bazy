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

namespace Infrastructure.DataBase
{
    public class ProductDataBaseIM:IProductRepositories
    {
        static ISession OpenSession()
        {
            return new Configuration().Configure().BuildSessionFactory().OpenSession();
        }
        public void Insert(Product product)
        {
            using (ISession s = OpenSession())
            {
                using (ITransaction t = s.BeginTransaction())
                {
                    s.Save(product);
                    t.Commit();
                }
            }
        }
        public void Insert(Currency curr)
        {
            using (ISession s = OpenSession())
            {
                using (ITransaction t = s.BeginTransaction())
                {
                    s.Save(curr);
                    t.Commit();
                }
            }
        }

        public void Delete(int Id)
        {
            using (var session = OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                var queryString = string.Format("delete {0} where IDProduct = :id", typeof(Product));
                session.CreateQuery(queryString)
                       .SetParameter("id", Id)
                       .ExecuteUpdate();
                transaction.Commit();
            }
        }

        public Product Find(int Id)
        {
            using (ISession s = OpenSession())
            {
                IQuery q = s.CreateQuery("FROM Product P WHERE P.IDProduct = "+Id.ToString());
                IList<Product> result = q.List<Product>();
                if (result.Count == 0)
                    return null;
                else
                {
                    foreach (Product a in result)
                        return a;
                }
            }
            return null;
        }

        public void Delete(string name)
        {
            throw new NotImplementedException();
        }

        public Product Find(string name)
        {
            throw new NotImplementedException();
        }

        public List<Currency> FindAllCurrency()
        {
            List<Currency> result2 = new List<Currency>();
            using (ISession s = OpenSession())
            {
                IQuery q = s.CreateQuery("from Currency as j order by j.Name");
                IList<Currency> result = q.List<Currency>();
                foreach(Currency a in result)
                {
                    result2.Add(a);
                }
            }
            return result2;
        }

        public List<Product> FindAll()
        {
            List<Product> result2 = new List<Product>();
            using (ISession s = OpenSession())
            {
                IQuery q = s.CreateQuery("from Product as j order by j.NameOfProduct");
                IList<Product> result = q.List<Product>();
                foreach (Product a in result)
                {
                    result2.Add(a);
                }
            }
            return result2;
        }
    }
}

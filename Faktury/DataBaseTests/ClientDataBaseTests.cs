using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Model.Client;
using Domain.Model.Client.Repositories;

namespace DataBaseTests
{
    [TestClass]
    public class ClientDataBaseTests
    {
        private ClientDataBaseIM baza = new ClientDataBaseIM();
        [TestMethod]
        public void FindIDTest()
        {
            Assert.IsNotNull(baza.FindID(284));
        }
        [TestMethod]
        public void InsertTest()
        {
            Client a = new Client();
            a.AddSomeDiscounts();
            baza.Insert(a);
            Client b = baza.FindID(a.IdClient);
            Assert.IsNotNull(b);
        }
        [TestMethod]
        public void DeleteTest()
        {
            Client a = new Client();
            baza.Insert(a);
            baza.Delete(a.IdClient);
            Assert.IsNull(baza.FindID(a.IdClient));
        }
    }
}

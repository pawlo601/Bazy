using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Model.Product;
using Domain.Model.Product.Repositories;

namespace DataBaseTests
{
    [TestClass]
    public class ProductDataBaseTests
    {
        private ProductDataBaseIM baza = new ProductDataBaseIM();
        [TestMethod]
        public void FindTest()
        {
            Assert.IsNotNull(baza.Find(252));
        }
        [TestMethod]
        public void InsertTest()
        {
            Product a = new Product();
            baza.Insert(a);
            Product b = baza.Find(a.IDProduct);
            Assert.IsNotNull(b);
        }
        [TestMethod]
        public void DeleteTest()
        {
            Product a = new Product();
            baza.Insert(a);
            baza.Delete(a.IDProduct);
            Product b = baza.Find(a.IDProduct);
            Assert.IsNull(b);
        }
    }
}

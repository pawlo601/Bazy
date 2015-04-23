using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DataBase;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Model.Invoice;
using Domain.Model.Invoice.Repositories;

namespace DataBaseTests
{
    [TestClass]
    public class InvoiceDataBaseTests
    {
        private InvoiceDataBaseIM baza = new InvoiceDataBaseIM();
        [TestMethod]
        public void FindTest()
        {
            Assert.IsNotNull(baza.Find("FAK/113/20/44/140"));
        }
        [TestMethod]
        public void InsertTest()
        {
            Invoice a = new Invoice();
            baza.Insert(a);
            Invoice b = baza.Find(a.IdInvoice);
            Assert.IsNotNull(b);
        }
        [TestMethod]
        public void DeleteTest()
        {
            Invoice a = new Invoice();
            baza.Insert(a);
            baza.Delete(a.IdInvoice);
            Invoice b = baza.Find(a.IdInvoice);
            Assert.IsNull(b);
        }
    }
}

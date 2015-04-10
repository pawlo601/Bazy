using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finance.ObjectMothers;
using Domain.Model.Invoice;

namespace Finance.Domain.UniTest
{
    [TestClass]
    public class InvoiceTest
    {
        [TestMethod]
        public void Item()
        {
            Item a = InvoiceObjectMothers.CreateItems123();
            Assert.IsTrue(a.Volume == 123);
            try
            {
                a.ChangeVolume(-12);
                Assert.IsTrue(false);
            }
            catch(Exception e)
            {
                Assert.IsTrue(e.Message.Equals("Zła ilość produktów.\n"));
            }
            a.Count();
            Assert.IsNotNull(a.Cost);
        }
        [TestMethod]
        public void Invoice()
        {
            Invoice a = InvoiceObjectMothers.CreateInvoicePrivWithDis2PrzedUsl();

            DateTime b = DateTime.Now;
            a.ChengeDate(b);
            Assert.IsTrue(a.DateOfCreate.Equals(b));

            string tit = "tyty";
            a.ChengeTitle(tit);
            Assert.IsTrue(a.Title.Equals(tit));
        }
    }
}

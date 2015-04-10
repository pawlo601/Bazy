using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finance.ObjectMothers;
using Domain.Model.Product;

namespace Finance.Domain.UniTest
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void PriceThrowException()
        {
            try
            {
                var a = new Price(12.05f, Waluta.PLN, 1.06f);
                Assert.IsTrue(false);
            }
            catch(Exception e)
            {
                Assert.IsTrue(e.Message.Equals("Zła wartośc VAT, ustawiono na 0%"));
            }
        }
        [TestMethod]
        public void MoneyThrowException()
        {
            try
            {
                var a = new Money(-12.05f, Waluta.PLN);
                Assert.IsTrue(false);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Equals("Zła wartość.\n"));
            }
        }

    }
}

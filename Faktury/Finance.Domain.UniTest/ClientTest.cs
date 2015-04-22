using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Finance.ObjectMothers;
using Domain.Model.Client;
using Iesi.Collections.Generic;

namespace Finance.Domain.UniTest
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void ChangeTypOfBonus()
        {
            Discount dis = ClientObjectMothers.CreateDiscountNetto();
            bool pomoc=false;
            if (dis.Type.Equals( Bonus.Netto))
                pomoc = true;
            Assert.IsTrue(pomoc);
            pomoc = false;
            dis.ChangeType(Bonus.Zniżka, 0.1f);
            if (dis.Type.Equals( Bonus.Zniżka))
                pomoc = true;
            Assert.IsTrue(pomoc);
        }
        [TestMethod]
        public void ChangeBonusThrowException()
        {
            Discount dis = ClientObjectMothers.CreateDiscountZnizka();
            try
            {
                dis.ChangeBonus(-1.0f);
                Assert.IsTrue(false);
            }
            catch(Exception e)
            {
                Assert.IsTrue(e.Message.Equals("Niewłaściwy bonus.\n"));
            }
        }
        [TestMethod]
        public void NipThrowExceptionToLongNip()
        {
            try
            {
                NIP np = new NIP("1123456789012");
                Assert.IsTrue(false);
            }
            catch(Exception e )
            {
                Assert.IsTrue(e.Message.Equals("Błąd w NIP-ie. Zła długość.\n"));
            }
        }
        [TestMethod]
        public void NipThrowExceptionWrongNumber()
        {
            try
            {
                NIP np = new NIP("123456789A");
                Assert.IsTrue(false);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Equals("Błąd w NIP-ie.Niewłaściwe znaki.\n"));
            }
        }
        [TestMethod]
        public void NipThrowExceptionWrongNIP()
        {
            try
            {
                NIP np = new NIP("1234567890");
                Assert.IsTrue(false);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.Message.Equals("Błąd w NIP-ie. Niepoprawne znaczenie.\n"));
            }
        }
        [TestMethod]
        public void Client()
        {
            Client a = ClientObjectMothers.CreateClientPrivateWithoutDiscount();
            Assert.IsTrue(a.ListOfDiscount.Count==0);

            a.AddDiscount(ClientObjectMothers.CreateDiscountNetto());
            Assert.IsTrue(a.ListOfDiscount.Count == 1);
            Assert.IsTrue(a.Data.Type.Equals(Typ.KlientPrywatny));

            a.ChangeTypeToCompany(ClientObjectMothers.CreateRegon(), ClientObjectMothers.CreateNip());
            Assert.IsTrue(a.Data.Type.Equals(Typ.Firma));
        }
    }
}

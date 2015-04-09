using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Model.Invoice;

namespace Finance.ObjectMothers
{
    public class InvoiceObjectMothers
    {
        public static Invoice CreateInvoicePrivNoDis1PrzedPLN()
        {
            Invoice a = new Invoice("Faktura zapłaty", ClientObjectMothers.CreateClientPrivateWithoutDiscount());
            a.AddProduct(ProductObjectMothers.CreateProductPrzedmiotPLN(),1);
            return a;
        }
        public static Invoice CreateInvoicePrivWithDis2PrzedUsl()
        {
            Invoice a = new Invoice("Faktura zapłaty2", ClientObjectMothers.CreateClientPrivateWithDiscountNetto());
            a.AddProduct(ProductObjectMothers.CreateProductPrzedmiotPLN(), 1);
            a.AddProduct(ProductObjectMothers.CreateProductUslugaPLN(), 2);
            return a;
        }
        public static Invoice CreateInvoiceCompWithDis2Przed()
        {
            Invoice a = new Invoice("Faktura zapłaty", ClientObjectMothers.CreateClientPrivateWithoutDiscount());
            a.AddProduct(ProductObjectMothers.CreateProductPrzedmiotUSD(), 1);
            a.AddProduct(ProductObjectMothers.CreateProductPrzedmiotPLN(), 2);
            return a;
        }
        public static Invoice CreateInvoiceCompWithDis1UslPLN()
        {
            Invoice a = new Invoice("Faktura zapłaty2", ClientObjectMothers.CreateClientPrivateWithDiscountNetto());
            a.AddProduct(ProductObjectMothers.CreateProductUslugaPLN(), 2);
            return a;
        }
    }
}

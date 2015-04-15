using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Domain.Model.Invoice.Repositories;
using Application;
using Moq;
using Finance.ObjectMothers;

namespace Finance.Application.UniTests
{
    [TestClass]
    public class InvoiceServiceTests
    {
        [TestMethod]
        public void InvoiceDocCreateTest()
        {
            Mock<IInvoiceRepositories> repositoryMock = new Mock<IInvoiceRepositories>();
            IInvoiceServices bs = new InvoiceService(repositoryMock.Object);
            repositoryMock.Setup(m => m.Find(It.IsAny<string>())).Returns(InvoiceObjectMothers.CreateInvoiceCompWithDis1UslPLN());

            // Act
            bs.CreateInvoice("jakies id");

            // Assert
            repositoryMock.Verify(k => k.Find(It.IsAny<string>()), Times.Once());
        }
    }
}

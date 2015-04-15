using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Domain.Model.Product.Repositories;
using Application;
using Moq;
using Finance.ObjectMothers;


namespace Finance.Application.UniTests
{
    [TestClass]
    public class ProductServiceTests
    {
        [TestMethod]
        public void CeateDocProductTest()
        {
            Mock<IProductRepositories> repositoryMock = new Mock<IProductRepositories>();
            IProductService bs = new ProductService(repositoryMock.Object);
            repositoryMock.Setup(m=>m.Find(It.IsAny<string>())).Returns(ProductObjectMothers.CreateProductPrzedmiotPLN());

            // Act
            bs.CreateDoc("nazwa");

            // Assert
            repositoryMock.Verify(k => k.Find(It.IsAny<string>()), Times.Once());
        }
    }
}

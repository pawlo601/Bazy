using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Domain.Model.Client.Repositories;
using Application;
using Moq;

namespace Finance.Application.UniTests
{
    [TestClass]
    public class ClientServiceTests
    {
        [TestMethod]
        public void ClientDocCreateTest()
        {
            // Arrange
            Mock<IClientRepositories> repositoryMock = new Mock<IClientRepositories>();
            IClientService bs = new ClientService(repositoryMock.Object);

            // Act
            bs.GetAll();

            // Assert
            repositoryMock.Verify(k => k.FindAll(), Times.Once());
        }
    }
}

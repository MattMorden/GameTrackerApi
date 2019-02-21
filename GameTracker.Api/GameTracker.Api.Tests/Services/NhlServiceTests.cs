using GameTracker.Api.Data.IRepositories;
using GameTracker.Api.Services.IServices;
using GameTracker.Api.Services.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTracker.Api.Tests.Services
{
    [TestClass]
    public class NhlServiceTests
    {
        private INhlService _nhlService;
        private Mock<INhlRepository> _nhlRepository;

        [TestInitialize]
        public void Init()
        {
            _nhlRepository = new Mock<INhlRepository>();
            _nhlService = new NhlService(_nhlRepository.Object);
        }

        [TestMethod]
        public void NhlService_GetNhlTeamsAsync_CallsRepo()
        {
            // Arrange
            _nhlRepository.Setup(r => r.GetNhlTeamsAsync()).ReturnsAsync(new List<DataContracts.NHLTeamContract>());

            // Act
            var result = _nhlService.GetNhlTeamsAsync();

            // Assert
            _nhlRepository.Verify(s => s.GetNhlTeamsAsync(), Times.Once());
        }

        [TestMethod]
        public void NhlService_GetNhlGamesAsync_CallsRepo()
        {
            // Arrange
            _nhlRepository.Setup(r => r.GetNhlGamesAsync()).ReturnsAsync(new List<DataContracts.NHLGameContract>());

            // Act
            var result = _nhlService.GetNhlGamesAsync();

            // Assert
            _nhlRepository.Verify(r => r.GetNhlGamesAsync(), Times.Once);
        }

        [TestMethod]
        public void SaveNewNhlGameAsync_CallsRepo()
        {
            // Arrange
            _nhlRepository.Setup(r => r.SaveNewNhlGameAsync(It.IsAny<DataContracts.NHLGameContract>())).ReturnsAsync(1);

            // Act
            _nhlService.SaveNewNhlGameAsync(It.IsAny<DataContracts.NHLGameContract>());

            // Assert
            _nhlRepository.Verify(r => r.SaveNewNhlGameAsync(It.IsAny<DataContracts.NHLGameContract>()), Times.Once);
        }

        //[TestMethod]
        //public void SaveNewNhlGameAsync_InvalidContract_DoesntSave()
        //{
        //    // Arrange

        //    // Act

        //    // Assert
        //}

    }
}

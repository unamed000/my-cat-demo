using System;
using System.Threading.Tasks;
using Moq;
using MyCats.Models.Cat;
using MyCats.UseCases;
using MyCats.ViewModels;
using MyOrg.Forms.Core.Navigation;
using NUnit.Framework;

namespace MyCats.UnitTests.ViewModels
{
    /// <summary>
    /// TODO: We should do the same for all models
    /// </summary>
    public class CatDetailsViewModelTest : AbstractTest<CatDetailsViewModel>
    {
        private Mock<IGetBreedByIdUseCase> _mockIGetBreedByIdUseCase;
        private Mock<INavigationService> _mockINavigationService;

        protected override CatDetailsViewModel GetImp()
        {
            _mockIGetBreedByIdUseCase = new Mock<IGetBreedByIdUseCase>();
            _mockINavigationService = new Mock<INavigationService>();
            return new CatDetailsViewModel(_mockIGetBreedByIdUseCase.Object, _mockINavigationService.Object);
        }

        [Test]
        public async Task ReloadDataSuccessfully_Test()
        {
            // Arrange
            var catData = new CatBreedDetailsItem()
            {
                Description = "Description bla bla",
                Name = "Name bla bla"
            };

            _mockIGetBreedByIdUseCase.Setup(x => x.Execute(It.IsAny<IGetBreedByIdUseCase.Param>()))
                .ReturnsAsync(catData);

            // Act
            await Imp.LoadData();

            Assert.False(Imp.IsBusy);
            Assert.False(Imp.LoadingError);
            Assert.AreSame(catData, Imp.Cat);
        }
        
        [Test]
        public async Task ReloadDataFailed_Test()
        {
            // Arrange
            _mockIGetBreedByIdUseCase.Setup(x => x.Execute(It.IsAny<IGetBreedByIdUseCase.Param>()))
                .ThrowsAsync(new Exception());

            // Act
            await Imp.LoadData();

            Assert.False(Imp.IsBusy);
            Assert.True(Imp.LoadingError);
        }
    }
}
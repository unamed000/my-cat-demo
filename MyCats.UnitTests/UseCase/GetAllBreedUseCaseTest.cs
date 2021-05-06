using System.Threading.Tasks;
using Moq;
using MyCats.UseCases;
using MyOrg.Api.Cats.Contract;
using NUnit.Framework;

namespace MyCats.UnitTests.UseCase
{
    /// <summary>
    /// TODO: We should do the same for GetBreedById, this is an example how we should make a test for use case.
    /// </summary>
    public class GetAllBreedUseCaseTest : AbstractTest<GetAllBreedUseCase>
    {
        private readonly Mock<ICatsClient> _mockICatsClient = new Mock<ICatsClient>();
        protected override GetAllBreedUseCase GetImp()
        {
            return new GetAllBreedUseCase(
                _mockICatsClient.Object);
        }
        
        [Test]
        public async Task TransformData_Test()
        {
            // Arrange
            var mockDataSet = new CatBreedDTO[]
            {
                new CatBreedDTO()
                {
                    id = "cat-id-1",
                    name = "name-1",
                    Image = new CatBreedImageDTO()
                    {
                        url = "url-1"
                    }
                },
                new CatBreedDTO()
                {
                    id = "cat-id-2",
                    name = "name-2"
                },
            };
            _mockICatsClient.Setup(x => x.GetCatBreeds())
                .ReturnsAsync(mockDataSet);
            
            // Act
            var result = await Imp.Execute(null);
            
            // Assert
            Assert.AreEqual(mockDataSet.Length, result.Length);

            for (int i = 0; i < mockDataSet.Length; i++)
            {
                var mockItem = mockDataSet[i];
                var apiItem = result[i];
                
                Assert.AreEqual(mockItem.id, apiItem.Id);
                Assert.AreEqual(mockItem.name, apiItem.Name);
                Assert.AreEqual(mockItem.Image?.url, apiItem.ImageUrl);
            }
        }

    }
}
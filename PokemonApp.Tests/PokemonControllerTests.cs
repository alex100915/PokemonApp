using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using PokemonApp.API.Controllers;
using PokemonApp.Application.Pokemons;
using PokemonApp.Domain.Entities;

namespace PokemonApp.Tests.Controllers
{
    [TestFixture]
    public class PokemonControllerTests
    {
        private Mock<IMediator> _mediatorMock;
        private PokemonController _controller;

        [SetUp]
        public void SetUp()
        {
            _mediatorMock = new Mock<IMediator>();
            _controller = new PokemonController(_mediatorMock.Object);
        }

        [Test]
        public async Task GetPokemons_ReturnsOkResult_WithPokemonDtos()
        {
            // Arrange
            var expectedResult = new List<PokemonDto>() { new PokemonDto { Number = 1, Name = "Pikachu" } };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPokemonListQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedResult);

            // Act
            var result = await _controller.GetPokemons();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.That(okResult.Value, Is.EqualTo(expectedResult));
        }

        [Test]
        public async Task GetPokemonById_ReturnsNotFound_WhenPokemonIsNull()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPokemonByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync((Pokemon)null);

            // Act
            var result = await _controller.GetPokemonById(1);

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task GetPokemonById_ReturnsOkResult_WithPokemon()
        {
            // Arrange
            var expectedPokemon = new Pokemon { Number = 1, Name = "Pikachu" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPokemonByIdQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedPokemon);

            // Act
            var result = await _controller.GetPokemonById(1);

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.That(okResult.Value, Is.EqualTo(expectedPokemon));
        }

        [Test]
        public async Task GetPokemonByName_ReturnsNotFound_WhenPokemonIsNull()
        {
            // Arrange
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPokemonByNameQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync((Pokemon)null);

            // Act
            var result = await _controller.GetPokemonByName("Pikachu");

            // Assert
            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task GetPokemonByName_ReturnsOkResult_WithPokemon()
        {
            // Arrange
            var expectedPokemon = new Pokemon { Number = 1, Name = "Pikachu" };
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPokemonByNameQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedPokemon);

            // Act
            var result = await _controller.GetPokemonByName("Pikachu");

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.That(okResult.Value, Is.EqualTo(expectedPokemon));
        }

        [Test]
        public async Task GetPokemonSummary_ReturnsOkResult_WithSummary()
        {
            // Arrange
            var expectedSummary = new PokemonSummaryData()
            {
                TotalSpecies = 100,
                GenerationCounts = new Dictionary<string, int>
                {
                    { "Generation 1", 10 }
                },
                TypeCounts = new Dictionary<string, int>
                {
                    { "Generation 2", 11 }
                }
            };
            
            _mediatorMock.Setup(m => m.Send(It.IsAny<GetPokemonSummaryQuery>(), It.IsAny<CancellationToken>()))
                         .ReturnsAsync(expectedSummary);

            // Act
            var result = await _controller.GetPokemonSummary();

            // Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.IsNotNull(okResult);
            Assert.That(okResult.Value, Is.EqualTo(expectedSummary));
        }
    }
}

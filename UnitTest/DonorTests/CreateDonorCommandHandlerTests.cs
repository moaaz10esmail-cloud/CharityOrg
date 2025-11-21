using Application.Features.Donors.Commands;
using Application.Features.Donors.Handlers;
using Application.Interfaces;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTest.DonorTests
{
    public class CreateDonorCommandHandlerTests
    {
        private readonly Mock<IDonorRepository> _mockRepo;
        private readonly CreateDonorCommandHandler _handler;

        public CreateDonorCommandHandlerTests()
        {
            _mockRepo = new Mock<IDonorRepository>();
            _handler = new CreateDonorCommandHandler(_mockRepo.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateDonor_WhenValidRequest()
        {
            // Arrange
            var command = new CreateDonorCommand
            {
                FullName = "Test Donor",
                Email = "test@donor.com",
                PhoneNumber = "123456789",
                Country = "Sudan",
                Address = "Khartoum"
            };

            _mockRepo.Setup(r => r.AddAsync(It.IsAny<Donor>()))
                     .ReturnsAsync((Donor d) => d);

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Donor", result.FullName);
            _mockRepo.Verify(r => r.AddAsync(It.IsAny<Donor>()), Times.Once);
        }
    }
}
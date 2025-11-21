using Application.Features.Donations.Commands;
using Application.Features.Donations.Handlers;
using Application.Interfaces;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.DonationTests
{
    public class CreateDonationCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldCreateDonation_WhenValidRequest()
        {
            // Arrange
            var mockRepo = new Mock<IDonationRepository>();
            var handler = new CreateDonationCommandHandler(mockRepo.Object);

            var command = new CreateDonationCommand
            {
                DonorId = Guid.NewGuid(),
                BeneficiaryId = Guid.NewGuid(),
                Amount = 100,
                Currency = "USD",
                DonationType = "Cash",
                Notes = "Test donation"
            };

            mockRepo.Setup(r => r.AddAsync(It.IsAny<Donation>()))
                    .ReturnsAsync((Donation d) => d);

            // Act
            var result = await handler.Handle(command, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(100, result.Amount);
            mockRepo.Verify(r => r.AddAsync(It.IsAny<Donation>()), Times.Once);
        }
    }
}

using Application.Features.Beneficiaries.Commands;
using Application.Features.Beneficiaries.Handlers;
using Application.Interfaces;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.BeneficiaryTests
{
    public class CreateBeneficiaryCommandHandlerTests
    {
        private readonly Mock<IBeneficiaryRepository> _mockRepo;
        private readonly CreateBeneficiaryCommandHandler _handler;

        public CreateBeneficiaryCommandHandlerTests()
        {
            _mockRepo = new Mock<IBeneficiaryRepository>();
            _handler = new CreateBeneficiaryCommandHandler(_mockRepo.Object);
        }

        [Fact]
        public async Task Handle_ShouldCreateBeneficiary_WhenValidRequest()
        {
            // Arrange
            var command = new CreateBeneficiaryCommand
            {
                FullName = "Ali Hassan",
                NationalId = "123456789",
                PhoneNumber = "0912345678",
                Country = "Sudan",
                Address = "Khartoum",
                Notes = "Needs monthly support"
            };

            _mockRepo.Setup(r => r.AddAsync(It.IsAny<Beneficiary>()))
                     .ReturnsAsync((Beneficiary b) => b);

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Ali Hassan", result.FullName);
            _mockRepo.Verify(r => r.AddAsync(It.IsAny<Beneficiary>()), Times.Once);
        }
    }
}

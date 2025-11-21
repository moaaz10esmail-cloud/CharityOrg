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
    public class UpdateBeneficiaryCommandHandlerTests
    {
        private readonly Mock<IBeneficiaryRepository> _mockRepo;
        private readonly UpdateBeneficiaryCommandHandler _handler;

        public UpdateBeneficiaryCommandHandlerTests()
        {
            _mockRepo = new Mock<IBeneficiaryRepository>();
            _handler = new UpdateBeneficiaryCommandHandler(_mockRepo.Object);
        }

        [Fact]
        public async Task Handle_ShouldUpdateBeneficiary_WhenExists()
        {
            // Arrange
            var existing = new Beneficiary { Id = Guid.NewGuid(), FullName = "Old Name" };
            var command = new UpdateBeneficiaryCommand
            {
                Id = existing.Id,
                FullName = "New Name",
                Country = "UAE",
                IsActive = true
            };

            _mockRepo.Setup(r => r.GetByIdAsync(existing.Id)).ReturnsAsync(existing);
            _mockRepo.Setup(r => r.UpdateAsync(existing)).Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            Assert.True(result);
            Assert.Equal("New Name", existing.FullName);
            _mockRepo.Verify(r => r.UpdateAsync(It.IsAny<Beneficiary>()), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldReturnFalse_WhenNotExists()
        {
            // Arrange
            var command = new UpdateBeneficiaryCommand { Id = Guid.NewGuid(), FullName = "Test" };

            _mockRepo.Setup(r => r.GetByIdAsync(command.Id)).ReturnsAsync((Beneficiary)null);

            // Act
            var result = await _handler.Handle(command, default);

            // Assert
            Assert.False(result);
        }
    }
}
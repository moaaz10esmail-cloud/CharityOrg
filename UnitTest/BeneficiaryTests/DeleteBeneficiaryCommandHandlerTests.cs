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
    public class DeleteBeneficiaryCommandHandlerTests
    {
        private readonly Mock<IBeneficiaryRepository> _mockRepo;
        private readonly DeleteBeneficiaryCommandHandler _handler;

        public DeleteBeneficiaryCommandHandlerTests()
        {
            _mockRepo = new Mock<IBeneficiaryRepository>();
            _handler = new DeleteBeneficiaryCommandHandler(_mockRepo.Object);
        }

        [Fact]
        public async Task Handle_ShouldDeleteBeneficiary_WhenExists()
        {
            // Arrange
            var id = Guid.NewGuid();
            var existing = new Beneficiary { Id = id, FullName = "Delete Me" };

            _mockRepo.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(existing);
            _mockRepo.Setup(r => r.DeleteAsync(id)).Returns(Task.CompletedTask);

            // Act
            var result = await _handler.Handle(new DeleteBeneficiaryCommand { Id = id }, default);

            // Assert
            Assert.True(result);
            _mockRepo.Verify(r => r.DeleteAsync(id), Times.Once);
        }

        [Fact]
        public async Task Handle_ShouldReturnFalse_WhenNotExists()
        {
            // Arrange
            var id = Guid.NewGuid();
            _mockRepo.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((Beneficiary)null);

            // Act
            var result = await _handler.Handle(new DeleteBeneficiaryCommand { Id = id }, default);

            // Assert
            Assert.False(result);
        }
    }
}
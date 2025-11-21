using Application.Features.Beneficiaries.Handlers;
using Application.Features.Beneficiaries.Queries;
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
    public class GetBeneficiariesListQueryHandlerTests
    {
        private readonly Mock<IBeneficiaryRepository> _mockRepo;
        private readonly GetBeneficiariesListQueryHandler _handler;

        public GetBeneficiariesListQueryHandlerTests()
        {
            _mockRepo = new Mock<IBeneficiaryRepository>();
            _handler = new GetBeneficiariesListQueryHandler(_mockRepo.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnBeneficiariesList()
        {
            // Arrange
            var beneficiaries = new List<Beneficiary>
            {
                new Beneficiary { FullName = "Ahmed Ali", Country = "Sudan" },
                new Beneficiary { FullName = "Mohamed Hassan", Country = "Qatar" }
            };

            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(beneficiaries);

            // Act
            var result = await _handler.Handle(new GetBeneficiariesListQuery(), default);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, b => b.FullName == "Ahmed Ali");
        }
    }
}

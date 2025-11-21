using Application.Features.Donors.Handlers;
using Application.Features.Donors.Queries;
using Application.Interfaces;
using Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.DonorTests
{
    public class GetDonorsListQueryHandlerTests
    {
        private readonly Mock<IDonorRepository> _mockRepo;
        private readonly GetDonorsListQueryHandler _handler;

        public GetDonorsListQueryHandlerTests()
        {
            _mockRepo = new Mock<IDonorRepository>();
            _handler = new GetDonorsListQueryHandler(_mockRepo.Object);
        }

        [Fact]
        public async Task Handle_ShouldReturnDonorsList()
        {
            // Arrange
            var donors = new List<Donor>
            {
                new Donor { FullName = "Donor 1", Country = "Sudan" },
                new Donor { FullName = "Donor 2", Country = "UAE" }
            };

            _mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(donors);

            // Act
            var result = await _handler.Handle(new GetDonorsListQuery(), default);

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Contains(result, d => d.FullName == "Donor 1");
        }
    }

}

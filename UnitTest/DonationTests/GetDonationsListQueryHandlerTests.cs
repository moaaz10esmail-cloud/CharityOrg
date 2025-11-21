using Application.Features.Donations.Queries;
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
    public class GetDonationsListQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnAllDonations()
        {
            var mockRepo = new Mock<IDonationRepository>();
            var handler = new GetDonationsListQueryHandler(mockRepo.Object);

            mockRepo.Setup(r => r.GetAllAsync())
                    .ReturnsAsync(new List<Donation> { new Donation(), new Donation() });

            var result = await handler.Handle(new GetDonationsListQuery(), default);

            Assert.Equal(2, result.Count);
        }
    }
}
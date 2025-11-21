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
    public class GetDonationsByDonorQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnDonations_WhenDonorHasDonations()
        {
            var mockRepo = new Mock<IDonationRepository>();
            var handler = new GetDonationsByDonorQueryHandler(mockRepo.Object);

            var donorId = Guid.NewGuid();
            mockRepo.Setup(r => r.GetByDonorIdAsync(donorId))
                    .ReturnsAsync(new List<Donation> { new Donation { DonorId = donorId } });

            var result = await handler.Handle(new GetDonationsByDonorQuery { DonorId = donorId }, default);

            Assert.Single(result);
            Assert.Equal(donorId, result[0].DonorId);
        }
    }
}
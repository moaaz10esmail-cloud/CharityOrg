using Application.Features.Donations.Handlers;
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
    public class GetDonationByIdQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnDonation_WhenExists()
        {
            var mockRepo = new Mock<IDonationRepository>();
            var handler = new GetDonationByIdQueryHandler(mockRepo.Object);

            var id = Guid.NewGuid();
            mockRepo.Setup(r => r.GetByIdAsync(id)).ReturnsAsync(new Donation { Id = id });

            var result = await handler.Handle(new GetDonationByIdQuery { Id = id }, default);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public async Task Handle_ShouldReturnNull_WhenNotExists()
        {
            var mockRepo = new Mock<IDonationRepository>();
            var handler = new GetDonationByIdQueryHandler(mockRepo.Object);

            var id = Guid.NewGuid();
            mockRepo.Setup(r => r.GetByIdAsync(id)).ReturnsAsync((Donation)null);

            var result = await handler.Handle(new GetDonationByIdQuery { Id = id }, default);

            Assert.Null(result);
        }
    }
}

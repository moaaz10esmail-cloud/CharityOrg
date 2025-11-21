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
    public class GetDonationsByBeneficiaryQueryHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnDonations_WhenBeneficiaryHasDonations()
        {
            var mockRepo = new Mock<IDonationRepository>();
            var handler = new GetDonationsByBeneficiaryQueryHandler(mockRepo.Object);

            var beneficiaryId = Guid.NewGuid();
            mockRepo.Setup(r => r.GetByBeneficiaryIdAsync(beneficiaryId))
                    .ReturnsAsync(new List<Donation> { new Donation { BeneficiaryId = beneficiaryId } });

            var result = await handler.Handle(new GetDonationsByBeneficiaryQuery { BeneficiaryId = beneficiaryId }, default);

            Assert.Single(result);
            Assert.Equal(beneficiaryId, result[0].BeneficiaryId);
        }
    }
}

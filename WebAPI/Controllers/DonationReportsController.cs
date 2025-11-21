using Application.Features.Reports.Donations.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{


    [ApiController]

    [Route("api/[controller]")]

    [Authorize(Roles = "Admin,Manager,SuperAdmin")]

    public class DonationReportsController : ControllerBase

    {

        private readonly IMediator _mediator;

        public DonationReportsController(IMediator mediator)

        {

            _mediator = mediator;

        }

        /// <summary>

        /// Get donations within a date range

        /// </summary>

        [HttpGet("by-date")]

        public async Task<IActionResult> GetByDate([FromQuery] DateTime start, [FromQuery] DateTime end)

        {

            if (start > end)

                return BadRequest("Start date must be before end date.");

            var result = await _mediator.Send(new GetDonationsByDateRangeQuery

            {

                StartDate = start,

                EndDate = end

            });

            if (result == null || !result.Any())

                return NotFound("No donations found in this date range.");

            return Ok(result);

        }

        /// <summary>

        /// Get donations by country

        /// </summary>

        [HttpGet("by-country/{country}")]

        public async Task<IActionResult> GetByCountry(string country)

        {

            if (string.IsNullOrWhiteSpace(country))

                return BadRequest("Country is required.");

            var result = await _mediator.Send(new GetDonationsByCountryQuery

            {

                Country = country

            });

            if (result == null || !result.Any())

                return NotFound($"No donations found for country: {country}");

            return Ok(result);

        }

        /// <summary>

        /// Get details of a specific donation

        /// </summary>

        [HttpGet("{donationId:guid}")]

        public async Task<IActionResult> GetDonationDetails(Guid donationId)

        {

            if (donationId == Guid.Empty)

                return BadRequest("Invalid donation ID.");

            var result = await _mediator.Send(new GetDonationDetailsQuery

            {

                DonationId = donationId

            });

            if (result == null)

                return NotFound($"Donation with ID {donationId} not found.");

            return Ok(result);

        }

    }

}
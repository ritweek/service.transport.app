using System;
using Microsoft.AspNetCore.Mvc;
using service.transport.business;
using service.transport.common.Entity;

namespace service.transport.api.Controllers
{
    [ApiController]
    [Route("api/bookings")]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("{bookingId}")]
        public IActionResult GetBooking(int bookingId)
        {
            var booking = _bookingService.GetBookingById(bookingId);

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        [HttpPost]
        public IActionResult AddBooking([FromBody] Booking booking)
        {
            if (booking == null)
            {
                return BadRequest("Invalid booking data");
            }

            _bookingService.AddBooking(booking);

            return CreatedAtAction(nameof(GetBooking), new { bookingId = booking.BookingId }, booking);
        }
    }
}


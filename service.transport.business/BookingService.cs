using System;
using service.transport.common.Entity;
using service.transport.data;

namespace service.transport.business
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        public Booking GetBookingById(int bookingId)
        {
            return _bookingRepository.GetById(bookingId);
        }

        public void AddBooking(Booking booking)
        {
            _bookingRepository.Add(booking);
        }
    }
}


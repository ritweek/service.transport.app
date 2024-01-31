using System;
using service.transport.common.Entity;

namespace service.transport.business
{
    public interface IBookingService
    {
        Booking GetBookingById(int bookingId);
        void AddBooking(Booking booking);
    }
}


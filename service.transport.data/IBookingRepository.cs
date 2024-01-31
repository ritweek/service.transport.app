using System;
using service.transport.common.Entity;

namespace service.transport.data
{
    public interface IBookingRepository
    {
        Booking GetById(int bookingId);
        void Add(Booking booking);
    }
}


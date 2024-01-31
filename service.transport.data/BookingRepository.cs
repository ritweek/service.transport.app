using System;
using service.transport.common.Entity;

namespace service.transport.data
{
    public class BookingRepository : IBookingRepository
    {
        private readonly TransportDbContext _dbContext;

        public BookingRepository(TransportDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Booking GetById(int bookingId)
        {
            return _dbContext.Bookings.FirstOrDefault(b => b.BookingId == bookingId);
        }

        public void Add(Booking booking)
        {
            _dbContext.Bookings.Add(booking);
            _dbContext.SaveChanges();
        }
    }
}


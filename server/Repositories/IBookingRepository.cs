using sheltermini.Shared;
using System;

namespace sheltermini.server.Repositories
{
    public interface IBookingRepository
    {
        Booking[] getAll();
        void Add(Booking shelter);
    }
}

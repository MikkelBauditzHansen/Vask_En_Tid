using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.Repository;

namespace Vask_En_Tid_Library.Service
{
    public class BookingService
    {
        private readonly IBookingRepository _bookingRepo;

        public BookingService(IBookingRepository bookingRepo)
        {
            _bookingRepo = bookingRepo;
        }

        public void Add(Models.Booking booking)
        {
            _bookingRepo.Add(booking);
        }

        public void Delete(int id)
        {
            _bookingRepo.Delete(id);
        }

        public List<Models.Booking> GetAll()
        {
            return _bookingRepo.GetAll();
        }
        public void Update(Models.Booking booking)
        {
            _bookingRepo.Update(booking);
        }
    }
}

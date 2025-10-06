using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.Models;

namespace Vask_En_Tid_Library.Repository
{
    internal interface IBookingRepository
    {
        public void Add(Booking booking);
        public void Delete(int id);
        public List<Booking> GetAll();
        public void Update(Booking booking);
    }
}

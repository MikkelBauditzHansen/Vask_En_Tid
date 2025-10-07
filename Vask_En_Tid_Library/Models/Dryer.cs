using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vask_En_Tid_Library.Models
{
    public class Dryer : Machine
    {
        public Dryer(int id, int bookingId, string name)
        : base(id, bookingId, "Dryer", name) { }

        public override void Book()
        {
            Console.WriteLine($"🔥 Tørretumbler '{MachineName}' er nu booket!");
        }

        public override void CancelBooking()
        {
            Console.WriteLine($"🔥 Booking af tørretumbler '{MachineName}' er annulleret.");
        }
    }
}

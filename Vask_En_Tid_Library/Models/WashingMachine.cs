using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vask_En_Tid_Library.Models
{
    public class WashingMachine : Machine
    {
        public WashingMachine(int id, int bookingId, string name)
        : base(id, bookingId, "WashingMachine", name) { }

        public override void Book()
        {
            Console.WriteLine($"🧼 Vaskemaskine '{MachineName}' er nu booket!");
        }

        public override void CancelBooking()
        {
            Console.WriteLine($"🧼 Booking af vaskemaskine '{MachineName}' er annulleret.");
        }
    }
}

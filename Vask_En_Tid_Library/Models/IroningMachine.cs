using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vask_En_Tid_Library.Models
{
    internal class IroningMachine : Machine
    {
        public IroningMachine(int id, int bookingId, string name)
        : base(id, bookingId, "IroningMachine", name) { }

        public override void Book()
        {
            Console.WriteLine($"👕 Rullemaskine '{Name}' er nu booket!");
        }

        public override void CancelBooking()
        {
            Console.WriteLine($"👕 Booking af rullemaskine '{Name}' er annulleret.");
        }
    }
}

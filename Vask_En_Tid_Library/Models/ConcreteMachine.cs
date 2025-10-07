using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vask_En_Tid_Library.Models
{
    public class ConcreteMachine : Machine
    {
        public ConcreteMachine(int id, int bookingId, string machineType, string name)
            : base(id, bookingId, machineType, name)
        {
        }

        public override void Book()
        {
            Console.WriteLine($"🧠 Maskine '{MachineName}' af typen '{MachineType}' er nu booket!");
        }

        public override void CancelBooking()
        {
            Console.WriteLine($"🧠 Booking af maskine '{MachineName}' (type: {MachineType}) er annulleret.");
        }
        public ConcreteMachine() { }
    }
}

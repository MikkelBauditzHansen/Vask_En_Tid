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

        public override void Add(Machine machine)
        {
            Console.WriteLine($"Rullemaskine: {Name} er nu booket!");
        }
        public override void Delete(int id)
        {
            Console.WriteLine($"Booking af rullemaskine: {Name} er nu annulleret ");
        }
        public override List<Machine> GetAll()
        {
            return new List<Machine>();
        }
        public override void Update(Machine machine)
        {
            Console.WriteLine($"Listen af maskiner er nu opdateret");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vask_En_Tid_Library.Models
{
    internal class Dryer : Machine
    {
        public Dryer(int id, int bookingId, string name)
        : base(id, bookingId, "Dryer", name) { }

        public override void Add(Machine machine)
        {
            Console.WriteLine($"Tørretumbler: {Name} er nu booket!");
        }
        public override void Delete(int id)
        {
            Console.WriteLine($"Booking af tørretumbler: {Name} er nu annulleret ");
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

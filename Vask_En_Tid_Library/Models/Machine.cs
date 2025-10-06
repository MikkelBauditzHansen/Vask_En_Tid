using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.Repository;

namespace Vask_En_Tid_Library.Models
{
    internal abstract class Machine : IMachineRepository
    {
        public int MachineID {  get; set; }
        public int BookingID { get; set; }
        public string MachineType {  get; set; }
        public string Name { get; set; }

        public Machine(int machineID, int bookingID, string machineType, string name)
        {
            MachineID = machineID;
            BookingID = bookingID;
            MachineType = machineType;
            Name = name;
        }
        public Machine() { }

        public abstract void Add(Machine machine);
        public abstract void Delete(int id);
        public abstract List<Machine> GetAll();
        public abstract void Update(Machine machine);
    }
}

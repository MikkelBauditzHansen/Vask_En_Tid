using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vask_En_Tid_Library.Models
{
    internal class Machine
    {
        public int MachineID {  get; set; }
        public string MachineType {  get; set; }
        public string Name { get; set; }

        public Machine(int machineID, string machineType, string name)
        {
            MachineID = machineID;
            MachineType = machineType;
            Name = name;
        }
        public Machine() { }
    }
}

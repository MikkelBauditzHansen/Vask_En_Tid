using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vask_En_Tid_Library.Repository;

namespace Vask_En_Tid_Library.Models
{
    public abstract class Machine : IMachineActions
    {
        public int MachineID {  get; set; }
        public int BookingID { get; set; }
        public string MachineType {  get; set; }
        public string MachineName { get; set; }

        public Machine(int machineID, int bookingID, string machineType, string machineName)
        {
            MachineID = machineID;
            BookingID = bookingID;
            MachineType = machineType;
            MachineName = machineName;
        }
        public Machine() { }

        public abstract void Book();
        public abstract void CancelBooking();
    }
}

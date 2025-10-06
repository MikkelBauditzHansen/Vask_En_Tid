using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vask_En_Tid_Library.Models
{
    public enum TimeSlotType
    {
        Morning,
        Afternoon,
        Evening,
        Night
    }
    internal class Booking
    {
        public int BookingID {  get; set; }
        public DateTime BookingDate {  get; set; }
        public int ResidentID {  get; set; }
        public int MachineID { get; set; }   
        public TimeSlotType TimeSlot { get; set; }

        public Booking (int bookingID, DateTime bookingDate, int renterID, int machineID, TimeSlotType timeSlot)
        {
            BookingID = bookingID;
            BookingDate = bookingDate;
            BookingID = renterID;
            MachineID = machineID;
            TimeSlot = timeSlot;
             
        }
        public Booking() { }
    }
}

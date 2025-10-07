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
    public class Booking
    {
        public int BookingID {  get; set; }
        public DateTime BookingDate {  get; set; }
        public int ResidentID {  get; set; }
        public int MachineID { get; set; }   
        public TimeSlotType TimeSlot { get; set; }

        public Resident Resident { get; set; }
        public Machine Machine { get; set; }

        public Booking (int bookingID, DateTime bookingDate,int residentID, int machineID, TimeSlotType timeSlot)
        {
            BookingID = bookingID;
            BookingDate = bookingDate;
            ResidentID = residentID;
            MachineID = machineID;
            TimeSlot = timeSlot;
             
        }
        public Booking() { }
    }
}

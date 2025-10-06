using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vask_En_Tid_Library.Models
{
    internal class Booking
    {
        public int BookingID {  get; set; }
        public DateTime BookingDate {  get; set; }
        public int RenterId {  get; set; }
        //public int MachineID { get; set; }        

        public Booking (int bookingID, DateTime bookingDate, int renterID)
        {
            BookingID = bookingID;
            BookingDate = bookingDate;
            BookingID = renterID;
             
        }
        public Booking() { }
    }
}

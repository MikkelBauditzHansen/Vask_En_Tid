using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vask_En_Tid_Library.Models
{
    public class Resident
    {
        public int ResidentID {  get; set; }
        public string ResidentName { get; set; }
        public string City { get; set; }
        public string PostNr { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ApartmentNr { get; set; }
        public int FloorNr { get; set; }

        public Resident(int residentID, string residentName, string city, string postNr, string phoneNumber, string email, string apartmentNr, int floorNr)
        {
            ResidentID = residentID;
            ResidentName = residentName;
            City = city;
            PostNr = postNr;
            PhoneNumber = phoneNumber;
            Email = email;
            ApartmentNr = apartmentNr;
            FloorNr = floorNr;
        }
        public Resident() { }
    }
}

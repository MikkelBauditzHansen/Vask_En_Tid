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
        public string Name { get; set; }
        public string City { get; set; }
        public int PostNr { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int ApartmentNr { get; set; }
        public int FloorNr { get; set; }

        public Resident(int residentID, string name, string city, int postNr, string phoneNumber, string email, int apartmentNr, int floorNr)
        {
            ResidentID = residentID;
            Name = name;
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

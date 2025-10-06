using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vask_En_Tid_Library.Models
{
    internal class Resident
    {
        public int ResidentID {  get; set; }
        public string Name { get; set; }
        public string Adresse { get; set; }
        public int PostNr { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public Resident(string name, string adresse, int postNr, string phoneNumber, string email)
        {
            Name = name;
            Adresse = adresse;
            PostNr = postNr;
            PhoneNumber = phoneNumber;
            Email = email;
        }
        public Resident() { }
    }
}

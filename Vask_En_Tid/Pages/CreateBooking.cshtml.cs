using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Vask_En_Tid_Library.Models;
using Vask_En_Tid_Library.Repository;
using Vask_En_Tid_Library.Service;

namespace Vask_En_Tid.Pages
{
    public class CreateBookingModel : PageModel
    {
        private readonly string _connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=VaskEnTidDataBase;Trusted_Connection=True;TrustServerCertificate=True;";

        public List<Booking> Bookings { get; private set; }

        public List<Machine> Machines { get; private set; }   
        public List<Resident> Residents { get; private set; } 

        [BindProperty]
        public Booking NewBooking { get; set; }

        public string Message { get; private set; }

        public void OnGet()
        {
            BookingCollectionRepo bookingRepo = new BookingCollectionRepo(_connectionString);
            BookingService bookingService = new BookingService(bookingRepo);
            Bookings = bookingService.GetAll();

            MachineCollectionRepo machineRepo = new MachineCollectionRepo(_connectionString);
            Machines = machineRepo.GetAll();

            ResidentCollectionRepo residentRepo = new ResidentCollectionRepo(_connectionString);
            Residents = residentRepo.GetAll();
        }

        public void OnPost()
        {
            BookingCollectionRepo bookingRepo = new BookingCollectionRepo(_connectionString);
            BookingService bookingService = new BookingService(bookingRepo);

            try
            {
                bookingService.Add(NewBooking);
                Message = "Booking oprettet!";
            }
            catch (Exception ex)
            {
                Message = "Fejl: " + ex.Message;
            }

            Machines = new MachineCollectionRepo(_connectionString).GetAll();
            Residents = new ResidentCollectionRepo(_connectionString).GetAll();
            Bookings = bookingService.GetAll();
        }
    }
}

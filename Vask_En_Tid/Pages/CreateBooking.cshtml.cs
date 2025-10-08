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
        // Forbindelse til din database
        private readonly string _connectionString =
            "Server=(localdb)\\MSSQLLocalDB;Database=VaskEnTidDataBase;Trusted_Connection=True;TrustServerCertificate=True;";

        // Lister som bruges på siden
        public List<Booking> Bookings { get; private set; }
        public List<Machine> Machines { get; private set; }
        public List<Resident> Residents { get; private set; }

        [BindProperty]
        public Booking NewBooking { get; set; }

        public string Message { get; private set; }

        // Når siden loades (GET)
        public void OnGet()
        {
            LoadData();
        }

        // Når der oprettes en booking (POST)
        public void OnPost()
        {
            BookingCollectionRepo bookingRepo = new BookingCollectionRepo(_connectionString);
            BookingService bookingService = new BookingService(bookingRepo);

            try
            {
                bookingService.Add(NewBooking);
                Message = "Booking oprettet!";
            }
            catch (System.Exception ex)
            {
                Message = "Fejl: " + ex.Message;
            }

            LoadData();
        }

        // Når der slettes en booking (POST Delete)
        public IActionResult OnPostDelete(int bookingID)
        {
            BookingCollectionRepo bookingRepo = new BookingCollectionRepo(_connectionString);
            BookingService bookingService = new BookingService(bookingRepo);

            try
            {
                bookingService.Delete(bookingID);
                Message = "Booking slettet!";
            }
            catch (System.Exception ex)
            {
                Message = "Fejl ved sletning: " + ex.Message;
            }

            LoadData();
            return Page(); // behold besked og opdateret liste
        }

        // Hjælpefunktion til at hente data
        private void LoadData()
        {
            BookingCollectionRepo bookingRepo = new BookingCollectionRepo(_connectionString);
            BookingService bookingService = new BookingService(bookingRepo);
            Bookings = bookingService.GetAll();

            MachineCollectionRepo machineRepo = new MachineCollectionRepo(_connectionString);
            Machines = machineRepo.GetAll();

            ResidentCollectionRepo residentRepo = new ResidentCollectionRepo(_connectionString);
            Residents = residentRepo.GetAll();
        }
    }
}

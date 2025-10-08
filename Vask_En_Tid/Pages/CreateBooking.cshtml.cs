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
        public List<Booking> Bookings { get; private set; }

        public void OnGet()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=VaskEnTidDataBase;Trusted_Connection=True;";
            BookingCollectionRepo repo = new BookingCollectionRepo(connectionString);
            BookingService service = new BookingService(repo);

            Bookings = service.GetAll();
        }
        [BindProperty]
        public Booking NewBooking { get; set; }

        public string Message { get; private set; }

        public void OnPost()
        {
            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=VaskEnTidDataBase;Trusted_Connection=True;";
            BookingCollectionRepo repo = new BookingCollectionRepo(connectionString);
            BookingService service = new BookingService(repo);

            try
            {
                service.Add(NewBooking);
                Message = "Booking oprettet!";
            }
            catch (Exception ex)
            {
                Message = "Fejl: " + ex.Message;
            }

            Bookings = service.GetAll();
        }

    }
}

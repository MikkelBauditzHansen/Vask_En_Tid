using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vask_En_Tid_Library.Models;
using Vask_En_Tid_Library.Service;

namespace Vask_En_Tid.Pages
{
    public class CreateUserModel : PageModel
    {
        [BindProperty]
        public Resident Resident { get; set; } // aggregering

       

        // Service til håndtering af beboer
        private ResidentService _residentService;

        // Miljøvariabel til at finde stier i projektet (f.eks. wwwroot)
        private readonly IWebHostEnvironment _env;

        // Constructor – modtager dyreservice og miljøinformation
        public CreateUserModel(ResidentService residentService, IWebHostEnvironment env) // assosition
        {
            Resident = new Resident(); // composition
            _residentService = residentService;
            _env = env;
        }

        // GET-metode – bruges ved visning af siden
        public void OnGet()
        {
        }

        // POST-metode – gemmer beboeren
        public IActionResult OnPost()
        {
            

            // Tilføj beboeren til servicen
            Debug.WriteLine("test");
            _residentService.Add(Resident);

            // Gå tilbage til oversigten
            return RedirectToPage("/ResidentGrid");
        }
    }
}

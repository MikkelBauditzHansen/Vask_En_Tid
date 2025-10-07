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

       

        // Service til h�ndtering af beboer
        private ResidentService _residentService;

        // Milj�variabel til at finde stier i projektet (f.eks. wwwroot)
        private readonly IWebHostEnvironment _env;

        // Constructor � modtager dyreservice og milj�information
        public CreateUserModel(ResidentService residentService, IWebHostEnvironment env) // assosition
        {
            Resident = new Resident(); // composition
            _residentService = residentService;
            _env = env;
        }

        // GET-metode � bruges ved visning af siden
        public void OnGet()
        {
        }

        // POST-metode � gemmer beboeren
        public IActionResult OnPost()
        {
            

            // Tilf�j beboeren til servicen
            Debug.WriteLine("test");
            _residentService.Add(Resident);

            // G� tilbage til oversigten
            return RedirectToPage("/ResidentGrid");
        }
    }
}

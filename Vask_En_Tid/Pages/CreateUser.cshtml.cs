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

        // Det billede der uploades til beboeren
        [BindProperty]
        public IFormFile ImageFile { get; set; }

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

        // POST-metode � gemmer dyret og eventuelt billede
        public IActionResult OnPost()
        {
            // Hvis brugeren har uploadet et billede
            if (ImageFile != null && ImageFile.Length > 0)
            {
                // Opret et unikt filnavn og find filsti
                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(ImageFile.FileName);
                string filePath = Path.Combine(_env.WebRootPath, "Img", fileName);

                // Gem billedet p� serveren
                using (FileStream stream = new FileStream(filePath, FileMode.Create))
                {
                    ImageFile.CopyTo(stream);
                }

                // Gem filnavnet (relativ sti) i modellen
                Animal.ImagePath = fileName;
            }

            // Tilf�j dyret til servicen
            Debug.WriteLine("test");
            _animalService.Add(Animal);

            // G� tilbage til oversigten
            return RedirectToPage("/AnimalsGrid");
        }
    }
}

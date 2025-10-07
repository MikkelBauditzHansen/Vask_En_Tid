using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vask_En_Tid_Library.Models;
using Vask_En_Tid_Library.Service;

namespace Vask_En_Tid.Pages
{
    public class ResidentGridModel : PageModel
    {
        public List<Resident> Resident { get; set; } = new List<Resident>();
        // Service til h�ndtering af beboerdata
        private readonly ResidentService _residentService;

        // Constructor � s�tter filstien ud fra projektets rodmappe og initialiserer service
        public ResidentGridModel(IWebHostEnvironment environment, ResidentService residentService)
        {
            _residentService = residentService;
        }
        // Beboer som brugeren kan tilf�je via formular
        [BindProperty]
        public Resident NewResident { get; set; } = new Resident();

        // GET-metode � henter og filtrerer dyr
        public void OnGet()
        {
            // Henter alle beboer fra service
            Resident = _residentService.GetAll();
        }

        // POST-metode � tilf�jer ny beboer
        public IActionResult OnPost()
        {
            // Tilf�j nyt dyr via service
            _residentService.Add(NewResident);

            // Hent eksisterende liste fra JSON
            List<Resident> residents = new List<Resident>();

            // Genindl�s siden
            return RedirectToPage();
        }

        // POST-metode � slet et dyr ud fra ID
        public IActionResult OnPostDelete(int residentID)
        {
            _residentService.Delete(residentID);
            return RedirectToPage(); // Opdaterer siden
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Vask_En_Tid_Library.Models;
using Vask_En_Tid_Library.Repository;
using Vask_En_Tid_Library.Service;

namespace Vask_En_Tid.Pages
{
    public class CreateUserModel : PageModel
    {
        private readonly string _connectionString =
            "Server=(localdb)\\MSSQLLocalDB;Database=VaskEnTidDataBase;Trusted_Connection=True;TrustServerCertificate=True;";

        [BindProperty]
        public Resident Resident { get; set; }

        private ResidentService _residentService;
        public string Message { get; private set; }

        public CreateUserModel(IWebHostEnvironment env)
        {
            ResidentCollectionRepo repo = new ResidentCollectionRepo(_connectionString);
            _residentService = new ResidentService(repo);
            Resident = new Resident();
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            // Hent eksisterende beboere
            List<Resident> allResidents = _residentService.GetAll();

            // Sørg for at ApartmentNr (lejlighedsnummer) er unikt
            bool exists = allResidents.Any(r => r.ApartmentNr == Resident.ApartmentNr);
            if (exists)
            {
                Message = $"Lejlighed {Resident.ApartmentNr} er allerede registreret. Hver lejlighed må kun have én beboer.";
                return Page();
            }

            // Automatisk ID (baseret på højeste eksisterende ID)
            if (allResidents.Count > 0)
            {
                Resident.ResidentID = allResidents.Max(r => r.ResidentID) + 1;
            }
            else
            {
                Resident.ResidentID = 1;
            }

            // Tjek at lejlighedsnummer følger formatet: X.A / 1.B osv.
            string pattern = @"^[0-9]+\.[A-Z]$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(Resident.ApartmentNr.ToString(), pattern))
            {
                Message = "Lejlighedsnummer skal følge formatet f.eks. 0.A eller 1.B.";
                return Page();
            }

            try
            {
                _residentService.Add(Resident);
                Message = "Beboerprofil oprettet!";
                return RedirectToPage("/ResidentGrid"); // send tilbage til oversigt
            }
            catch (System.Exception ex)
            {
                Message = "Fejl under oprettelse: " + ex.Message;
                return Page();
            }
        }
    }
}

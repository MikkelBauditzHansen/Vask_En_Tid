using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Vask_En_Tid_Library.Models;
using Vask_En_Tid_Library.Repository;
using Vask_En_Tid_Library.Service;

namespace Vask_En_Tid.Pages
{
    public class ResidentGridModel : PageModel
    {
        // Connection string til SQL-databasen
        private readonly string _connectionString =
            "Server=(localdb)\\MSSQLLocalDB;Database=VaskEnTidDataBase;Trusted_Connection=True;TrustServerCertificate=True;";

        // Liste som indeholder alle beboere
        public List<Resident> Resident { get; set; } = new List<Resident>();

        // Service som h�ndterer CRUD-operationer for beboere
        private ResidentService _residentService;

        // Property som bruges til at modtage nye beboerdata fra formularen
        [BindProperty]
        public Resident NewResident { get; set; } = new Resident();

        // Constructor � initialiserer repository og service s� vi kan forbinde til databasen
        public ResidentGridModel()
        {
            // Opretter repository og sender det videre til service-laget
            ResidentCollectionRepo repo = new ResidentCollectionRepo(_connectionString);
            _residentService = new ResidentService(repo);
        }

        // GET-metode � kaldes n�r siden hentes f�rste gang
        // Henter alle eksisterende beboere fra databasen
        public void OnGet()
        {
            Resident = _residentService.GetAll();
        }

        // POST-metode � kaldes n�r brugeren indsender formularen for at oprette en ny beboer
        public IActionResult OnPost()
        {
            try
            {
                // Fors�ger at tilf�je den nye beboer til databasen
                _residentService.Add(NewResident);

                // Viser besked p� siden hvis oprettelsen lykkes
                TempData["Message"] = "Beboer oprettet!";
            }
            catch (System.Exception ex)
            {
                // Hvis der sker en fejl, vises en fejlbesked til brugeren
                TempData["Message"] = "Fejl under oprettelse: " + ex.Message;
            }

            // Genindl�ser siden s� brugeren ser den opdaterede liste
            return RedirectToPage();
        }

        // POST-metode � kaldes n�r brugeren trykker p� "Slet" knappen
        // Denne metode modtager et ID p� den beboer der skal slettes
        public IActionResult OnPostDelete(int residentID)
        {
            try
            {
                // Fors�ger at slette beboeren fra databasen
                _residentService.Delete(residentID);

                // Viser besked hvis sletningen lykkes
                TempData["Message"] = "Beboer slettet!";
            }
            catch (System.Exception ex)
            {
                // Hvis der sker fejl, vis besked p� siden
                TempData["Message"] = "Fejl under sletning: " + ex.Message;
            }

            // Genindl�ser siden for at vise opdateret liste
            return RedirectToPage();
        }
    }
}

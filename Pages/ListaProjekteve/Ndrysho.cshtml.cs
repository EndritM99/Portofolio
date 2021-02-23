using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portofolio.Model;

namespace Portofolio.Pages.ListaProjekteve
{
    public class NdryshoModel : PageModel
    {
        private ApplicationDbContext _db;

        public NdryshoModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Projektet Projekti { get; set; }

        public async Task OnGet(int id)
        {
            Projekti = await _db.Projektet.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var ProjektiFromDb = await _db.Projektet.FindAsync(Projekti.Id);
                ProjektiFromDb.Autori = Projekti.Autori;
                ProjektiFromDb.EmriProjektit = Projekti.EmriProjektit;
                ProjektiFromDb.Pershkrimi = Projekti.Pershkrimi;
                ProjektiFromDb.URL = Projekti.URL;

                await _db.SaveChangesAsync();

                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}

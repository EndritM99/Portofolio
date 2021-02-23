using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portofolio.Model;

namespace Portofolio.Pages.ListaProjekteve
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Projektet> Projects { get; set; }

        public async Task OnGet()
        {
            Projects = await _db.Projektet.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var ProjektiQeDoTeFshihet = await _db.Projektet.FindAsync(id);
            if (ProjektiQeDoTeFshihet == null)
            {
                return NotFound();
            }
            _db.Projektet.Remove(ProjektiQeDoTeFshihet);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }

    }
}

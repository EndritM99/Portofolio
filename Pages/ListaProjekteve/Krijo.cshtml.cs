using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Portofolio.Model;

namespace Portofolio.Pages.ListaProjekteve
{
    public class KrijoModel : PageModel
    {
        private readonly ApplicationDbContext _db;


        public KrijoModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Projektet projektet2 { get; set; }

        public void OnGet()
        {  
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Projektet.AddAsync(projektet2);
                await _db.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}

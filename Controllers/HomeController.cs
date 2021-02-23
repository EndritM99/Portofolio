using Microsoft.AspNetCore.Mvc;
using Portofolio.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Portofolio.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data=_db.Projektet.ToList()});
        }
    }
}

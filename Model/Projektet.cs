using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portofolio.Model
{
    public class Projektet
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string URL { get; set; }

        public string Autori { get; set; }

        [Required]
        public string EmriProjektit { get; set; }

        public string Pershkrimi { get; set; }


    }
}

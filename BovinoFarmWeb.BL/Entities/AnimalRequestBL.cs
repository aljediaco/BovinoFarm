using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovinoFarmWeb.BL.Entities
{
    public class AnimalRequestBL
    {
        public string? Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string? Sex { get; set; }
        public decimal Price { get; set; }
        public string? Comments { get; set; }
        public string? IdBreed { get; set; }
    }
}

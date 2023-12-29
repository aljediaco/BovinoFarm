using BovinoFarmWeb.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovinoFarmWeb.DAL.Entities
{
    public class AnimalDAL
    {        
        public string? IdAnimal { get; set; }
        public string? Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string? Sex { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public string? Comments { get; set; }
        public DateTime RegistrationDate { get; set; }


        public string? IdBreed { get; set; }
        public BreedDAL? BreedType { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovinoFarmWeb.DAL.Entities
{
    public class BreedDAL
    {
        public string IdBreed { get; set; }
        public string Name { get; set; }
        public DateTime RegistrationDate { get; set; }
        public ICollection<AnimalDAL> Animals { get; set; }
    }
}

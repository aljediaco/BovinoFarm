namespace BovinoFarmWeb.BL.Entities
{
    public  class AnimalResponseBL
    {
        public string? IdAnimal { get; set; }
        public string? Name { get; set; }
        public DateTime Birthdate { get; set; }
        public string? Sex { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public string? Comments { get; set; }
        public string? IdBreed { get; set; }
        public BreedResponseBL Breed { get; set; }
    }
}

using AutoMapper;
using BovinoFarmWeb.BL.Entities;
using BovinoFarmWeb.DAL;
using BovinoFarmWeb.DAL.Entities;

namespace BovinoFarmWeb.BL
{
    public class AnimalsFarmBL
    {
        private static readonly AnimalsFarmDal obj = new AnimalsFarmDal();
        private static readonly BreedsFarmBL objBreedBL = new BreedsFarmBL();

        public AnimalResponseBL GetAnimalByIDBL(string Id)
        {
            try
            {
                List<AnimalDAL> Query = obj.GetAnimalByIdDAL(Id);

                MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<AnimalDAL, AnimalResponseBL>(); });
                IMapper iMapper = config.CreateMapper();
                var destination = from obj in Query select iMapper.Map<AnimalDAL, AnimalResponseBL>(obj);
                var resultAnimal = destination.ToList();

                if (resultAnimal.Count > 0)
                {
                    AnimalResponseBL animal = resultAnimal.FirstOrDefault();
                    animal.Breed = objBreedBL.GetBreedByIDBL(animal.IdBreed);
                    return animal;
                }
                else
                {
                    throw new FileNotFoundException("No data found.");                    
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<AnimalResponseBL> GetAnimalBL(int actualPage, int pageSize)
        {
            try
            {
                List<AnimalDAL> Query = obj.GetAnimalDAL(actualPage, pageSize);

                MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<AnimalDAL, AnimalResponseBL>(); });
                IMapper iMapper = config.CreateMapper();
                var lstAnimal = from obj in Query select iMapper.Map<AnimalDAL, AnimalResponseBL>(obj);
                var resultAnimals = lstAnimal.ToList();

                if (resultAnimals == null || resultAnimals.Count == 0)
                {
                    throw new FileNotFoundException("Data Not Found...");
                }

                foreach (var animal in resultAnimals)
                {
                    animal.Breed = objBreedBL.GetBreedByIDBL(animal.IdBreed);
                }

                return resultAnimals;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<object> GetAnimalByGroupBL()
        {
            try
            {
                var groupAnimal = obj.GetAnimalByGroupDAL();

                if (groupAnimal.Count == 0)
                {
                    throw new FileNotFoundException("Data Not Found...");
                }

                return groupAnimal;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }         

        public async Task<AnimalResponseBL> PostAnimalBL(AnimalRequestBL animalRq)
        {
            try
            {
                var nameExists = obj.GetAnimalByNameDAL(animalRq.Name);

                if (!nameExists && animalRq.Price > 0)
                {
                    string IdAnimal = await obj.PostAnimalDAL(animalRq.Name, animalRq.Birthdate, animalRq.Sex, animalRq.Price, 
                                                        animalRq.Comments, animalRq.IdBreed);

                    var resultAnimal = GetAnimalByIDBL(IdAnimal);
                    return resultAnimal;
                }
                else
                {
                    throw new InvalidDataException("The registry doesn't comply with the established parameters.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public AnimalResponseBL UpdateAnimalBL(AnimalPutBL animal)
        {
            try
            {
                var nameExists = obj.GetAnimalByNameDAL(animal.Name);

                if (!nameExists && animal.Price > 0)
                {
                    obj.UpdateAnimalDAL(animal.IdAnimal, animal.Name, animal.Birthdate, animal.Sex, animal.Price,
                                                        animal.Status, animal.Comments, animal.IdBreed);

                    var resultAnimal = GetAnimalByIDBL(animal.IdAnimal);

                    return resultAnimal;
                }
                else
                {
                    throw new InvalidDataException("The registry doesn't comply with the established parameters.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool DeleteAnimalBL(string Id)
        {
            try
            {
                return obj.DeleteAnimalDAL(Id).Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

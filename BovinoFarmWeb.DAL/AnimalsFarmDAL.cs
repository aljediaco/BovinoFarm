using BovinoFarmWeb.DAL.Entities;
using BovinoFarmWeb.DAL.Models;

namespace BovinoFarmWeb.DAL
{
    public class AnimalsFarmDal
    {
        /// <summary>
        /// Animal query by ID
        /// </summary>
        /// <returns></returns>
        public List<AnimalDAL> GetAnimalByIdDAL(string Id)
        {
            try
            {
                using (var db = new BovinoFarmDbContext())
                {
                    var animal = db.Animals
                        .Where(p => p.IdAnimal == Id);

                    List<AnimalDAL> result = animal.ToList();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// Animal query
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// 
        public List<AnimalDAL> GetAnimalDAL(int actualPage, int pageSize)
        {
            try
            {
                using (var db = new BovinoFarmDbContext())
                {
                    int omitted = (actualPage - 1) * pageSize;

                    List<AnimalDAL> paginatedData = db.Animals
                           .Skip(omitted)
                           .Take(pageSize)
                           .ToList();

                    return paginatedData;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// consult animal information by name
        /// </summary>
        /// <param name="animalName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool GetAnimalByNameDAL(string animalName)
        {
            try
            {
                using (var db = new BovinoFarmDbContext())
                {
                    var nameExists = db.Animals
                        .Any(p => p.Name == animalName);

                    return nameExists;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// animal information by groups
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<object> GetAnimalByGroupDAL()
        {
            try
            {
                using (var db = new BovinoFarmDbContext())
                {
                    var animalGroup = db.Animals
                        .Where(p => p.Status == true)
                        .GroupBy(p => p.IdBreed)
                        .Select(group => new
                        {
                            Breed = group.Key,
                            Animals = group.ToList()
                        }).ToList();

                    return animalGroup.Cast<object>().ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// save data for animal
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Birthdate"></param>
        /// <param name="Sex"></param>
        /// <param name="Price"></param>
        /// <param name="Status"></param>
        /// <param name="Comments"></param>
        public async Task<string> PostAnimalDAL(string Name, DateTime Birthdate, string Sex, decimal Price, string Comments, string IdBreed)
        {
            try
            {
                using (var db = new BovinoFarmDbContext())
                {
                    await db.Database.EnsureCreatedAsync();
                    var Id = Guid.NewGuid().ToString();

                    var anumal = new AnimalDAL()
                    {
                        IdAnimal = Id,
                        Name = Name,
                        Birthdate = Birthdate,
                        Sex = Sex,
                        Price = Price,
                        Status = true,
                        Comments = Comments,
                        RegistrationDate = DateTime.Now,
                        IdBreed = IdBreed
                    };

                    db.Animals.Add(anumal);
                    await db.SaveChangesAsync();

                    return Id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// update animal information
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Name"></param>
        /// <param name="Birthdate"></param>
        /// <param name="Sex"></param>
        /// <param name="Price"></param>
        /// <param name="status"></param>
        /// <param name="Comments"></param>
        /// <param name="IdBreed"></param>
        /// <exception cref="Exception"></exception>
        public async void UpdateAnimalDAL(string Id, string Name, DateTime Birthdate, string Sex, decimal Price, bool status,
                                                    string Comments, string IdBreed)
        {
            try
            {
                using (var db = new BovinoFarmDbContext())
                {
                    await db.Database.EnsureCreatedAsync();

                    var animal = db.Animals.FirstOrDefault(p => p.IdAnimal == Id);

                    if (animal != null)
                    {
                        animal.Name = Name;
                        animal.Birthdate = Birthdate;
                        animal.Sex = Sex;
                        animal.Price = Price;
                        animal.Status = status;
                        animal.Comments = Comments;
                        animal.IdBreed = IdBreed;
                    }

                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        /// <summary>
        /// delete animal information
        /// </summary>
        /// <param name="Id"></param>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteAnimalDAL(string Id)
        {
            try
            {
                using (var db = new BovinoFarmDbContext())
                {
                    var animal = db.Animals.FirstOrDefault(p => p.IdAnimal == Id);

                    if (animal != null)
                    {
                        db.Animals.Remove(animal);
                        await db.SaveChangesAsync();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
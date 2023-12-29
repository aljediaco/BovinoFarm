using BovinoFarmWeb.DAL.Entities;
using BovinoFarmWeb.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BovinoFarmWeb.DAL
{
    public class BreedFarmDAL
    {
        /// <summary>
        /// Breed query by ID
        /// </summary>
        /// <returns></returns>
        public List<BreedDAL> GetBreedByIdDAL(string Id)
        {
            try
            {
                using (var db = new BovinoFarmDbContext())
                {
                    var Breed = db.Breeds
                        .Where(p => p.IdBreed == Id);

                    List<BreedDAL> result = Breed.ToList();

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// check all breeds
        /// </summary>
        /// <param name="actualPage"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<BreedDAL> GetBreedDAL(int actualPage, int pageSize)
        {
            try
            {
                using (var db = new BovinoFarmDbContext())
                {
                    int omitted = (actualPage - 1) * pageSize;

                    List<BreedDAL> paginatedData = db.Breeds
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
        /// save breed information
        /// </summary>
        /// <param name="breed"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<string> PostBreedDAL(string Name)
        {
            try
            {
                using (var db = new BovinoFarmDbContext())
                {
                    await db.Database.EnsureCreatedAsync();
                    var Id = Guid.NewGuid().ToString();

                    var breed = new BreedDAL()
                    {
                        IdBreed = Id,
                        Name = Name,
                        RegistrationDate = DateTime.Now
                    };

                    db.Breeds.Add(breed);
                    await db.SaveChangesAsync();

                    return Id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        /// <summary>
        /// Update breed information
        /// </summary>
        /// <param name="Breed"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async void UpdateBreedDAL(string Id, string Name)
        {
            try
            {
                using (var db = new BovinoFarmDbContext())
                {
                    await db.Database.EnsureCreatedAsync();

                    var Breed = db.Breeds.FirstOrDefault(p => p.IdBreed == Id);

                    if (Breed != null)
                    {
                        Breed.Name = Name;
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
        /// Delet creed information
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteBreedDAL(string Id)
        {
            try
            {
                using (var db = new BovinoFarmDbContext())
                {
                    var Breed = db.Breeds.FirstOrDefault(p => p.IdBreed == Id);

                    if (Breed != null)
                    {
                        db.Breeds.Remove(Breed);
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

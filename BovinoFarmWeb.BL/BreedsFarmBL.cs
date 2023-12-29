using AutoMapper;
using BovinoFarmWeb.BL.Entities;
using BovinoFarmWeb.DAL;
using BovinoFarmWeb.DAL.Entities;

namespace BovinoFarmWeb.BL
{
    public class BreedsFarmBL
    {
        private static readonly BreedFarmDAL obj = new BreedFarmDAL();

        public BreedResponseBL GetBreedByIDBL(string Id)
        {
            try
            {
                List<BreedDAL> Query = obj.GetBreedByIdDAL(Id);

                MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<BreedDAL, BreedResponseBL>(); });
                IMapper iMapper = config.CreateMapper();
                var destination = from obj in Query select iMapper.Map<BreedDAL, BreedResponseBL>(obj);
                var resultBreed = destination.ToList();

                if (resultBreed.Count > 0)
                {
                    return destination.FirstOrDefault();
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

        public List<BreedResponseBL> GetBreedBL(int actualPage, int pageSize)
        {
            try
            {
                List<BreedDAL> Query = obj.GetBreedDAL(actualPage, pageSize);

                MapperConfiguration config = new MapperConfiguration(cfg => { cfg.CreateMap<BreedDAL, BreedResponseBL>(); });
                IMapper iMapper = config.CreateMapper();
                var lstBreed = from obj in Query select iMapper.Map<BreedDAL, BreedResponseBL>(obj);

                var result = lstBreed.ToList();

                if (result == null || result.Count == 0)
                {
                    throw new FileNotFoundException("Data Not Found...");
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public async Task<BreedResponseBL> PostBreedBL(BreedRequestBL breed)
        {
            try
            {
                string IdBreed = await obj.PostBreedDAL(breed.Name);
                var resultBreed = GetBreedByIDBL(IdBreed);

                return resultBreed;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
                
        public BreedResponseBL UpdateBreedBL(BreedResponseBL Breed)
        {
            try
            {
                    obj.UpdateBreedDAL(Breed.IdBreed, Breed.Name);

                    var resultBreed = GetBreedByIDBL(Breed.IdBreed);

                    return resultBreed;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool DeleteBreedBL(string Id)
        {
            try
            {
                return obj.DeleteBreedDAL(Id).Result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

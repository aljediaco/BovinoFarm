using BovinoFarmWeb.BL;
using BovinoFarmWeb.BL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BovinoFarmWeb.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly AnimalsFarmBL obj = new AnimalsFarmBL();

        [HttpGet("{Id}")]
        public ActionResult<AnimalResponseBL> GetAnimalByID(string Id)
        {
            try
            {
                var animal = obj.GetAnimalByIDBL(Id);
                return Ok(animal);
            }            
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{actualPage}/{pageSize}")]
        public ActionResult<AnimalResponseBL> GetAnimal(int actualPage, int pageSize)
        {
            try
            {
                var animals = obj.GetAnimalBL(actualPage, pageSize);
                return Ok(animals);
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GroupByBreed")]
        public ActionResult<AnimalResponseBL> GetAnimalByGroup()
        {
            try
            {
                var groupByBreed = obj.GetAnimalByGroupBL();
                return Ok(groupByBreed);
            }
            catch (FileNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult<AnimalResponseBL> CreateAnimal([FromBody] AnimalRequestBL animal)
        {
            try
            {
                var create = obj.PostAnimalBL(animal);
                return Ok(create);
            }            
            catch (InvalidDataException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<AnimalResponseBL> UpdateAnimal([FromBody] AnimalPutBL animal)
        {
            try
            {
                var update = obj.UpdateAnimalBL(animal);
                return Ok(update);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult<AnimalResponseBL> DeleteAnimal(string Id)
        {
            try
            {
                var delete = obj.DeleteAnimalBL(Id);
                return Ok(delete);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

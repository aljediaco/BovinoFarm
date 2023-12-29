using BovinoFarmWeb.BL;
using BovinoFarmWeb.BL.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BovinoFarmWeb.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BreedController : ControllerBase
    {
        private static readonly BreedsFarmBL obj = new BreedsFarmBL();

        [HttpGet("{Id}")]
        public ActionResult<BreedResponseBL> GetBreedByID(string Id)
        {
            try
            {
                var Breed = obj.GetBreedByIDBL(Id);
                return Ok(Breed);
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
        public ActionResult<BreedResponseBL> GetBreed(int actualPage, int pageSize)
        {
            try
            {
                var animals = obj.GetBreedBL(actualPage, pageSize);
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

        [HttpPost]
        public ActionResult<BreedResponseBL> CreateBreed([FromBody] BreedRequestBL breed)
        {
            try
            {
                var create = obj.PostBreedBL(breed);
                return Ok(create);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<BreedResponseBL> UpdateBreed([FromBody] BreedResponseBL Breed)
        {
            try
            {
                var update = obj.UpdateBreedBL(Breed);
                return Ok(update);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public ActionResult<BreedResponseBL> DeleteBreed(string Id)
        {
            try
            {
                var delete = obj.DeleteBreedBL(Id);
                return Ok(delete);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

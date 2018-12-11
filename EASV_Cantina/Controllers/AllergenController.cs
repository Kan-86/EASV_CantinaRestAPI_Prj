using System.Collections.Generic;
using CantinaApp.Core.ApplicationServices;
using CantinaApp.Core.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EASV_CantinaRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergenController: ControllerBase
    {
        private readonly IAllergenServices _AllergenService;

        public AllergenController(IAllergenServices allergenServices)
        {
            _AllergenService = allergenServices;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<Allergens>> Get()
        {
            return _AllergenService.GetAllergens();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<Allergens> Get(int id)
        {
            return _AllergenService.FindAllergenId(id);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult<Allergens> Delete(int id)
        {
            return _AllergenService.DeleteAllergen(id);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CantinaApp.Core.ApplicationServices;
using CantinaApp.Core.Entity.Entities;
using Microsoft.AspNetCore.Http;
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

        // POST api/<controller>
        [HttpPost]
        public ActionResult<Allergens> Post([FromBody]Allergens all)
        {
            try
            {
                return Ok(_AllergenService.AddAllergen(all));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult<Allergens> Put(int id, [FromBody]Allergens all)
        {
            try
            {
                var entity = _AllergenService.UpdateAllergen(all);
                return entity;
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult<Allergens> Delete(int id)
        {
            return _AllergenService.DeleteAllergen(id);
        }
    }
}
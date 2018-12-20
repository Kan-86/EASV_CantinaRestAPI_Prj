using System;
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
            try
            {

                return Ok(_AllergenService.GetAllergens());
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<Allergens> Get(int id)
        {
            try
            {

                return Ok(_AllergenService.FindAllergenId(id));
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
            try
            {

                return Ok(_AllergenService.DeleteAllergen(id));
            }

            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
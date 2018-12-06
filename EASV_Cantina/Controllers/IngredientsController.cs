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
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientsServices _ingredientService;

        public IngredientsController(IIngredientsServices ingredientService)
        {
            _ingredientService = ingredientService;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<Ingredients>> Get()
        {
            return _ingredientService.GetIngredients();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<Ingredients> Get(int id)
        {
            return _ingredientService.FindIngredientId(id);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<Ingredients> Post([FromBody]Ingredients ingr)
        {
            return _ingredientService.AddIngredient(ingr);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult<Ingredients> Put(int id, [FromBody]Ingredients ingr)
        {
            var entity = _ingredientService.UpdateIngredient(ingr);
            return entity;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult<Ingredients> Delete(int id)
        {
            return _ingredientService.DeleteIngredient(id);
        }
    }
}
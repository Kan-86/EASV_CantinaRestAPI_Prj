using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CantinaApp.Core.ApplicationServices;
using CantinaApp.Core.DomainServices.List;
using CantinaApp.Core.Entity.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EASV_CantinaRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainFoodController : ControllerBase
    {
        private readonly IMainFoodServices _mainFoodService;
        public MainFoodController(IMainFoodServices mainFoodService)
        {
            _mainFoodService = mainFoodService;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<MainFood>> Get()
        {
            try
            {
                return Ok(_mainFoodService.GetMainFood().ToList());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<MainFood> Get(int id)
        {
            try { 

            return Ok(_mainFoodService.FindMainFoodIdIncludeRecipAlrg(id));
                 }
            catch (Exception e)
            {
                return BadRequest(e.Message);
             }
}

        // POST api/<controller>
        [HttpPost]
        public ActionResult<MainFood> Post([FromBody]MainFood mFood)
        {
            try
            {
                return Ok( _mainFoodService.AddMainFood(mFood));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult<MainFood> Put(int id, [FromBody]MainFood mFood)
        {
            try
            {
                var entity = _mainFoodService.UpdateMainFood(mFood);
                entity.MainFoodName = mFood.MainFoodName;
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult<MainFood> Delete(int id)
        {
            try
            {
                return Ok(_mainFoodService.DeleteMainFood(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using CantinaApp.Core.ApplicationServices;
using CantinaApp.Core.Entity.Entities;
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
        public ActionResult<IEnumerable<MainFood>> Get([FromQuery] DateTime date)
        {

            
            try
            { if (date.Date == DateTime.Now.Date)
                {
                    return Ok(_mainFoodService.GetTodayFood(date).ToList());
                }
                else
                {
                    return Ok(_mainFoodService.GetMainFood().ToList());
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<MainFood>> Get(int id)
        {
            try
            { 

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
            return _mainFoodService.AddMainFood(mFood);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult<MainFood> Put(int id, [FromBody]MainFood mFood)
        {
            var entity = _mainFoodService.UpdateMainFood(mFood);
            entity.MainFoodName = mFood.MainFoodName;
            return entity;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult<MainFood> Delete(int id)
        {
            return _mainFoodService.DeleteMainFood(id);
        }
    }
}
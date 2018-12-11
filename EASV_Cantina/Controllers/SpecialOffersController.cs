using System.Collections.Generic;
using CantinaApp.Core.ApplicationServices;
using CantinaApp.Core.Entity.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EASV_CantinaRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialOffersController : ControllerBase
    {
        private readonly ISpecialOffersServices _spclService;

        public SpecialOffersController(ISpecialOffersServices spclService)
        {
            _spclService = spclService;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<IEnumerable<SpecialOffers>> Get()
        {
            try
            {
                return Ok(_spclService.GetSpecialOffers());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<SpecialOffers> Get(int id)
        {
            try
            {
                return Ok(_spclService.GetSpecialOffersById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<SpecialOffers> Post([FromBody]SpecialOffers spcl)
        {
            try
            {
                return Ok(_spclService.AddSpecialOffer(spcl));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult<SpecialOffers> Put(int id, [FromBody]SpecialOffers spcl)
        {
            try
            {
                var entity = _spclService.UpdateSpecialOffer(spcl);
                entity.SpecialOfferName = spcl.SpecialOfferName;
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult<SpecialOffers> Delete(int id)
        {
            try
            {
                return Ok(_spclService.DeleteSpecialOffer(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
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
            return _spclService.GetSpecialOffers();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<SpecialOffers> Get(int id)
        {
            return _spclService.GetSpecialOffersById(id);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult<SpecialOffers> Post([FromBody]SpecialOffers spcl)
        {
            return _spclService.AddSpecialOffer(spcl);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult<SpecialOffers> Put(int id, [FromBody]SpecialOffers spcl)
        {
            var entity = _spclService.UpdateSpecialOffer(spcl);
            entity.SpecialOfferName = spcl.SpecialOfferName;
            return entity;
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult<SpecialOffers> Delete(int id)
        {
            return _spclService.DeleteSpecialOffer(id);
        }
    }
}
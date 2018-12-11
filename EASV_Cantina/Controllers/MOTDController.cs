using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CantinaApp.Core.Entity.Entities;
using CantinaApp.Core.ApplicationServices;
using System;

namespace EASV_CantinaRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MOTDController : ControllerBase
    {

        private readonly IMOTDServices _MOTDServices;

        public MOTDController(IMOTDServices MOTDServices)
        {
            
                _MOTDServices = MOTDServices;
           
        }

        // GET: api/MOTD
        [HttpGet]
        public ActionResult<IEnumerable<MOTD>> GetMOTD()
        {
            try
            {
                return Ok(_MOTDServices.GetMOTDs());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/MOTD/5
        [HttpGet("{id}")]
        public ActionResult<MOTD> Get(int id)
        {
            try{
                return Ok(_MOTDServices.GetMOTDById(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // PUT: api/MOTD/5
        [HttpPut("{id}")]
        public ActionResult<MOTD> PutMOTD([FromRoute] int id, [FromBody] MOTD mOTD)
        {
            try
            {
                var entity = _MOTDServices.UpdateMOTD(mOTD);
                entity.TipOfTheDay = mOTD.TipOfTheDay;
                return Ok(entity);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: api/MOTD
        [HttpPost]
        public ActionResult<MOTD>  post([FromBody]MOTD motd)
        {
            try
            {
                return Ok(_MOTDServices.AddMOTD(motd));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // DELETE: api/MOTD/5
        [HttpDelete("{id}")]
        public ActionResult<MOTD> Delete(int id)
        {
            try
            {
                return Ok(_MOTDServices.DeleteMOTD(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
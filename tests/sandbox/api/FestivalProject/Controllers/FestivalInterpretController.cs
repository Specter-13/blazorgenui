using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FestivalProject.BL.Facade;
using FestivalProject.BL.Models.FestivalInterpretDto;
using Microsoft.AspNetCore.Mvc;

namespace FestivalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FestivalInterpretController : ControllerBase
    {
        private readonly FestivalInterpretFacade _facade;
        public FestivalInterpretController(FestivalInterpretFacade facade)
        {
            _facade = facade;
        }

        [HttpPost]
        public IActionResult Create([FromBody] FestivalInterpretCreateUpdate item)
        {
            try
            {
                var returnedItem = _facade.Create(item);
                if (returnedItem == null)
                    return BadRequest();

                return Ok(returnedItem);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
           

           


        }

        [HttpPut]
        public IActionResult Update([FromBody] FestivalInterpretCreateUpdate item)
        {
            try
            {
                return Ok(_facade.Update(item));
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }


        [HttpDelete("{festivalId}/{interpretId}")]
        public IActionResult Delete(Guid festivalId, Guid interpretId)
        {
            try
            {
                _facade.Delete(festivalId, interpretId);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FestivalProject.BL.Facade;
using FestivalProject.BL.Models.StageInterpretDto;
using Microsoft.AspNetCore.Mvc;

namespace FestivalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StageInterpretController : ControllerBase
    {
        private readonly StageInterpretFacade _facade;
        public StageInterpretController(StageInterpretFacade facade)
        {
            _facade = facade;
        }

        [HttpPost]
        public IActionResult Create([FromBody] StageInterpretCreateUpdateDto item)
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
        public IActionResult Update([FromBody] StageInterpretCreateUpdateDto item)
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

        [HttpDelete("{stageId}/{interpretId}")]
        public IActionResult Delete( Guid stageId, Guid interpretId)
        {
            try
            {
                _facade.Delete(stageId,interpretId);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }
    }
}

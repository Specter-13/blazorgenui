using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FestivalProject.BL.Facade;
using FestivalProject.BL.Models.InterpretDto;
using FestivalProject.BL.Models.StageDto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FestivalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StageController : Controller
    {
        private readonly StageFacade _facade;

        public StageController(StageFacade facade)
        {
            _facade = facade;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(_facade.GetAll());

        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var returnedItem = _facade.GetById(id);
            if (returnedItem == null) return NotFound();

            return Ok(returnedItem);

        }


        [HttpPost]
        public IActionResult Create([FromBody] StageCreateDto item)
        {
            var returnedItem = _facade.Create(item);
            if (returnedItem == null)
                return BadRequest();

            return Ok(returnedItem);


        }

        [HttpPut]
        public IActionResult Update([FromBody] StageDetailDto item)
        {
            try
            {
                return Ok(_facade.Update(item));
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            try
            {
                _facade.Delete(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }

        }
    }
}

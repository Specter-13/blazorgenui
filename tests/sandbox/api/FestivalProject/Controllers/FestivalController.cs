using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FestivalProject.BL.Facade;
using FestivalProject.BL.Models.FestivalDto;
using FestivalProject.BL.Models.InterpretDto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FestivalProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FestivalController : Controller
    {
        private readonly FestivalFacade _facade;
        private readonly ReservationFacade _reservationFacade;

        public FestivalController(FestivalFacade facade, ReservationFacade reservationFacade)
        {
            _facade = facade;
            _reservationFacade = reservationFacade;
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
            return Ok(_facade.GetById(id));
            
        }

        [HttpGet("tickets/{id}")]
        public IActionResult GetTicketsCountByFestivalId(Guid id)
        {
            try
            {
                var count = _reservationFacade.GetTicketsCountByFestivalId(id);


                return Ok(new FestivalReservationCountDto
                {
                    ReservedTickets = count
                });
            }
            catch 
            {
                return NotFound();
            }


        }

        [HttpPost]
        public IActionResult Create([FromBody] FestivalDetailDto item)
        {
            var returnedItem = _facade.Create(item);
            if (returnedItem == null)
                return BadRequest();

            return Ok(returnedItem);


        }

        [HttpPut]
        public IActionResult Update([FromBody] FestivalDetailDto item)
        {
            
                return Ok(_facade.Update(item));
           
                //return BadRequest();
            

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

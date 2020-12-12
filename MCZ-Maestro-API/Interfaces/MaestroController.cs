using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MCZ_Maestro_API.Interfaces
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaestroController : ControllerBase
    {
        private readonly IMaestroService _maestroService;

        public MaestroController(IMaestroService maestroService)
        {
            _maestroService = maestroService;
        }

        // GET: api/<MaestroController>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult List()
        {
            return Ok(_maestroService.AllCommands);
        }

        // GET api/<MaestroController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var maestrocommand = _maestroService.Find(id);

            if (maestrocommand != null)
            {
                return Ok(maestrocommand);
            }
            else
            {
                return NotFound();
            }
        }

        //// POST api/<MaestroController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<MaestroController>/1&1
        [HttpPut("{id}")]
        public void Put(int id, int value)
        {
            var maestrocommand = _maestroService.Find(id);

            if (maestrocommand != null)
            {
                _maestroService.WriteData(id, value);
            }
            else
            {
                
            }
        }

        //// DELETE api/<MaestroController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}

using Microsoft.AspNetCore.Mvc;
using Project1.Models;
using Project1.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Controllers
{
    [Route("api/[controller]")]


    public class WarningController : Controller
    {
        private IWarningRepository warningRepository;
        public WarningController(IWarningRepository warningRepository)
        {
            this.warningRepository = warningRepository;
        }
        // GET: api/warning
        [HttpGet]
        public IActionResult Get()
        {
            return new ObjectResult(warningRepository.GetAll());
        }

        // GET api/warning/"id"
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return new ObjectResult(warningRepository.GetWarning(id));
        }
        // PUT api/warning/"id"
        [HttpPut("id")]
        public IActionResult Put(int id, [FromBody]Warning value)
        {
            warningRepository.Update(value);
            return Ok();
        }
        // POST api/warning
        [HttpPost]
        public IActionResult Post([FromBody]Warning warning)
        {
            var newWarning = warningRepository.Add(warning);
            return Created("api/warning", warning);
        }

    }
}

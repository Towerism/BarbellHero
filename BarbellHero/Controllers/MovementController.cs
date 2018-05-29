using BarbellHero.Models;
using BarbellHero.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BarbellHero.Controllers
{
    [Route("api/[controller]")]
    public class MovementController : Controller
    {
        private readonly IMovementRepository _repository;

        public MovementController(IMovementRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repository.List());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Movement movement)
        {
            _repository.Create(movement);
            return Ok(movement);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return Ok(id);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int id, [FromBody] Movement movement)
        {
            _repository.Update(id, movement);
            return Ok(movement);
        }
    }
}
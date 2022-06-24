using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SuperAnimalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperAnimalController : ControllerBase
    {
      
        private readonly DataContext _context;
        public SuperAnimalController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<SuperAnimal>> Get()
        {
            
            return Ok(await _context.SuperAnimals.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperAnimal>> Get(int id)
        {
            var animal = await _context.SuperAnimals.FindAsync(id);
            if (animal == null)
            {
                return BadRequest("Animal not found");
            }
            return Ok(animal);
        }
        [HttpPost]
        public async Task<ActionResult<SuperAnimal>> PostAdd(SuperAnimal lsa)
        {
            _context.SuperAnimals.Add(lsa);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperAnimals.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<SuperAnimal>> update(SuperAnimal lsa)
        {
            var animal = await _context.SuperAnimals.FindAsync(lsa.Id);
            if (animal == null)
                return BadRequest("Animal not found");

            animal.Name = lsa.Name;
            animal.Type = lsa.Type;
            animal.Place = lsa.Place;
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperAnimals.ToListAsync());
        }
        [HttpDelete]
        public async Task<ActionResult<SuperAnimal>> delete(int id)
        {
            var animal = await _context.SuperAnimals.FindAsync(id);
            if (animal == null)
                return BadRequest("Animal not found");

            _context.SuperAnimals.Remove(animal);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperAnimals.ToListAsync());
        }
    }
}

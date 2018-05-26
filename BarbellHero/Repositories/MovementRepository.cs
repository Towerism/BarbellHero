using BarbellHero.Models;
using BarbellHero.Repositories.Interfaces;
using Mapster;
using System.Collections.Generic;
using System.Linq;

namespace BarbellHero.Repositories
{
    public class MovementRepository : IMovementRepository
    {
        private readonly BarbellHeroDbContext _context;

        public MovementRepository(BarbellHeroDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movement> List()
        {
            return _context.Movements;
        }

        public Movement GetById(int id)
        {
            return _context.Movements.SingleOrDefault(m => m.Id == id);
        }

        public void Create(Movement movement)
        {
            _context.Movements.Add(movement);
            _context.SaveChanges();
        }

        public void Update(int id, Movement movement)
        {
            var record = GetById(id);
            movement.Adapt(record);
            _context.SaveChanges();
        }
        
        public void Delete(int id)
        {
            var record = GetById(id);
            _context.Movements.Remove(record);
            _context.SaveChanges();
        }
    }
}

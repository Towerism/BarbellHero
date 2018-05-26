using System.Collections.Generic;
using BarbellHero.Models;

namespace BarbellHero.Repositories.Interfaces
{
    public interface IMovementRepository
    {
        void Create(Movement movement);
        void Delete(int id);
        Movement GetById(int id);
        IEnumerable<Movement> List();
        void Update(int id, Movement movement);
    }
}
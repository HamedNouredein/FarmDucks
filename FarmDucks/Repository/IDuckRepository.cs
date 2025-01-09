using FarmDucks.Models;

namespace FarmDucks.Repository
{
    public interface IDuckRepository
    {
        IEnumerable<Duck> GetAllDucks();
        Duck? GetDuckById(int id);
        void AddDuck(Duck duck);
        void UpdateDuck(Duck duck);
        bool DeleteDuck(int id);
    }
}

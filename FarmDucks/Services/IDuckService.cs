using FarmDucks.Models;


namespace FarmDucks.Services
{
    public interface IDuckService
    {
        IEnumerable<Duck> GetAllDucks();
        Duck? GetDuckById(int id);
        void AddDuck(Duck duck);
        void UpdateDuck(Duck duck);
        bool DeleteDuck(int id);
    }
}

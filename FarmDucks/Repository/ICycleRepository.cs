using FarmDucks.Models;

namespace FarmDucks.Repository
{
    public interface ICycleRepository
    {
        IEnumerable<Cycle> GetAllCycles();
        Cycle? GetCycleById(int id);
        void AddCycle(Cycle cycle);
        void UpdateCycle(Cycle cycle);
        bool DeleteCycle(int id);
    }
}

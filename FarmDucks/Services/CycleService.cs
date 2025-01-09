using FarmDucks.Data;
using FarmDucks.Models;
using FarmDucks.Repository;
using Microsoft.EntityFrameworkCore;

namespace FarmDucks.Services
{
    public class CycleService : ICycleService
    {
        private readonly ICycleRepository _cycleRepository;

        public CycleService(ICycleRepository cycleRepository)
        {
            _cycleRepository = cycleRepository;
        }

        public IEnumerable<Cycle> GetAllCycles()
        {
            return _cycleRepository.GetAllCycles();
        }


        public Cycle? GetCycleById(int id)
        {
            return _cycleRepository.GetCycleById(id);
        }

        public void AddCycle(Cycle cycle)
        {

            _cycleRepository.AddCycle(cycle);
        }

        public void UpdateCycle(Cycle cycle)
        {
            _cycleRepository.UpdateCycle(cycle);
        }

        public bool DeleteCycle(int id)
        {
           return _cycleRepository.DeleteCycle(id);
        }
    }
}

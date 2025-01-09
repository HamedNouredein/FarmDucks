using FarmDucks.Data;
using FarmDucks.Models;
using FarmDucks.Repository;
using Microsoft.EntityFrameworkCore;
namespace FarmDucks.Services 
{
    public class DuckService : IDuckService
    {
        private readonly IDuckRepository _duckRepository;

        public DuckService(IDuckRepository duckRepository)
        {
            _duckRepository = duckRepository;
        }

        public IEnumerable<Duck> GetAllDucks()
        {
            return _duckRepository.GetAllDucks();
        }

        public Duck? GetDuckById(int id)
        {
            return _duckRepository.GetDuckById(id);
        }

        public void AddDuck(Duck duck)
        {
           _duckRepository.AddDuck(duck);
        }

        public void UpdateDuck(Duck duck)
        {
           _duckRepository.UpdateDuck(duck);
        }

        public bool DeleteDuck(int id)
        {
           return _duckRepository.DeleteDuck(id);
        }
    }
}   

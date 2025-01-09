using FarmDucks.Data;
using FarmDucks.Models;
using FarmDucks.Repository;

public class FarmRepository : IFarmRepository
{
    private readonly ApplicationDbContext _context;

    public FarmRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Farm> GetAllFarms()
    {
        return _context.Farms.ToList();
    }

    public Farm? GetFarmById(int id)
    {
        return _context.Farms.FirstOrDefault(x => x.Id == id);
    }

    public void AddFarm(Farm farm)
    {
        _context.Farms.Add(farm);
        _context.SaveChanges();
    }

    public void UpdateFarm(Farm farm)
    {
        var existingFarm = _context.Farms.Find(farm.Id);
        if (existingFarm != null)
        {
            _context.Entry(existingFarm).CurrentValues.SetValues(farm);
            _context.SaveChanges();
        }
    }

    public bool DeleteFarm(int id)
    {
        var farm = _context.Farms.Find(id);
        if (farm != null)
        {
            _context.Farms.Remove(farm);
            _context.SaveChanges();
            return true;
        }
        return false;
    }
}

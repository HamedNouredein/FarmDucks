using FarmDucks.Models;

public interface ICycleService
{
    IEnumerable<Cycle> GetAllCycles();
    Cycle? GetCycleById(int id);
    void AddCycle(Cycle cycle);
    void UpdateCycle(Cycle cycle);
    bool DeleteCycle(int id);
}

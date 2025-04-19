using System.Collections.Generic;
using System.Threading.Tasks;
using IndoorMappingAPI.Models;

public class BeaconService : IBeaconService
{
    private readonly IBeaconRepo _repo;

    public BeaconService(IBeaconRepo repository)
    {
        _repo = repository;
    }

    public async Task<IEnumerable<Beacon>> GetFilteredAsync(string? nome, double? lat, double? lng)
    {
        var beacons = await _repo.GetAllAsync();
        var filtered = beacons.AsQueryable();

        if (!string.IsNullOrWhiteSpace(nome))
            filtered = filtered.Where(b => b.Nome.ToLower().Contains(nome.ToLower()));

        if (lat.HasValue && lng.HasValue)
            filtered = filtered.Where(b => b.Latitude != 0 && b.Longitude != 0);

        return filtered;
    }

    public async Task<List<Beacon>> GetAllAsync() => await _repo.GetAllAsync();

    public async Task<Beacon> GetByIdAsync(long id) => await _repo.GetByIdAsync(id);

    public async Task AddAsync(Beacon entity) => await _repo.AddAsync(entity);

    public async Task UpdateAsync(Beacon entity) => await _repo.UpdateAsync(entity);

    public async Task DeleteAsync(long id) => await _repo.DeleteAsync(id);
}

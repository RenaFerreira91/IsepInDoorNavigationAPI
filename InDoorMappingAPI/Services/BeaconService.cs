using AutoMapper;
using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.DTOs.PUTs;
using InDoorMappingAPI.Models;
using InDoorMappingAPI.Repos.Interfaces;
using InDoorMappingAPI.Services.Interfaces;

namespace InDoorMappingAPI.Services
{
    public class BeaconService : IBeaconService
    {
        private readonly IBeaconRepo _repo;
        private readonly IMapper _mapper;

        public BeaconService(IBeaconRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<GetBeaconDTO>> GetAllAsync()
        {
            var beacons = await _repo.GetAllAsync();
            return _mapper.Map<List<GetBeaconDTO>>(beacons);
        }

        public async Task<GetBeaconDTO> GetByIdAsync(long id)
        {
            var beacon = await _repo.GetByIdAsync(id);
            return _mapper.Map<GetBeaconDTO>(beacon);
        }

        public async Task AddAsync(PostBeaconDTO dto)
        {
            var beacon = _mapper.Map<Beacon>(dto);
            await _repo.AddAsync(beacon);
        }

        public async Task UpdateAsync(PutBeaconDTO dto)
        {
            var existing = await _repo.GetByIdAsync(dto.Id);
            if (existing == null) throw new InvalidOperationException("Beacon não encontrado.");

            _mapper.Map(dto, existing);
            await _repo.UpdateAsync(existing);
        }

        public async Task DeleteAsync(long id)
        {
            var existing = await _repo.GetByIdAsync(id);
            if (existing == null) throw new InvalidOperationException("Beacon não encontrado.");

            await _repo.DeleteAsync(id);
        }
    }
}

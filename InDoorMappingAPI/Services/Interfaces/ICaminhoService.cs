using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using InDoorMappingAPI.DTOs.PUTs.InDoorMappingAPI.DTOs.PUTs;
using InDoorMappingAPI.Models;

public interface ICaminhoService
{
    // Obtém os caminhos entre dois pontos (origem e destino), com opção de filtrar apenas os acessíveis.
    Task<List<GetCaminhoDTO>> GetCaminho(int origemId, int destinoId, bool apenasAcessiveis = false);

    // Calcula o melhor caminho acessível entre as entradas do ISEP e o destino especificado, 
    // evitando infraestruturas bloqueadas (ex: rampas).
    Task<GetMelhorCaminhoDTO> ObterMelhorCaminhoAsync(long destinoId, List<long> infraestruturasBloqueadas);

    Task<GetCaminhosDetalhadoDTO> GetAllPossiblePathsAsync(long origemId, long destinoId);
    //CRUD
    Task<List<GetCaminhoDTO>> GetAllAsync();
    Task<GetCaminhoDTO> GetByIdAsync(long id);
    Task AddAsync(PostCaminhoDTO dto);
    Task UpdateAsync(PutCaminhoDTO dto);
    Task DeleteAsync(long id);
    Task<List<GetCaminhoDetalhadoDTO>> GetAllWithDetailsAsync();
}
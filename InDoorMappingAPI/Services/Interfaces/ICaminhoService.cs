using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.Models;

public interface ICaminhoService
{
    // Obtém os caminhos entre dois pontos (origem e destino), com opção de filtrar apenas os acessíveis.
    Task<List<GetCaminhoDTO>> ObterCaminhos(int origemId, int destinoId, bool apenasAcessiveis = false);

    // Calcula o melhor caminho acessível entre as entradas do ISEP e o destino especificado, 
    // evitando infraestruturas bloqueadas (ex: rampas).
    Task<GetMelhorCaminhoDTO> ObterMelhorCaminhoAsync(long destinoId, List<long> infraestruturasBloqueadas);
}
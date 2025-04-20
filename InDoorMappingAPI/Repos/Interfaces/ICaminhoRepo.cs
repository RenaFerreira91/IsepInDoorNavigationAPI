using InDoorMappingAPI.Models;
using System.Threading.Tasks;

public interface ICaminhoRepo
{
    Task<List<Caminho>> ObterCaminhos(int origemId, int destinoId);
    Task<List<Caminho>> ObterTodosCaminhosAcessiveisAsync();
}
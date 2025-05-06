using InDoorMappingAPI.DTOs.GETs;
using InDoorMappingAPI.DTOs.POSTs;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IFeedbackCaminhoService
{
    Task<IEnumerable<GetFeedbackCaminhoDTO>> GetAllAsync();
    Task<GetFeedbackCaminhoDTO?> GetByIdAsync(long id);
    Task AddAsync(PostFeedbackCaminhoDTO dto);
    Task DeleteAsync(long id);
}

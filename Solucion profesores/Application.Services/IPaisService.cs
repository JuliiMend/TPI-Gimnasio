using DTOs;

namespace Application.Services
{
    public interface IPaisService
    {
        Task<IEnumerable<PaisDTO>> GetAllAsync();
    }
}

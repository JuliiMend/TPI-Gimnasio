using Domain.Model;

namespace Data
{
    public interface IPaisRepository
    {
        Task<IEnumerable<Pais>> GetAllAsync();
    }
}

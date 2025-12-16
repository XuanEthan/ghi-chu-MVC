using BaoCao1.Models;

namespace BaoCao1.Services
{
    public interface IGhichuService
    {
        Task<List<Ghichu>> GetAllitems();
        Task<Ghichu> GetById(long id);
        Task<long> Insert(Ghichu ghichu);
        Task<Ghichu> Update(Ghichu ghichu);
        Task<int> Delete(long id);

    }
}

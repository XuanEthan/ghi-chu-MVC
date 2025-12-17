using BaoCao1.Models;

namespace BaoCao1.Services
{
    public interface IGhichuService
    {
        Task<List<Ghichu>> GetAllitems(Ghichu_TimkiemModel filter);
        Task<ResultModel> GetById(long id);
        Task<ResultModel> Insert(Ghichu ghichu);
        Task<ResultModel> Update(Ghichu ghichu);
        Task<ResultModel> Delete(long id);

    }
}

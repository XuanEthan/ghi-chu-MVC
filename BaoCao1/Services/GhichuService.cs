using BaoCao1.Models;
using ServiceStack.OrmLite;

namespace BaoCao1.Services
{
    public class GhichuService : BaseService, IGhichuService
    {
        public async Task<List<Ghichu>> GetAllitems()
        {
            using var db = _ormLiteConnectionFactory.OpenDbConnection();
            return await db.SelectAsync<Ghichu>();
        }

        public async Task<Ghichu> GetById(long id)
        {
            using var db = _ormLiteConnectionFactory.OpenDbConnection();
            return await db.SingleByIdAsync<Ghichu>(id);
        }

        public async Task<long> Insert(Ghichu ghichu)
        {
            using var db = _ormLiteConnectionFactory.OpenDbConnection();
            var affected = await db.InsertAsync(ghichu);
            return affected;
        }

        public async Task<Ghichu> Update(Ghichu ghichu)
        {
            using var db = _ormLiteConnectionFactory.OpenDbConnection();
            await db.UpdateAsync(ghichu);
            return await GetById(ghichu.Id);
        }

        public async Task<int> Delete(long id)
        {
            using var db = _ormLiteConnectionFactory.OpenDbConnection();
            var affeced = await db.DeleteByIdAsync<Ghichu>(id);
            return affeced;
        }
    }
}

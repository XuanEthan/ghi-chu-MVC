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

        public async Task<ResultModel> Insert(Ghichu ghichu)
        {
            //using var db = _ormLiteConnectionFactory.OpenDbConnection();
            //var affected = await db.InsertAsync(ghichu);
            //if(affected <= 0)
            //{
            //    return new ResultModel(false, ResultModel.ResultCode.NotOk, ResultModel.BuildMessage(ResultModel.ResultCode.NotOk), affected);
            //}
            //return new ResultModel(true, ResultModel.ResultCode.Ok, ResultModel.BuildMessage(ResultModel.ResultCode.Ok), affected);
        }

        public async Task<ResultModel> Update(Ghichu ghichu)
        {
            //using var db = _ormLiteConnectionFactory.OpenDbConnection();
            //await db.UpdateAsync(ghichu);
            //return await GetById(ghichu.Id);
        }

        public async Task<ResultModel> Delete(long id)
        {
            //using var db = _ormLiteConnectionFactory.OpenDbConnection();
            //var affeced = await db.DeleteByIdAsync<Ghichu>(id);
            //return affeced;
        }

        public static Ghichu initEmpty()
        {
            return new Ghichu
            {
                Tieude = string.Empty,
                Noidung = string.Empty
            };
        }
    }
}

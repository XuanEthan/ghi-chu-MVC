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

        public async Task<ResultModel> GetById(long id)
        {
            using var db = _ormLiteConnectionFactory.OpenDbConnection();
            var found = db.SingleById<Ghichu>(id);
            if (found == null) { 
                return new ResultModel(false , ResultModel.ResultCode.NotOk , ResultModel.BuildMessage(ResultModel.ResultCode.Ok));
            }
            return new ResultModel(true, ResultModel.ResultCode.Ok, ResultModel.BuildMessage(ResultModel.ResultCode.Ok), found.Id , found);
        }

        public async Task<ResultModel> Insert(Ghichu ghichu)
        {
            using var db = _ormLiteConnectionFactory.OpenDbConnection();
            // validate logic ...
            var newNote = initEmpty();
            newNote.Id = ghichu.Id;
            newNote.Tieude = string.IsNullOrEmpty(ghichu.Tieude) ? "" : ghichu.Tieude;
            newNote.Noidung = string.IsNullOrEmpty(ghichu.Noidung) ? "" : ghichu.Noidung;

            await db.InsertAsync(newNote);
            return new ResultModel(true , ResultModel.ResultCode.Ok , ResultModel.BuildMessage(ResultModel.ResultCode.Ok));
        }

        public async Task<ResultModel> Update(Ghichu ghichu)
        {
            using var db = _ormLiteConnectionFactory.OpenDbConnection();
            var found = db.SingleById<Ghichu>(ghichu.Id);
            if (found == null) { return new ResultModel(false, ResultModel.ResultCode.NotOk, ResultModel.BuildMessage(ResultModel.ResultCode.NotOk)); }
            found.Tieude = ghichu.Tieude;
            found.Noidung = ghichu.Noidung;
            await db.UpdateAsync(found);
            return new ResultModel(true , ResultModel.ResultCode.Ok , ResultModel.BuildMessage (ResultModel.ResultCode.Ok) , found.Id , found);
        }

        public async Task<ResultModel> Delete(long id)
        {
            using var db = _ormLiteConnectionFactory.OpenDbConnection();
            var found = db.SingleById<Ghichu>(id);
            if (found == null) {
                return new ResultModel(false, ResultModel.ResultCode.Khong_ton_tai, ResultModel.BuildMessage(ResultModel.ResultCode.Khong_ton_tai));
            }
            await db.DeleteAsync<Ghichu>(found);
            return new ResultModel(true , ResultModel.ResultCode.Ok , ResultModel.BuildMessage(ResultModel.ResultCode.Ok), id , found.Id);
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

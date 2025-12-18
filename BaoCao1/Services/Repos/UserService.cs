using BaoCao1.Models;
using BaoCao1.Services.Utils;
using ServiceStack.OrmLite;

namespace BaoCao1.Services.Repos
{
    public class UserService : BaseService, IUserService
    {
        public async Task<ResultModel> Login(User_RegisterModel user_Register)
        {
            var db = _ormLiteConnectionFactory.OpenDbConnection();
            var hashedPassword = CryptUtil.MD5Hash(user_Register.Password);
            var query = db.From<User>().Where(u => u.UserName == user_Register.UserName && u.HashedPassword == hashedPassword);
            var user = await db.SingleAsync(query);
            if(user == null)
            {
                return new ResultModel(false, ResultModel.ResultCode.Tai_khoan_hoac_mat_khau_khong_dung, ResultModel.BuildMessage(ResultModel.ResultCode.Tai_khoan_hoac_mat_khau_khong_dung));
            }
            return new ResultModel(true, ResultModel.ResultCode.Ok, ResultModel.BuildMessage(ResultModel.ResultCode.Ok), user.Id, user);
        }

        public async Task<ResultModel> Register(User_RegisterModel user_Register)
        {
            using var db = _ormLiteConnectionFactory.OpenDbConnection();
            var query =  db.From<User>().Where(u => u.UserName == user_Register.UserName);
            var isExist = await db.SingleAsync(query);
            if (isExist != null)
            {
                return new ResultModel(false, ResultModel.ResultCode.Ten_Tai_khoan_da_dc_su_dung, ResultModel.BuildMessage(ResultModel.ResultCode.Ten_Tai_khoan_da_dc_su_dung));
            }
            var user = new User
            {
                UserName = user_Register.UserName,
                HashedPassword = CryptUtil.MD5Hash(user_Register.Password)
            };

            await db.InsertAsync(user);
            return new ResultModel(true, ResultModel.ResultCode.Ok, ResultModel.BuildMessage(ResultModel.ResultCode.Ok));
        }
    }
}

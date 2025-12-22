using BaoCao1.Models;
using BaoCao1.Services.Utils;
using ServiceStack.OrmLite;

namespace BaoCao1.Services.Repos
{
    public class UserService : BaseService, IUserService
    {
        public async Task<ResultModel> Login(User_LoginModel user_Login)
        {
            var db = _ormLiteConnectionFactory.OpenDbConnection();
            if(string.IsNullOrEmpty(user_Login.UserName) || string.IsNullOrEmpty(user_Login.Password))
            {
                return new ResultModel(false, ResultModel.ResultCode.Tai_khoan_hoac_mat_khau_khong_duoc_de_trong, ResultModel.BuildMessage(ResultModel.ResultCode.Tai_khoan_hoac_mat_khau_khong_duoc_de_trong));
            }

            var hashedPassword = CryptUtil.MD5Hash(user_Login.Password);
            var query = db.From<User>().Where(u => u.UserName == user_Login.UserName && u.HashedPassword == hashedPassword);
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
            if(string.IsNullOrEmpty(user_Register.UserName) || string.IsNullOrEmpty(user_Register.Password) || string.IsNullOrEmpty(user_Register.ConfirmPassword))
            {
                return new ResultModel(false, ResultModel.ResultCode.Tai_khoan_hoac_mat_khau_khong_duoc_de_trong, ResultModel.BuildMessage(ResultModel.ResultCode.Tai_khoan_hoac_mat_khau_khong_duoc_de_trong));
            }
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

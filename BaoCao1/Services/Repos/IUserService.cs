using BaoCao1.Models;

namespace BaoCao1.Services.Repos
{
    public interface IUserService
    {
        Task<ResultModel> Login(User_RegisterModel user_Register);
        Task<ResultModel> Register(User_RegisterModel user_Register);
    }
}

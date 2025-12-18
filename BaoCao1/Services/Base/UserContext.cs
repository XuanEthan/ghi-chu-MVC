using DevExpress.Xpo;

namespace BaoCao1.Services.Base
{
    public class UserContext
    {
        public static void setUserId(long userId, HttpContext httpContext)
        {
            httpContext.Session.SetString("UserId", userId.ToString());
        }

        public static long getUserId(HttpContext httpContext)
        {
            var userId = httpContext.Session.GetString("UserId");
            if (userId != null)
            {
                return long.Parse(userId);
            }
            return 0;
        }
    }
}

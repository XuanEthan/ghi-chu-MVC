using ServiceStack.DataAnnotations;

namespace BaoCao1.Models
{
    [Alias("User")]
    public class User
    {
        [AutoIncrement]
        public long Id { get; set; }

        public string UserName { get; set; }

        public string HashedPassword { get; set; }
    }

    public class User_RegisterModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class  User_LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class User_TimkiemModel
    {
    }
}

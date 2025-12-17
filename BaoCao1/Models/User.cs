using ServiceStack.DataAnnotations;

namespace BaoCao1.Models
{
    [Alias("User")]
    public class User
    {
        [AutoIncrement]
        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

    }
}

using ServiceStack.DataAnnotations;
using System.Diagnostics.Contracts;

namespace BaoCao1.Models
{
    [Alias("ghichu")]
    public class Ghichu
    {
        [AutoIncrement]
        public long Id { get; set; }
        public string? Tieude { get; set; } = string.Empty;
        public string? Noidung { get; set; } = string.Empty;
    }

    public class Ghichu_TimkiemModel
    {
        public string? search { get; set; }
    }

}

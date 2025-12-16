using ServiceStack.DataAnnotations;

namespace BaoCao1.Models
{
    [Alias("ghichu")]
    public class Ghichu
    {
        [AutoIncrement]
        public long Id { get; set; }
        public string Tieude { get; set; } = "Tieu de";
        public string Noidung { get; set; } = "Ghi chu";
    }
}

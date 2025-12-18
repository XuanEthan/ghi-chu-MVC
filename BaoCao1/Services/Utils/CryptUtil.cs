using System.Security.Cryptography;

namespace BaoCao1.Services.Utils
{
    public class CryptUtil
    {
        public static string MD5Hash(string input)
        {
            using var md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            string encoded = BitConverter.ToString(hashBytes).Replace("-", string.Empty).ToLower();
            return encoded;
        }

    }
}

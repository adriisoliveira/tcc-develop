using System.Security.Cryptography;
using System.Text;

namespace APIController.Helpers
{
    public static class StringHelper
    {
        public static string CreateMD5(string value)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] valueBytes = Encoding.ASCII.GetBytes(value);
                byte[] hashBytes = md5.ComputeHash(valueBytes);

                StringBuilder result = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                    result.Append(hashBytes[i].ToString("X2"));

                return result.ToString();
            }
        }
    }
}

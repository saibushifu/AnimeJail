using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AnimeJail.App.Methods
{
    public class CryptoFunc
    {
        public static string QuickHash(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes("ANIME" + input + "JP");
            var inputHash = SHA256.HashData(inputBytes);
            return Convert.ToHexString(inputHash);
        }
    }
}

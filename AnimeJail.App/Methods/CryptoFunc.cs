using System.Security.Cryptography;
using System.Text;

namespace AnimeJail.App.Methods;

public class CryptoFunc
{
    public static string QuickHash(string input)
    {
        var inputBytes = Encoding.UTF8.GetBytes("ANIME" + input + "JP");
        var inputHash = SHA256.HashData(inputBytes);
        return Convert.ToHexString(inputHash);
    }
}

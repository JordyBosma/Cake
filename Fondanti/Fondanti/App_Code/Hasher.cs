using System.Security.Cryptography;
using System.Text;
using System.IO;

/// <summary>
/// SHA Encrypt password hasher
/// </summary>
public class Hasher
{
    public static string GenerateSHA512String(string input)
    {
        SHA512 sha512 = SHA512Managed.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(input);
        byte[] hash = sha512.ComputeHash(bytes);

        return GetStringFromHash(hash);
    }

    public string RandomKey()
    {
        string path = Path.GetRandomFileName();
        path = path.Replace(".", "");
        string key = GenerateSHA512String(path);

        return key;
    }

    private static string GetStringFromHash(byte[] hash)
    {
        StringBuilder result = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            result.Append(hash[i].ToString("X2"));
        }

        return result.ToString();
    }
}
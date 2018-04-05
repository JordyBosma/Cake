using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;
/// <summary>
/// SHA-Encrypts the password that was entered by the user.
/// </summary>
public class SHAGenerate
{
    public static string GenerateSHAString(string input)
    {
        SHA512 sha512 = SHA512Managed.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(input);
        byte[] hash = sha512.ComputeHash(bytes);
        return GetStringFromHash(hash);
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

using System.Security.Cryptography;

namespace Shared.Core.Extensions;

/// <summary>
/// Hasher extension
/// </summary>
public static class HasherExtension
{
    /// <summary>
    /// Hash string
    /// </summary>
    /// <param name="str">String</param>
    /// <param name="salt">Salt</param>
    /// <returns></returns>
    public static string HashString(string str, string salt = "SaltString")
    {
        if (string.IsNullOrEmpty(str))
            return string.Empty;
        return BitConverter
            .ToString(SHA256.HashData(System.Text.Encoding.UTF8.GetBytes(str + salt)))
            .Replace("-", string.Empty);
    }
}
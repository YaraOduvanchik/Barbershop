using System.Security.Cryptography;
using System.Text;

namespace Barbershop.Services.Helpers;

internal static class HashService
{
    public static string Compute(string value)
    {
        ArgumentNullException.ThrowIfNull(value);

        var bytes = new UTF8Encoding().GetBytes(value);

        byte[] hashBytes = SHA512.HashData(bytes);

        return Convert.ToBase64String(hashBytes);
    }
}

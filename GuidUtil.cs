using System.Buffers.Text;
using System.Runtime.InteropServices;

namespace StringCoversionBenchmark;

public static class GuidUtil
{
    private const char EqualsChar = '=';
    private const string EqualsStr = "=";
    private const char Slash = '/';
    private const char Underscore = '_';
    private const char Plus = '+';
    private const char Hyphen = '-';
    
    private const byte EqualsByte = (byte)'=';
    private const byte SlashByte = (byte)'/';
    private const byte UnderscoreByte = (byte)'_';
    private const byte PlusByte = (byte)'+';
    private const byte HyphenByte = (byte)'-';

    public static string ToStringFromGuid(Guid id)
    {
        return Convert.ToBase64String(id.ToByteArray())
            .Replace(Slash, Hyphen)
            .Replace(Plus, Underscore)
            // base 64 string length is fixed last 2 chars (==) are placeholders.
            .Replace(EqualsStr, string.Empty);
    }

    public static string ToStringFromGuidOptimized(Guid id)
    {
        Span<byte> idBytes = stackalloc byte[16];
        Span<byte> base64Bytes = stackalloc byte[24];

        MemoryMarshal.TryWrite(idBytes, ref id);
        Base64.EncodeToUtf8(idBytes, base64Bytes, out _, out _);

        Span<char> result = stackalloc char[22];
        // 22 bytes coming in from the base 64 string
        for (int i = 0; i < 22; i++)
        {
            result[i] = base64Bytes[i] switch
            {
                SlashByte => Hyphen,
                PlusByte => Underscore,
                _ => (char)base64Bytes[i]
            };
        }
        
        return new string(result);
    }

    public static Guid ToGuidFromString(string id)
    {
        var base64char = Convert.FromBase64String(id
            .Replace(Hyphen, Slash)
            .Replace(Underscore, Plus)
            // base 64 string length is fixed last 2 chars (==) are placeholders.
            + EqualsChar + EqualsChar);

        return new Guid(base64char);
    }

    // Implicit string conversion.
    public static Guid ToGuidFromStringOptimized(ReadOnlySpan<char> id)
    {
        // stack object
        Span<char> base64Chars = stackalloc char[24];

        // 22 bytes coming in from the base 64 string
        for (int i = 0; i < 22; i++)
        {
            base64Chars[i] = id[i] switch
            {
                Hyphen => Slash,
                Underscore => Plus,
                _ => id[i]
            };
        }

        base64Chars[22] = EqualsChar;
        base64Chars[23] = EqualsChar;

        Span<byte> idBytes = stackalloc byte[16];
        Convert.TryFromBase64Chars(base64Chars, idBytes, out _); // out _); toss out last char because we don't need it.
        
        return new Guid(idBytes);
    }
}
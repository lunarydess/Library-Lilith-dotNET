using System.Globalization;

namespace Lilith.Utility;

public class StringKit {
    #region Password
    private static readonly Random Random = new();

    public static string Password(
        int  length,
        bool lower,
        bool upper,
        bool number,
        bool special
    ) {
        string[] categories = new string[4];

        int index                        = 0;
        if (lower) categories[index++]   = LowerChars;
        if (upper) categories[index++]   = UpperChars;
        if (number) categories[index++]  = NumberChars;
        if (special) categories[index++] = SpecialChars;

        string password = "";
        for (int i = 0 ; i < length ; i++) {
            string charCategory = categories[Random.Next(maxValue: index)];
            password += charCategory.ToCharArray()[Random.Next(maxValue: charCategory.Length)];
        }

        return password;
    }
    #endregion

    #region Bytes
    /* ISO/IEC 80000-13 standard */
    private static readonly string[] ByteUnits = { "B", "kiB", "MiB", "GiB", "TiB", "PiB", "EiB", "ZiB", "YiB" };
    private static readonly NumberFormatInfo ByteFormat = new() { NumberGroupSeparator = ",", NumberDecimalDigits = 2 };

    public static string FormatBytes(in double size) {
        int unitIndex = (int) (Math.Log(d: size) / Math.Log(d: 1024));

        unitIndex = unitIndex < 0                    ? 0 :
                    unitIndex > ByteUnits.Length - 1 ? ByteUnits.Length - 1 : unitIndex;

        return
        $"{(size / Math.Pow(x: 1024, y: unitIndex)).ToString("#,##0.##", provider: ByteFormat)} {ByteUnits[unitIndex]}";
    }
    #endregion

    #region Chars
    private const string UpperChars   = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private const string LowerChars   = "abdcefghijklmnopqrstuvwxyz";
    private const string SpecialChars = "!@#$%&*()_+-=[]|,./\\?><";
    private const string NumberChars  = "0123456789";

    public static string GetUpperChars()   => UpperChars;
    public static string GetLowerChars()   => UpperChars;
    public static string GetSpecialChars() => UpperChars;
    public static string GetNumberChars()  => UpperChars;
    #endregion
}
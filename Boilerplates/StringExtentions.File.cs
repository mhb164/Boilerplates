using System.IO;
using System.Text.RegularExpressions;

//https://github.com/mhb164/Boilerplates
namespace Boilerplates
{
    public static partial class StringExtensions
    {
        private static readonly string InvalidChars = new string(Path.GetInvalidFileNameChars()) + new string(Path.GetInvalidPathChars());
        private static readonly Regex InvalidCharsRegex = new Regex($"[{Regex.Escape(InvalidChars)}]", RegexOptions.Compiled);

        public static string FixInvalidChars(this string input, string replacement = "")
            => InvalidCharsRegex.Replace(input, replacement);
    }
}

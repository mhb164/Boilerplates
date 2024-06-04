using System.Collections.Generic;
using System.Linq;

//https://github.com/mhb164/Boilerplates
namespace Boilerplates
{
    public static partial class StringExtensions
    {
        public static bool IsNothing(this string input)
            => string.IsNullOrWhiteSpace(input);

        public static bool IsNotNothing(this string input)
            => !string.IsNullOrWhiteSpace(input);

        public static string Join(this IEnumerable<string> items, string separator = "")
            => string.Join(separator, items);

        public static string Join<T>(this IEnumerable<T> items, string separator = "")
            => string.Join(separator, items);

        public static string ToHexString(this IEnumerable<byte> input, string prefix = "", string separator = "")
            => input.Select(x => $"{prefix}{x:X2}").Join(separator);
    }
}

using System.Linq;
using System.Text;

//https://github.com/mhb164/Boilerplates
namespace Boilerplates
{
    public static partial class StringExtensions
    {
        private const string JSON_INDENT_STRING = "    ";
        public static string PrettifyJson(this string jsonText, string indentText = JSON_INDENT_STRING)
        {
            var indent = 0;
            var quoted = false;
            var sb = new StringBuilder();
            for (var i = 0; i < jsonText.Length; i++)
            {
                var ch = jsonText[i];
                switch (ch)
                {
                    case '{':
                    case '[':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            foreach (var item in Enumerable.Range(0, ++indent)) sb.Append(indentText);
                        }
                        break;
                    case '}':
                    case ']':
                        if (!quoted)
                        {
                            sb.AppendLine();
                            foreach (var item in Enumerable.Range(0, --indent)) sb.Append(indentText);
                        }
                        sb.Append(ch);
                        break;
                    case '"':
                        sb.Append(ch);
                        bool escaped = false;
                        var index = i;
                        while (index > 0 && jsonText[--index] == '\\')
                            escaped = !escaped;
                        if (!escaped)
                            quoted = !quoted;
                        break;
                    case ',':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            foreach (var item in Enumerable.Range(0, indent)) sb.Append(indentText);
                        }
                        break;
                    case ':':
                        sb.Append(ch);
                        if (!quoted)
                            sb.Append(' ');
                        break;
                    default:
                        sb.Append(ch);
                        break;
                }
            }
            return sb.ToString();
        }
    }
}
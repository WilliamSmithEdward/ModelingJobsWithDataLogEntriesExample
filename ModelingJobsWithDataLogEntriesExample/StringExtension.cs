using System.Globalization;
using System.Text;

namespace ModelingJobsWithDataLogEntriesExample
{
    internal static class StringExtension
    {
        public static string ToCamelCase(this string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            var words = s.Split(new[] { ' ', '-', '_' }, StringSplitOptions.RemoveEmptyEntries);
            var result = new StringBuilder();

            // Add the first word as is (in lowercase)
            result.Append(words[0].ToLower(CultureInfo.InvariantCulture));

            // Capitalize the first letter of the remaining words
            for (int i = 1; i < words.Length; i++)
            {
                var word = words[i];
                if (!string.IsNullOrEmpty(word))
                {
                    result.Append(char.ToUpper(word[0], CultureInfo.InvariantCulture) + word.Substring(1).ToLower(CultureInfo.InvariantCulture));
                }
            }

            return result.ToString();
        }

        public static string ToPascalCase(this string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            var words = s.Split(new[] { ' ', '-', '_' }, StringSplitOptions.RemoveEmptyEntries);
            var result = new StringBuilder();

            // Capitalize the first letter of every word
            foreach (var word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    result.Append(char.ToUpper(word[0], CultureInfo.InvariantCulture) + word.Substring(1).ToLower(CultureInfo.InvariantCulture));
                }
            }

            return result.ToString();
        }
    }
}

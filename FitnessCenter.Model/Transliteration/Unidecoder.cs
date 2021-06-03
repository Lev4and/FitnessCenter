using System.Linq;
using System.Text;

namespace FitnessCenter.Model.Transliteration
{
    public static partial class Unidecoder
    {
        public static string Unidecode(this string input, int? tempStringBuilderCapacity = null)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "";
            }

            if (input.All(x => x < 0x80))
            {
                return input;
            }


            var sb = new StringBuilder(tempStringBuilderCapacity ?? input.Length * 2);
            foreach (char c in input)
            {
                if (c < 0x80)
                {
                    sb.Append(c);
                }
                else
                {
                    int high = c >> 8;
                    int low = c & 0xff;
                    string[] transliterations;
                    if (characters.TryGetValue(high, out transliterations))
                    {
                        sb.Append(transliterations[low]);
                    }
                }
            }

            return sb.ToString();
        }

        public static string Unidecode(this char c)
        {
            string result;
            if (c < 0x80)
            {
                result = new string(c, 1);
            }
            else
            {
                int high = c >> 8;
                int low = c & 0xff;
                string[] transliterations;
                if (characters.TryGetValue(high, out transliterations))
                {
                    result = transliterations[low];
                }
                else
                {
                    result = "";
                }
            }

            return result;
        }
    }
}
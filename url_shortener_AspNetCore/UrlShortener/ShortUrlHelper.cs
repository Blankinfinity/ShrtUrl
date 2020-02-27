using System;
using System.Linq;
using System.Text;

namespace UrlShortenerLib
{
    /// <summary>
    /// Bidirective conversion between natural numbers (int or IDs) and short strings
    /// </summary>
    public class ShortUrlHelper
    {

        private const string Alphabet = "23456789bcdfghjkmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ-_";
        private static readonly int Base = Alphabet.Length;

        // Encode() takes an int and turns it into a short string 
        public static string Encode(int num)
        {
            if (num == 0)
                return Alphabet[0].ToString();
            var s = string.Empty;
            while (num > 0)
            {
                s += Alphabet[num % Base];
                num = num / Base;
            }

            return string.Join(string.Empty, s.Reverse());
        }

        // Decode() takes a short string and turns it into an int
        public static int Decode(string str)
        {
            var num = 0;
            for (var i = 0; i < str.Length; i++)
            {
                num = num * Base + Alphabet.IndexOf(str.ElementAt(i));
            }
            return num;
        }
    }
}

using System;
using System.Linq;

namespace ReverseVowels
{
    /// <summary>
    /// Extension methods for char
    /// </summary>
    public static class CharExtensions
    {
        private static char[] vowels = { 'a', 'e', 'i', 'o', 'u' };

        /// <summary>
        /// Evaluates if a char value is vowel
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool IsVowel(this char c)
        {
            return vowels.Contains(c.ToString().ToLower()[0]);
        }
    }
}

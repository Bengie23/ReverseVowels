using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseVowels
{
    /// <summary>
    /// Returns a given string with reversed vowels.
    /// </summary>
    public class ReverseVowelsResolver
    {
        private Stack<char> vowelsFound = new Stack<char>();
        private string stringToEvaluate;

        private ReverseVowelsResolver(string stringParameter)
        {
            if (stringParameter is null)
            {
                throw new ArgumentNullException();
            }

            stringToEvaluate = stringParameter;
        }

        private string TryResolve()
        {
            char[] arrayOfChar = stringToEvaluate.ToCharArray();

            if (!arrayOfChar.Where(x => EvaluateIsVowelAndStore(x)).ToArray().Any()) {
                return new string(arrayOfChar);
            }

            var result = arrayOfChar.Select(x =>
             {
                 if (x.IsVowel())
                 {
                     return vowelsFound.Pop();
                 }
                 else
                 {
                     return x;
                 }
             }).ToArray();

            return new string(result);
        }

        private bool EvaluateIsVowelAndStore(char c)
        {
            bool isVowel = c.IsVowel();
            if (isVowel)
            {
                vowelsFound.Push(c);
            }
            return isVowel;
        }

        /// <summary>
        /// Entry point for resolver. Creates a new instance of resolver and returns the resolved value.
        /// </summary>
        /// <param name="stringParameter"></param>
        /// <returns></returns>
        public static string Resolve(string stringParameter)
        {
            var resolvable = new ReverseVowelsResolver(stringParameter);

            return resolvable.TryResolve();
        }
    }
}

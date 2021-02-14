using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReverseVowels
{
    public class ReverseVowelsResolver
    {
        private Stack<char> vowelsFound = new Stack<char>();
        private string stringToEvaluate;
        private char[] vowels = { 'a','e','i','o','u' };

        internal ReverseVowelsResolver(string stringParameter)
        {
            if (stringParameter is null)
            {
                throw new ArgumentNullException();
            }

            this.stringToEvaluate = stringParameter;
        }

        internal string TryResolve()
        {
            char[] arrayOfChar = stringToEvaluate.ToCharArray();

            if (!arrayOfChar.Where(x => EvaluateIsVowelAndStore(x)).ToArray().Any()) {
                return new string(arrayOfChar);
            }


            var result = arrayOfChar.Select(x =>
             {
                 if (IsVowel(x))
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

        internal bool EvaluateIsVowelAndStore(char c)
        {
            bool isVowel = IsVowel(c);
            if (isVowel)
            {
                vowelsFound.Push(c);
            }
            return isVowel;
        }

        internal bool IsVowel(char c)
        {
            char value = c.ToString().ToLower()[0];
            return vowels.Contains(value);

            
        }

        public static string Resolve(string stringParameter)
        {
            var resolvable = new ReverseVowelsResolver(stringParameter);

            return resolvable.TryResolve();

        }
    }
}

using System;
using System.Collections.Generic;

namespace ReverseVowels
{
    /// <summary>
    /// Returns a given string with reversed vowels.
    /// </summary>
    public class RecursiveReverseVowelsResolver
    {
        private Queue<char> vowelsFound = new Queue<char>();
        private string result = "";
        private string DoResolve(string stringParameter)
        {
            if (stringParameter != null && stringParameter.Length > 0)
            {
                return ResolveStep(stringParameter);
            }

            return stringParameter;
        }

        private string ResolveStep(string input,int pos=0)
        {
            char charToEvaluate = input[pos];

            if (charToEvaluate.IsVowel())
            {
                vowelsFound.Enqueue(charToEvaluate);
            }

            if (input.Length > pos + 1)
            {
                ResolveStep(input, ++pos);
            }

            result = (charToEvaluate.IsVowel() ? vowelsFound.Dequeue().ToString() : charToEvaluate.ToString()) + result;

            return result;
        }

        /// <summary>
        /// Entry point for resolver. Creates a new instance of resolver and returns the resolved value.
        /// </summary>
        /// <param name="stringParameter"></param>
        /// <returns></returns>
        public static string Resolve(string stringParameter)
        {
            if (stringParameter is null)
            {
                throw new ArgumentNullException();
            }

            var obj = new RecursiveReverseVowelsResolver();
            return obj.DoResolve(stringParameter);
        }
    }
}

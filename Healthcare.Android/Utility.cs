using Microsoft.FSharp.Core;
using System;
using System.Text;

namespace Healthcare.Android
{
    static class Utility
    {
        public static bool IsSome<T>(this FSharpOption<T> option) => FSharpOption<T>.get_IsSome(option);
        public static bool IsNone<T>(this FSharpOption<T> option) => FSharpOption<T>.get_IsNone(option);

        public static string LoremIpsum(int minWords, int maxWords,
                                 int minSentences, int maxSentences,
                                 int numParagraphs)
        {

            var words = new[] {"lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
                               "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
                               "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"};

            var rand = new Random();
            var numSentences = rand.Next(maxSentences - minSentences) + minSentences + 1;
            var numWords = rand.Next(maxWords - minWords) + minWords + 1;

            var result = new StringBuilder();

            for (int p = 0; p < numParagraphs; p++)
            {
                result.Append("<p>");
                for (int s = 0; s < numSentences; s++)
                {
                    for (int w = 0; w < numWords; w++)
                    {
                        if (w > 0) { result.Append(" "); }
                        result.Append(words[rand.Next(words.Length)]);
                    }
                    result.Append(". ");
                }
                result.Append("</p>");
            }

            return result.ToString();
        }
    }
}
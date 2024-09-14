using System;

namespace eKadenceHomework;

public static class StringExtensions
{
    public static int AverageNumberOfLettersPerWord(
        this string rawSentence,
        Func<string, bool> matchedCondition
    )
    {
        if (string.IsNullOrEmpty(rawSentence))
        {
            return -1;
        }

        var sentence = rawSentence.Trim();

        var qualifiedWords = sentence.GetWords().Where(matchedCondition);

        var totalWords = qualifiedWords.Count();
        if (totalWords == 0)
        {
            return 0;
        }

        var totalLetters = qualifiedWords.Aggregate(
            0,
            (accummulation, currentWord) => accummulation + currentWord.Length
        );

        return (int)Math.Floor((double)totalLetters / totalWords);
    }

    public static IEnumerable<string> GetWords(this string sentence)
    {
        if (string.IsNullOrEmpty(sentence))
        {
            return [];
        }

        var punctuations = sentence
            .Where(char.IsPunctuation) // Filter to get only the characters that are punctuation
            .Distinct() // Get the unique punctuations only
            .ToArray();

        var words = sentence.Split(); // Split using the default delimiter as white space

        return punctuations.Length == 0
            ? words // Return the current words
            : words.Select(x => x.Trim(punctuations));
        // Transform every word to removes all leading and trailing punctuation in the 'punctuations' set.
    }
}

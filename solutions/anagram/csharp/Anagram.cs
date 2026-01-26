using System;
using System.Linq;

public class Anagram
{
    private readonly string subject;
    private readonly char[] baseLetters;

    public Anagram(string baseWord)
    {
        subject = baseWord.ToLower();
        baseLetters = Sorted(subject);
    }

    public string[] FindAnagrams(string[] potentialMatches) =>
        // returns all candidates that are anagrams of, but not equal to, 'subject'
        [.. potentialMatches.Where(word =>
        {
            if (word.Length != subject.Length) return false;

            var candidate = word.ToLower();
            if (candidate == subject) return false;

            return Sorted(candidate).SequenceEqual(baseLetters);
        })];

    private static char[] Sorted(string input)
    {
        var letters = input.ToCharArray();
        Array.Sort(letters);
        return letters;
    }
}
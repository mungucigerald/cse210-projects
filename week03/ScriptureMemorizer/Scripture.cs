using System;
using System.Collections.Generic;
using System.Linq;

// Represents a scripture: the Reference and the text of words.
// Holds logic for hiding words and displaying the current scripture.
// Displays the scripture with hidden words replaced by underscores.
public class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random = new Random();

    // Constructor that takes a Reference and the text of the scripture.
    // Splits the text into words and creates a list of Word objects.
    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    // Hides a random number of words in the scripture.
    // The number of words to hide is determined by the numberToHide parameter.
    public void HideRandomWords(int numberToHide)
    {
        List<int> availableIndices = Enumerable.Range(0, _words.Count).Where(i => !_words[i].IsHidden()).ToList();

        for (int i = 0; i < numberToHide && availableIndices.Count > 0; i++)
        {
            int randomIndex = _random.Next(availableIndices.Count);
            int wordIndex = availableIndices[randomIndex];
            _words[wordIndex].Hide();
            // Remove the index from availableIndices to avoid hiding the same word again
            availableIndices.RemoveAt(randomIndex);
        }
    }

    // Returns true if all words in the scripture are hidden, otherwise false.
    public bool AllWordsHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    // Returns the display text of the scripture, including the reference and the current state of the words (hidden or visible).
    public string GetDisplayText()
    {
        string scriptureText = string.Join(" ", _words.Select(word => word.GetDisplayText()));
        return _reference.GetDisplayText() + "\n\n" + scriptureText;
    }

    // Reveals a random hidden word in the scripture. Helps the user by providing a hint. 
    // Returns true if a word was revealed, otherwise false if all words are already visible.
    public bool RevealHint()
    {
        List<int> hiddenIndices = Enumerable.Range(0, _words.Count).Where(i => _words[i].IsHidden()).ToList();
        if (hiddenIndices.Count == 0)
        {
            return false; // No hidden words to reveal
        }

        int randomIndex = _random.Next(hiddenIndices.Count);
        _words[hiddenIndices[randomIndex]].Show();
        return true;
    }

}
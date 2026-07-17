using System;

public class Word
{
    // Instance variables to hold the text of the word and its hidden state.
    private string _text;
    private bool _isHidden;

    // Constructor that initializes the word with the given text and sets it as not hidden.
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    // Hides the word by setting its hidden state to true.
    public void Hide()
    {
        _isHidden = true;
    }

    // Shows the word by setting its hidden state to false.
    public void Show()
    {
        _isHidden = false;
    }

    // Returns true if the word is hidden, otherwise false.
    public bool IsHidden()
    {
        return _isHidden;
    }

    // Returns the display text of the word. If the word is hidden, it returns underscores instead of the actual text.
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }
}
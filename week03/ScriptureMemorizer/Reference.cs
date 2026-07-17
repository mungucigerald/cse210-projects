using System;

public class Reference
{
    // Instance variables to hold the book, chapter, verse, and optional end verse of the scripture reference.
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    // Constructor that initializes the reference with the given book, chapter, and verse. The end verse is optional and defaults to 0 if not provided.
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = 0; // Default value for end verse
    }

    // Represents a scripture reference with a book, chapter, verse, and optional end verse.
    // Constructor that initializes the reference with the given book, chapter, verse, and end verse.
    // Not involved scripture's actual text, it only formats the reference for display purposes.
    // Two constructors are provided: one for a single verse and another for a range of verses.
    public Reference(string book, int chapter, int verse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = endVerse;
    }

    // Format the reference as a string for display purposes.
    //  If the end verse is 0, it returns the reference in the format "Book Chapter:Verse". 
    // If the end verse is provided, it returns the reference in the format "Book Chapter:Verse-EndVerse".
    public string GetDisplayText()
    {
        if (_endVerse == 0)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
}
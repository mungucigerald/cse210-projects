using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

public class ScriptureLibrary
{
    private List<(Reference reference, string text)> _scriptures = new List<(Reference reference, string text)>();
    private Random _random = new Random();

    public ScriptureLibrary(string filePath)
    {
        LoadScripturesFromFile(filePath);
    }

    private void LoadScripturesFromFile(string filePath)
    {
        foreach (string line in File.ReadAllLines(filePath))
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue; // Skip empty lines
            }

            string[] parts = line.Split('|');
            string book = parts[0].Trim();
            int chapter = int.Parse(parts[1].Trim());
            int verse = int.Parse(parts[2].Trim());
            string text = parts[4].Trim();

            Reference reference = string.IsNullOrWhiteSpace(parts[3])
                ? new Reference(book, chapter, verse)
                : new Reference(book, chapter, verse, int.Parse(parts[3].Trim()));

            _scriptures.Add((reference, text));
        }
    }

    public Scripture GetRandomScripture()
    {
        var scripture = _scriptures[_random.Next(_scriptures.Count)];
        return new Scripture(scripture.reference, scripture.text);
    }
    
    public int Count => _scriptures.Count;
}
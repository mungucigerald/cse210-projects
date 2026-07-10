using System;

public class Journal
{
    // Initialize member variables
    // List of all entries currently added in the Journal
    public List<Entry> _entries = new List<Entry>();

    // Initialize member methods
    // Adds a new entry to journal
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    // Prints every entry in the journal to the output
    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    // Writes all entries into a CSV file with a header row for Excel compatibility
    public void SaveToFile(string filename)
    {
        using (StreamWriter outputFile = new(filename))
        {
            // Insert header row
            outputFile.WriteLine("Date,Time,Prompt,Response");
            foreach (Entry entry in _entries)
            {
                outputFile.WriteLine(entry.GetSaveString());
            }
        }
    }

    // Reads entries from a CSV five and replacing all that is currently laoded 
    public void LoadFromFile(string filename)
    {
        // Clear the current journal before loading saved journal
        _entries.Clear();

        string[] lines = File.ReadAllLines(filename);

        // Index starts from 1 to skip the header row added when file was saved
        for (int i = 1; i < lines.Length; i++)
        {
            List<string> parts = CsvHelper.ParseLine(lines[i]);
            Entry entry = new Entry(parts[0], parts[1], parts[2], parts[3]);
            _entries.Add(entry);
        }
    }

}
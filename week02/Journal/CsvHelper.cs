using System;

public static class CsvHelper
{
    // Wrap the field in quotes and double in internal quote characters
    public static string EscapeField(string field)
    {
        if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
        {
            string fixer = field.Replace("\"", "\"\"");
            return $"\"{fixer}\"";
        }
        return field;
    }

    // Parse every single CSV line into separate fields, correctly handling fields that contain commas or quotes wrapped in double quotes.
    public static List<string> ParseLine(string line)
    {
        List<string> fields = new();
        bool insideQoutes = false;
        string currentField = "";

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (insideQoutes)
            {
                // Double quotes in a row inside a quoted field = one literal character
                if (c == '"' && i + 1 < line.Length && line[i + 1] == '"')
                {
                    currentField += '"';
                    i++; //Skip the second quote after the qoute addition
                }
                // Single quote shows the end of the quoted section
                else if (c == '"')
                {
                    insideQoutes = false;
                }
                else
                {
                    currentField += c;
                }
            }
            else
            {
                if (c == '"')
                {
                    // Qoutes are inside and are not treated as a delimeter
                    insideQoutes = true;
                }
                else if (c == ',')
                {
                    // Quotes added to exclude the comma within the text
                    fields.Add(currentField);
                    currentField = "";
                }
                else
                {
                    currentField += c;
                }
            }
        }

        // Trailing quotes are added after the end of the loop
        fields.Add(currentField);

        return fields;
    }
}
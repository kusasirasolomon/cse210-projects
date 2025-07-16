// Entry.cs
// Represents one journal entry (date, prompt, response).

using System;

namespace JournalProgram
{
    public class Entry
    {
        public string Date { get; }
        public string Prompt { get; }
        public string Response { get; }

        // Constructor used when writing a new entry (date = today)
        public Entry(string prompt, string response)
        {
            Date = DateTime.Now.ToString("yyyy-MM-dd");
            Prompt = prompt;
            Response = response;
        }

        // Constructor used when loading from file (date already known)
        public Entry(string date, string prompt, string response)
        {
            Date = date;
            Prompt = prompt;
            Response = response;
        }

        public override string ToString()
        {
            return $"[{Date}] {Prompt}\n{Response}\n";
        }

        /// <summary>
        /// Format for saving: Date~|~Prompt~|~Response
        /// </summary>
        public string ToFileString(string sep = "~|~")
        {
            return $"{Date}{sep}{Prompt}{sep}{Response}";
        }

        /// <summary>
        /// Parse line from file back into an Entry.
        /// </summary>
        public static Entry FromFileString(string line, string sep = "~|~")
        {
            string[] parts = line.Split(sep);
            if (parts.Length < 3)
                throw new FormatException("Invalid entry line.");

            // Combine any additional separators back into the response
            string response = string.Join(sep, parts, 2, parts.Length - 2);
            return new Entry(parts[0], parts[1], response);
        }
    }
}

// Journal.cs
// Holds a list of Entry objects and handles file I/O.

using System;
using System.Collections.Generic;
using System.IO;

namespace JournalProgram
{
    public class Journal
    {
        private readonly List<Entry> _entries = new();
        private readonly string _sep;

        public Journal(string separator = "~|~")
        {
            _sep = separator;
        }

        public void AddEntry(Entry entry) => _entries.Add(entry);

        public void Display()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("Your journal is empty.\n");
                return;
            }

            Console.WriteLine("\n--- Your Journal ---");
            foreach (Entry e in _entries)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine("--------------------\n");
        }

        public void Save(string filename)
        {
            using StreamWriter sw = new(filename);
            foreach (Entry e in _entries)
            {
                sw.WriteLine(e.ToFileString(_sep));
            }
            Console.WriteLine($"Journal saved to “{filename}”.\n");
        }

        public void Load(string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found.\n");
                return;
            }

            _entries.Clear();
            foreach (string line in File.ReadLines(filename))
            {
                if (!string.IsNullOrWhiteSpace(line))
                    _entries.Add(Entry.FromFileString(line, _sep));
            }
            Console.WriteLine($"Journal loaded from “{filename}”.\n");
        }
    }
}

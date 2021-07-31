using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace DesignPatterns
{
    /// <summary>
    ///     Solid principle : Class Journal handles only the text entries while the persistence handles saving
    ///     Data into a file.
    ///     If saving text into a file is to be handle within the Journal class, we violate this
    ///     as the journal class handle two distinctly different responsibility.
    /// </summary>
    public class Journal
    {
        private static int _count;
        private readonly List<string> _entries = new List<string>();

        public int AddEntries(string text)
        {
            _entries.Add($"{++_count}:{text}");
            return _count;
        }

        public void RemoveEntry(int index)
        {
            _entries.RemoveAt(index); //doing this will change the overall index in the list.
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, _entries);
        }
    }

    public class Persistence
    {
        public void SaveToFile(Journal j, string filename, bool overwrite = false)
        {
            if (overwrite || !File.Exists(filename)) File.WriteAllText(filename, j.ToString());
        }
    }

    public class Program
    {
        public void Main(string[] args)
        {
            var j = new Journal();
            j.AddEntries("I cried today");
            j.AddEntries("I ate a bug");
            Console.WriteLine(j);

            var p = new Persistence();
            const string fileName = @"c:\temp\journal.txt";
            p.SaveToFile(j, fileName, true);
            Process.Start(fileName);
        }
    }
}
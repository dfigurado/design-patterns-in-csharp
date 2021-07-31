using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace DesignPatternsInCSharp
{
	public class Diary
	{
		private readonly List<string> entries = new List<string>();
		
		private static int count = 0;
		
		public int AddEntry(string text)
		{
			entries.Add($"{++count}: {text}");
			return count;
		}
		
		public void RemoveEntry(int index)
		{
			entries.RemoveAt(index); //Note: Not the best way to do this because, rest of the indexs becomes invalid.
		}
		
		public override string ToString()
		{
			return string.Join(Environment.NewLine, entries);
		}	
		
		// Persistance
		public void Save(string filename)
		{
			File.WriteAllText(filename, ToString());
		}
		
		public static Diary Load(string filename) 
		{
			
		}
		
		public void Load(Uri uri)
		{
		}
	}
	
	public class Demo
	{
		static  void Main(string[] args)
		{
			var d = new Diary();
			d.AddEntry("I cooked today");
			d.AddEntry("I ate sushi for lunch");
			WriteLine(d);
		}
	}
}
namespace JestingCSharp {
	using System;
	using System.IO;
	using CsvHelper;

	public static class Program {

		public static void Main() {

			var p1 = new Person(id: 0, name: "Jos\"eph");

			{
				using var writeStream = File.CreateText("temp.txt");
				using var csvWriter = new CsvWriter(writeStream);

				csvWriter.WriteHeader<Person>();
				csvWriter.NextRecord();
				csvWriter.WriteRecord(p1);
				csvWriter.Flush();
			}

			var readerStream = File.OpenText("temp.txt");
			using var csvReader = new CsvReader(readerStream);
			csvReader.Read();
			csvReader.ReadHeader();

			while (csvReader.Read()) {
				var p2 = csvReader.GetRecord<Person>();
				Console.WriteLine($"{p2.Id} {p2.Name}");
			}
		}
	}
}

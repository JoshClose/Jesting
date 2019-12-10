namespace JestingCSharp {
	using CsvHelper.Configuration.Attributes;

	public sealed class Person {

		[Index(0)]
		public int Id { get; }

		[Index(1)]
		public string Name { get; }

		public Person(int id, string name) {
			Id = id;
			Name = name;
		}
	}
}

abstract class Person
{
	public abstract string? Name { get; set; }
	public abstract string? Surname { get; set; }
	public abstract int Age { get; set; }

	public Person() { }

	protected Person(string? name, string? surname, int age)
	{
		Name = name;
		Surname = surname;
		Age = age;
	}

	public override string ToString() => $"{Name} {Surname} {Age}";
}
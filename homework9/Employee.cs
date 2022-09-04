abstract class Employee : Person
{
	public abstract string? Position { get; set; }
	public abstract double Salary { get; set; }

	protected Employee() { }

	protected Employee(string name, string surname, int age, string position, double salary)
		: base(name, surname, age) { Position = position; Salary = salary; }

	public override string ToString() => $"{base.ToString()}\n\t{Position} | {Salary}\n";
}
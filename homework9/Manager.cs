class Manager : Employee, IOrganize, IUnique
{
	public Guid Id { get; } = Guid.NewGuid();
	public override string? Name { get; set; }
	public override string? Surname { get; set; }
	public override int Age { get; set; }
	public override string? Position { get; set; }
	public override double Salary { get; set; }

	public Manager() { }

	public Manager(string name, string surname, int age, string position, double salary)
		: base(name, surname, age, position, salary) { }

	public void Organize() => Console.WriteLine("Manager Is Organizing...");

	public override string ToString() => $"{base.ToString}\n\tManager id : {Id}";

	public static double CalculateSalary(Employee[] employees)
	{
		double total = 0;

		foreach (var employee in employees)	
			total += employee.Salary;

		return total;
	}
}
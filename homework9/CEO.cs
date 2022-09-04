class CEO : Employee, IOrganize, IUnique
{
	public Guid Id { get; } = Guid.NewGuid();
	public override string? Name { get; set; }
	public override string? Surname { get; set; }
	public override int Age { get; set; }
	public override string? Position { get; set; }
	public override double Salary { get; set; }

	public CEO() { }

	public CEO(string name, string surname, int age, string position, double salary)
		: base(name, surname, age, position, salary) { }

	public void Organize() => Console.WriteLine("CEO Is Organizing...");
	public void Unique() => Console.WriteLine("Meeting...");

	public override string ToString() => $"{base.ToString}\n\tCEO id : {Id}";
}
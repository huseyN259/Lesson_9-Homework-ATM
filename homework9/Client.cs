class Client : Employee, IUnique
{
	public Guid Id { get; } = Guid.NewGuid();
	public override string? Name { get; set; }
	public override string? Surname { get; set; }
	public override int Age { get; set; }
	public override string? Position { get; set; }
	public override double Salary { get; set; }
	public string? WorkAddress { get; set; }
	public string? LiveAddress { get; set; }
	public Credit? Credit { get; set; }

	public Client() { }

	public Client(string name, string surname, byte age, string position, uint salary, string workAddress, string liveAddress)
		: base(name, surname, age, position, salary) { WorkAddress = workAddress; LiveAddress = liveAddress; }

	public static bool operator ==(Client c1, Client c2)
	   => c1.Id == c2.Id;
	public static bool operator !=(Client c1, Client c2)
		=> c1.Id != c2.Id;
}
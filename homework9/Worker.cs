class Worker : Employee, IUnique
{
	public Guid Id { get; } = Guid.NewGuid();
	public override string? Name { get; set; }
	public override string? Surname { get; set; }
	public override int Age { get; set; }
	public override string? Position { get; set; }
	public override double Salary { get; set; }
	public TimeOnly StartTime { get; set; }
	public TimeOnly EndTime { get; set; }
	public Operation[]? Operations { get; set; } = null;

	public Worker() { }

	public Worker(string name, string surname, int age, string position, double salary, TimeOnly startTime, TimeOnly endTime, Operation[]? operations = null)
		: base(name, surname, age, position, salary)
	{
		StartTime = startTime;
		EndTime = endTime;
		Operations = operations;
	}

	public override string ToString() => $"{base.ToString()}\n\tWorker : {Id}\n\t{StartTime} => {EndTime}";

	public void AddOperation(Operation operation)
	{
		if (operation == null) 
			Operations = Addition.AddElement(Operations, operation);
		else 
			throw new ArgumentNullException();
	}
}
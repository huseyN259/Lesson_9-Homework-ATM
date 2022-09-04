class Operation : IUnique
{
	public Guid Id { get; } = Guid.NewGuid();
	public string? OperationName { get; set; }
	public DateTime Time { get; set; }
}
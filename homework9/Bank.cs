class Bank
{
	public Guid Id { get; } = Guid.NewGuid();
	public string? Name { get; set; }
	public double Budget { get; set; }
	public CEO? CEO { get; set; }
	public Manager[]? Managers { get; set; }
	public Worker[]? Workers { get; set; }
	public Client[]? Clients { get; set; }

	public double CalculateProfit()
	{
		double profit = 0;

		if (Clients != null)
			foreach (var client in Clients)
				profit += Convert.ToDouble(client?.Credit?.Amount * client?.Credit?.Percent / 100.0);

		if (Managers != null)
			foreach (var manager in Managers)
				profit -= Convert.ToDouble(manager.Salary);

		if (Workers != null)
			foreach (var worker in Workers)
				profit -= Convert.ToDouble(worker.Salary);

		profit -= Convert.ToDouble(CEO?.Salary);

		return profit;
	}

	public void ShowAllClientCredits(string name, string surname)
	{
		if (Clients != null)
			foreach (var client in Clients)
				if (client.Name == name && client.Surname == surname)
					Console.WriteLine(client?.Credit);
	}

	public void ShowAllCredits()
	{
		if (Clients != null)
			foreach (var client in Clients)
				Console.WriteLine(client?.Credit);
	}

	public void ShowAllClients()
	{
		if (Clients != null)
			foreach (var client in Clients)
				Console.WriteLine(client);
	}

	public void ShowAllWorkers()
	{
		if (Workers != null)
			foreach (var worker in Workers)
				Console.WriteLine(worker);
	}

	public void ShowAllManagers()
	{
		if (Managers != null)
			foreach (var manager in Managers)
				Console.WriteLine(manager);
	}

	public Client? GetClient(string name, string surname)
	{
		if (Clients != null) 
			foreach (var client in Clients)
				if (client.Name == name && client.Surname == surname)
					return client;
		
		return null;
	}

	public void PayCredit(Client clientIn, double money)
	{
		if (Clients != null)
			foreach (var client in Clients)
				if (clientIn == client)
					client.Credit.Payment -= money;
	}
}
using Faker;
using System.Runtime.InteropServices;

class Program
{
	public static string[] positions = { "Software Developer", "Graphic Designer", "Director" };

	static CEO FakerCEO()
	{
		Random random = new Random();
		
		CEO ceo = new CEO()
		{
			Name = Faker.NameFaker.Name(),
			Surname = Faker.NameFaker.LastName(),
			Age = Convert.ToInt32(random.Next(18, 100)),
			Position = positions[random.Next(0, 3)],
			Salary = (double)(random.Next(500, 10000))
		};

		return ceo;
	}

	static Manager FakerManager()
	{
		Random random = new Random();

		Manager manager = new Manager()
		{
			Name = Faker.NameFaker.Name(),
			Surname = Faker.NameFaker.LastName(),
			Age = Convert.ToInt32(random.Next(18, 100)),
			Position = positions[random.Next(0, 3)],
			Salary = (double)(random.Next(500, 10000))
		};

		return manager;
	}

	static Worker FakerWorker()
	{
		Random random = new Random();

		Worker worker = new Worker()
		{
			Name = Faker.NameFaker.Name(),
			Surname = Faker.NameFaker.LastName(),
			Age = Convert.ToInt32(random.Next(18, 100)),
			Position = positions[random.Next(0, 3)],
			Salary = (double)(random.Next(500, 10000)),
			StartTime = new TimeOnly(09, 00),
			EndTime = new TimeOnly(18, 00),
			Operations = new Operation[] 
			{ 
				FakerOperation() 
			}
		};

		return worker;
	}

	static Operation FakerOperation()
	{
		Random random = new Random();

		Operation operation = new Operation()
		{
			OperationName = "Money Lending...",
			Time = Faker.DateTimeFaker.DateTimeBetweenYears(2015, 2022)
		};

		return operation;
	}

	static Client FakerClient()
	{
		Random random = new Random();

		Client client = new Client()
		{
			Name = Faker.NameFaker.Name(),
			Surname = Faker.NameFaker.LastName(),
			Age = Convert.ToInt32(random.Next(18, 100)),
			Position = positions[random.Next(0, 3)],
			Salary = (double)(random.Next(500, 10000)),
			WorkAddress = Faker.LocationFaker.Street(),
			LiveAddress = Faker.LocationFaker.Street(),
			Credit = FakerCredit()
		};

		return client;
	}

	static Credit FakerCredit()
	{
		Random random = new Random();

		Credit credit = new Credit()
		{
			Amount = (double)random.Next(500, 10000),
			Percent = (double)random.Next(1, 100),
			Months = (int)(random.Next(1, 13))
		};

		credit.Payment = Credit.CalculatePercent(credit.Amount, credit.Percent);
		
		return credit;
	}

	static Bank FakerBank()
	{
		Random random = new Random();

		Bank bank = new Bank()
		{
			Name = Faker.CompanyFaker.Name(),
			Budget = (double)random.Next(100000, 1000000),
			CEO = FakerCEO(),
		};

		return bank;
	}

	static void Main()
	{
		Console.ForegroundColor = ConsoleColor.Cyan;

		Bank bank = FakerBank();

		for (int i = 0; i < 15; i++)
			bank.Clients = Addition.AddElement(bank.Clients, FakerClient());

		for (int i = 0; i < 10; i++)
			bank.Workers = Addition.AddElement(bank.Workers, FakerWorker());

		for (int i = 0; i < 5; i++)
			bank.Managers = Addition.AddElement(bank.Managers, FakerManager());
		bank.CEO = FakerCEO();

		string clients = "========== CLIENTS ==========";
		Console.WriteLine(clients.PadLeft(70));
		bank.ShowAllClients();
		Console.WriteLine("\nPress any key to continue...");
		Console.ReadKey();
		Console.Clear();

		string workers = "========== WORKERS ==========";
		Console.WriteLine(workers.PadLeft(70));
		bank.ShowAllWorkers();
		Console.WriteLine("\nPress any key to continue...");
		Console.ReadKey();
		Console.Clear();

		string managers = "=========== MANAGERS ==========";
		Console.WriteLine(managers.PadLeft(70));
		bank.ShowAllManagers();
		Console.WriteLine("\nPress any key to continue...");
		Console.ReadKey();
		Console.Clear();
		
		bank.ShowAllCredits();
		Console.ReadKey();
		Console.Clear();

		Console.WriteLine($"Total Profit : {bank.CalculateProfit()}");
		string? name = bank.Clients?.First().Name;
		string? surname = bank.Clients?.First().Surname;

		bank.ShowAllClientCredits(name, surname);
		bank.PayCredit(bank.GetClient(name, surname), 2500);
		bank.ShowAllClientCredits(name, surname);
	}
}
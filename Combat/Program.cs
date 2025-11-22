using Combat;

bool doCzasu = true;
bool gra = true;
int akcja;
int liczba_pokonanych = 0;
int punktyUlepszeń = 0;
int money = 0;

Random rnd = new Random();
Random rndmoney = new Random();

Gracz player = new Gracz();

List<Potwor> Potwory = new List<Potwor>();

Potwory.Add(new Zombie());
Potwory.Add(new Cyklop());
Potwory.Add(new Wampir());

int PotworyLen = Potwory.Count;

while (doCzasu) {
	Console.WriteLine("Podaj swoją nazwe: ");
	string imie = Console.ReadLine();
    if (imie is not null)
    {
        player.Nazwa = imie;
        doCzasu = false;
    }
}
void Walcz(Potwor przeciwnik)
{
	bool CzyPokonany = true;
	while (CzyPokonany)
	{
		Console.WriteLine("Wybierz jedną z akcji: ");
		Console.WriteLine("1 - Atakuj");
		Console.WriteLine("2 - Ulecz");

		bool idk = true;
		while (idk)
		{
			string input = Console.ReadLine();
			if (int.TryParse(input, out akcja))
			{
				akcja = int.Parse(input);
				idk = false;
			}

			switch (akcja)
			{
				case 1:
					Console.Clear();
					Console.WriteLine("Atakujesz!");
					przeciwnik.Otrzymaj(player.Sila);
					Console.WriteLine($"Przeciwnik ma teraz {przeciwnik.HP} HP");

					Console.ReadLine();

					Console.Clear();
					Console.WriteLine("Przeciwnik atakuje!");
					player.Otrzymaj(przeciwnik.Sila);
					Console.WriteLine($"Masz teraz {player.HP} HP");

					Console.ReadLine();
					Console.Clear();

					if (przeciwnik.HP == 0)
					{
						CzyPokonany = false;
						liczba_pokonanych += 1;
						money += rndmoney.Next(100, 200);
						punktyUlepszeń += 1;
						Console.Clear();
						Console.WriteLine($"Pokonałeś przeciwnika. Liczba pokonanych przeciwników: {liczba_pokonanych}");
						Console.WriteLine($"Łącznie masz {money} kasy i {punktyUlepszeń} punkty ulepszeń");
						Console.WriteLine("Naciśnij by kontynuować");
						Console.ReadLine();

					}
					if (player.HP == 0)
					{
						Console.Clear();
						Console.WriteLine("PORAZKA!");
						Console.WriteLine("Naciśnij dowolny przycisk by wyjść z gry...");
						Console.ReadLine();
						gra = false;
						CzyPokonany = false;
					}
					break;

				case 2:
					Console.Clear();
					Console.WriteLine("Leczysz się");
					player.Ulecz(player.SilaLeczenia);
					Console.WriteLine($"Masz teraz {player.HP} HP");

					Console.ReadLine();

					Console.Clear();
					Console.WriteLine("Przeciwnik atakuje!");
					player.Otrzymaj(przeciwnik.Sila);
					Console.WriteLine($"Masz teraz {player.HP} HP");

					Console.ReadLine();
					Console.Clear();

					if (player.HP == 0)
					{
						Console.Clear();
						Console.WriteLine("PORAZKA!");
						Console.WriteLine("Naciśnij dowolny przycisk by wyjść z gry...");
						Console.ReadLine();
						gra = false;
						CzyPokonany = false;
					}
					break;
			}
		}
	}
}


while (gra)
{
    Console.Clear();
    Console.WriteLine($"Witaj {player.Nazwa}");

    Console.WriteLine("Wybierz jedną z opcji: ");
    Console.WriteLine("1 - Walka -- częściowo dostępne");
    Console.WriteLine("2 - Ulepszenia -- WORK IN PROGRESS");
    Console.WriteLine("3 - Przeciwnicy -- WORK IN PROGRESS");
	Console.WriteLine("4 - Wyjście");
	string wybór = Console.ReadLine();

	switch (wybór)
	{
		case "1":
			Console.WriteLine("WALKA!");

			int FightWho = rnd.Next(1, PotworyLen + 1);

			switch (FightWho)
			{
				case 1:
					Zombie zombie = new Zombie();
					Console.Clear();
					Console.WriteLine($"Twój przeciwnik to: {zombie.Nazwa}");
					Walcz(zombie);
					break;
				case 2:
					Cyklop cyklop = new Cyklop();
					Console.Clear();
					Console.WriteLine($"Twój przeciwnik to: {cyklop.Nazwa}");
					Walcz(cyklop);
					break;
				case 3:
					Wampir wampir = new Wampir();
					Console.Clear();
					Console.WriteLine($"Twój przeciwnik to: {wampir.Nazwa}");

					Random rndKrew = new Random();
					if (rndKrew.Next(1, 11) > 7)
					{
						wampir.SpecjalnyAtak(player);
						Console.ReadLine();
						Console.Clear();
					}

					Walcz(wampir);
					break;

			}
			break;


		case "2":
			Console.Clear();
			Console.WriteLine("ULEPSZENIA");
			Console.WriteLine("Naciśnij dowolny przycisk by kontynuować");
			Console.ReadLine();
			break;

		case "3":
			Console.Clear();
			Console.WriteLine("PRZECIWNICY");
			Console.WriteLine("Naciśnij dowolny przycisk by kontynuować");
			Console.ReadLine();
			break;

		case "4":
			return;
	}
}


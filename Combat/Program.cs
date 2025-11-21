using Combat;
bool doCzasu = true;
bool gra = true;

Random rnd = new Random();

Gracz player = new Gracz();

List<Potwor> Potwory = new List<Potwor>();

Potwory.Add(new Zombie());

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

while (gra)
{
    Console.Clear();
    Console.WriteLine($"Witaj {player.Nazwa}");

    Console.WriteLine("Wybierz jedną z opcji: ");
    Console.WriteLine("1 - Walka -- częściowo dostępne");
    Console.WriteLine("2 - Ulepszenia -- WORK IN PROGRESS");
    Console.WriteLine("3 - Potwory -- WORK IN PROGRESS");
    string wybór = Console.ReadLine();

    if (wybór == "1")
    {
        Console.WriteLine("Walka się rozpoczyna!");

	    int FightWho = rnd.Next(1, PotworyLen);
        switch (FightWho) 
        { 
            case 1:
                Zombie zombie = new Zombie();
                bool CzyPokonany = true;
                Console.Clear();
                Console.WriteLine($"Twój przeciwnik to: {zombie.Nazwa}");
                while (CzyPokonany)
                {
                    Console.WriteLine("Wybierz jedną z akcji: ");
                    Console.WriteLine("1 - Atakuj");
                    Console.WriteLine("2 - Ulecz");

                    int akcja = int.Parse(Console.ReadLine());
                    switch (akcja)
                    {
                        case 1:
							Console.Clear();
							Console.WriteLine("Atakujesz!");
                            zombie.Otrzymaj(player.Sila);
                            Console.WriteLine($"Przeciwnik ma teraz {zombie.HP} HP");

                            Console.ReadLine();

                            Console.Clear();
							Console.WriteLine("Przeciwnik atakuje!");
							player.Otrzymaj(zombie.Sila);
							Console.WriteLine($"Masz teraz {player.HP} HP");

							Console.ReadLine();
							Console.Clear();

							if (zombie.HP == 0)
                            {
								Console.Clear();
                                Console.WriteLine("Pokonałeś przeciwnika. Naciśnij by kontynuować.");
                                Console.ReadLine();
                                CzyPokonany = false;
                            }
                            if (player.HP == 0) 
                            { 
                                Console.Clear();
                                Console.WriteLine("PORAZKA!");
                                Console.WriteLine("Naciśnij dowolny przycisk by wyjść z gry...");
								Console.ReadLine();
                                gra = false;
                                CzyPokonany= false;
                            }
							break;
                    }
                }
                break;
        }

	}

}

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

	    int FightWho = rnd.Next(1, PotworyLen+1);
        
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
                                player.Otrzymaj(zombie.Sila);
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
                break;

            case 2:
				Cyklop cyklop = new Cyklop();
				bool CzyPokonany2 = true;
				Console.Clear();
				Console.WriteLine($"Twój przeciwnik to: {cyklop.Nazwa}");
				while (CzyPokonany2)
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
								cyklop.Otrzymaj(player.Sila);
								Console.WriteLine($"Przeciwnik ma teraz {cyklop.HP} HP");

								Console.ReadLine();

								Console.Clear();
								Console.WriteLine("Przeciwnik atakuje!");
                                player.Otrzymaj(cyklop.Sila);
								Console.WriteLine($"Masz teraz {player.HP} HP");

								Console.ReadLine();
								Console.Clear();

								if (cyklop.HP == 0)
								{
									CzyPokonany2 = false;
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
									CzyPokonany2 = false;
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
								player.Otrzymaj(cyklop.Sila);
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
									CzyPokonany2 = false;
								}
								break;
						}
					}

				}
				break;

		}

	}

}

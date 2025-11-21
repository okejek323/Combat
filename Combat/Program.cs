using Combat;
bool doCzasu = true;
bool gra = true;

Gracz player = new Gracz();
Zombie zombie = new Zombie();

Console.WriteLine("Podaj swoją nazwe: ");

while (doCzasu) {
    string imie = Console.ReadLine();
    if (imie is not null)
    {
        player.Nazwa = imie;
        doCzasu = false;
    }
}

while (gra)
{
    Console.WriteLine($"Witaj {player.Nazwa}. Wybierz jedną z opcji");

    Console.WriteLine("Wybierz jedną z opcji: ");
    Console.WriteLine("1 - Walka");
    Console.WriteLine("2 - Ulepszenia");
    Console.WriteLine("-------------");
    string wybór = Console.ReadLine();

    if (wybór == "1")
    {
        Console.WriteLine("Walka się rozpoczyna!\n");
    }

}

namespace MP1_APBD_s30638.Items;

public abstract class Sprzęt
{
    protected string Id {get;}
    public string Nazwa { get; protected set; }
    public StatusSprzętu Status {get; set;}
    protected string Producent {get; set;}
    protected string NumerSeryjny {get; set;}

    protected Sprzęt(string nazwa, StatusSprzętu status, string producent, string numerSeryjny)
    {
        Nazwa = nazwa;
        Status = status;
        Producent = producent;
        NumerSeryjny = numerSeryjny;
        Id = Guid.NewGuid().ToString();
    }

    public void UstawJakoNiedostępny()
    {
        if (Status == StatusSprzętu.Wypożyczony)
            Console.WriteLine("Nie można oznaczyć jako niedostępny - sprzęt jest wypożyczony");
        Status = StatusSprzętu.Niedostępny;
        Console.WriteLine($"Ustawiono jako niedostępny {Nazwa}");
    }

    public void UstawJakoDostępny()
    {
        if (Status != StatusSprzętu.Wypożyczony)
            Console.WriteLine("Nie można zwrócić. Sprzęt nie jest wypożyczony");
        Status = StatusSprzętu.Dostępny;
        Console.WriteLine("Ustawiono jako dostępny;");
    }

    public void UstawJakoWypożyczony()
    {
        if (Status != StatusSprzętu.Dostępny)
        {
            Console.WriteLine($"Nie można wypożyczyć - sprzęt jest {Status}");
        }
        Status = StatusSprzętu.Wypożyczony;
        Console.WriteLine("Ustawionio jako wypożyczony");
    }
}
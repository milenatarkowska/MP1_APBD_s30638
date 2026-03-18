namespace MP1_APBD_s30638.Items;

public abstract class Sprzęt
{
    private string Id {get;}
    private string Nazwa { get; set; }
    private StatusSprzętu Status {get; set;}
    private string Producent {get; set;}
    private string NumerSeryjny {get; set;}

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
            throw new InvalidOperationException("Nie można oznaczyć jako niedostępny - sprzęt jest wypożyczony");
        Status = StatusSprzętu.Niedostępny;
        Console.WriteLine("Ustawiono jako niedostępny");
    }

    public void UstawJakoDostępny()
    {
        if (Status != StatusSprzętu.Wypożyczony)
            throw new InvalidOperationException($"Nie można zwrócić. Sprzęt nie jest wypożyczony");
        Status = StatusSprzętu.Dostępny;
        Console.WriteLine("Ustawiono jako dostępny;");
    }

    public void UstawJakoWypożyczony()
    {
        if (Status != StatusSprzętu.Dostępny)
        {
            throw new InvalidOperationException($"Nie można wypożyczyć - sprzęt jest {Status}");
        }
        Status = StatusSprzętu.Wypożyczony;
        Console.WriteLine("Ustawionio jako wypożyczony");
    }
}
using MP1_APBD_s30638.Items;
using MP1_APBD_s30638.Users;
namespace MP1_APBD_s30638;

public class Serwis
{
    private List<Użytkownik> _użytkownicy = new List<Użytkownik>();
    private List<Sprzęt> _sprzęt = new List<Sprzęt>();
    private List<Wypożyczenie> _wypożyczenie = new List<Wypożyczenie>();

    public void DodajUżytkownika(Użytkownik użytkownik)
    {
        _użytkownicy.Add(użytkownik);
        Console.WriteLine("Dodano nowego użytkownika: " + użytkownik.ToString());
    }

    public List<Użytkownik> PobierzWszystkichUżytkowników()
    {
        return _użytkownicy.ToList();
    }

    public void DodajSprzęt(Sprzęt sprzęt)
    {
        _sprzęt.Add(sprzęt);
        Console.WriteLine("Dodano nowy sprzęt: " + sprzęt);
    }

    public void WyświetlCałySprzęt()
    {
        foreach (var s in _sprzęt)
        {
            Console.WriteLine($"{s.Nazwa} - Status: {s.Status}");
        }
    }

    public void WyświetlDostępne()
    {
        var dostepne = _sprzęt.Where(s => s.Status == StatusSprzętu.Dostępny);
    
        foreach (var s in dostepne)
        {
            Console.WriteLine($"Wolny sprzęt: {s.Nazwa}");
        }
    }
}
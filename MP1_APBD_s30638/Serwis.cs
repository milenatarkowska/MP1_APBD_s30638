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
        Console.WriteLine("Dodano nowego użytkownika: " + użytkownik);
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

    public List<Sprzęt> PobierzCałySprzęt()
    {
        return _sprzęt.ToList();
    }
}
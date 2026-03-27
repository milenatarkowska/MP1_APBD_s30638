using MP1_APBD_s30638.Items;
using MP1_APBD_s30638.Users;
namespace MP1_APBD_s30638;

public class Serwis
{
    private List<Użytkownik> _użytkownicy = new List<Użytkownik>();
    private List<Sprzęt> _sprzęt = new List<Sprzęt>();
    private List<Wypożyczenie> _wypożyczenia = new List<Wypożyczenie>();

    public void DodajUżytkownika(Użytkownik użytkownik)
    {
        _użytkownicy.Add(użytkownik);
        Console.WriteLine("Dodano nowego użytkownika: " + użytkownik.ToString());
    }
    
    public void DodajSprzęt(Sprzęt sprzęt)
    {
        _sprzęt.Add(sprzęt);
        Console.WriteLine("Dodano nowy sprzęt: " + sprzęt);
    }

    public void WyświetlCałySprzęt()
    {
        Console.WriteLine("Lista całego sprzętu");
        foreach (var s in _sprzęt)
        {
            Console.WriteLine($"{s.Nazwa} - Status: {s.Status}");
        }
    }

    public void WyświetlDostępne()
    {
        var dostepne = _sprzęt.Where(s => s.Status == StatusSprzętu.Dostępny);
        
        Console.WriteLine("Lista dostępnego sprzętu");
        
        foreach (var s in dostepne)
        {
            Console.WriteLine($"Wolny sprzęt: {s.Nazwa}");
        }
    }

    public void Wypożycz(Sprzęt sprzęt, Użytkownik użytkownik)
    {
        int aktywneWypożyczenia = 0;
        
        foreach (var w in _wypożyczenia)
            if (w.Użytkownik == użytkownik && w.FaktycznyZwrot == null) aktywneWypożyczenia++;
        
        int limit =(użytkownik is Student) ? 2 : 5;
        
        if (aktywneWypożyczenia >= limit) {
            Console.WriteLine($"BŁĄD: {użytkownik.Nazwisko} osiągnął limit {limit} wypożyczeń.");
            return;
        }

        if (sprzęt.Status != StatusSprzętu.Dostępny) {
            Console.WriteLine($"BŁĄD: Sprzęt {sprzęt.Nazwa} jest {sprzęt.Status}.");
            return;
        }
        
        var wypożyczenie = new Wypożyczenie(użytkownik, sprzęt);
        _wypożyczenia.Add(wypożyczenie);
    }
    
    public void Zwróć(Sprzęt sprzet)
    {
        Wypożyczenie aktywneWypozyczenie = null;
        
        foreach (var w in _wypożyczenia)
        {
            if (w.Sprzęt == sprzet && w.FaktycznyZwrot == null)
            {
                aktywneWypozyczenie = w;
                break;
            }
        }
        
        if (aktywneWypozyczenie == null)
        {
            Console.WriteLine("BŁĄD: Nie znaleziono aktywnego wypożyczenia dla tego urządzenia.");
            return;
        }
        
        aktywneWypozyczenie.FaktycznyZwrot = DateTime.Now;

        if (aktywneWypozyczenie.FaktycznyZwrot > aktywneWypozyczenie.TerminZwrotu)
        {
            TimeSpan opóźnienie = aktywneWypozyczenie.FaktycznyZwrot.Value - aktywneWypozyczenie.TerminZwrotu;
            int dni = opóźnienie.Days;
            
            double kara = dni * 5;
            Console.WriteLine($"Zwrot OPÓŹNIONY o {dni} dni. Naliczona kara: {kara}zł");
        }
        else
        {
            Console.WriteLine("Zwrot w terminie. Brak dodatkowych opłat.");
        }
        
        sprzet.UstawJakoDostępny();
    }
    
    public void WyswietlAktywneDlaUzytkownika(Użytkownik u)
    {
        Console.WriteLine($"Aktywne wypożyczenia dla: {u.Imie} {u.Nazwisko}");
        foreach (var w in _wypożyczenia)
            if (w.Użytkownik == u && w.FaktycznyZwrot == null)
                Console.WriteLine($"- {w.Sprzęt.Nazwa} (Termin: {w.TerminZwrotu})");
    }
    
    public void WyswietlPrzeterminowane()
    {
        Console.WriteLine("Przeterminowane wypożyczenia");
        foreach (var w in _wypożyczenia)
            if (w.FaktycznyZwrot == null && w.TerminZwrotu < DateTime.Now)
                Console.WriteLine($"- {w.Sprzęt.Nazwa} u {w.Użytkownik.Nazwisko}");
    }

    public void GenerujRaport()
    {
        Console.WriteLine("----------WYGENEROWANY RAPORT SYSTEMU----------");
        Console.WriteLine($"Liczba sprzętu: {_sprzęt.Count}");
        Console.WriteLine($"Liczba użytkowników: {_użytkownicy.Count}");
        int aktywne = 0;
        foreach(var w in _wypożyczenia) if(w.FaktycznyZwrot == null) aktywne++;
        Console.WriteLine($"Aktywne wypożyczenia: {aktywne}");
    }
}
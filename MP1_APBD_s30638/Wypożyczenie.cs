using MP1_APBD_s30638.Users;
using MP1_APBD_s30638.Items;

namespace MP1_APBD_s30638;

public class Wypożyczenie
{
    private DateTime DataWypożyczenia { get; set; }
    private DateTime TerminZwrotu { get; set; }
    private DateTime? FaktycznyZwrot { get; set; }
    private double DodatkoweKoszty { get; set; }
    private Użytkownik Użytkownik { get; set; }
    private Sprzęt Sprzęt  { get; set; }
    private bool CzyPrzekroczonoTermin { get; set; }
    private string Id { get; set; }
    private bool CzyAktywne => !FaktycznyZwrot.HasValue;
    private bool CzyPoTerminie => CzyAktywne && DateTime.Now > TerminZwrotu;

    public Wypożyczenie(Użytkownik użytkownik, Sprzęt sprzęt, int okresWypożyczenia = 14)
    {
        Id = Guid.NewGuid().ToString();
        Użytkownik = użytkownik;
        Sprzęt = sprzęt;
        DataWypożyczenia = DateTime.Now;
        TerminZwrotu = DateTime.Now.AddDays(okresWypożyczenia);
        FaktycznyZwrot = null;
        DodatkoweKoszty = 0;
        CzyPrzekroczonoTermin = false;
        
        sprzęt.UstawJakoWypożyczony();
    }

    public void Zwróć()
    {
        if (!CzyAktywne)
        {
            throw new InvalidOperationException("To wypożyczenie jest już zakończone!");
        }
        FaktycznyZwrot = DateTime.Now;

        if (FaktycznyZwrot > TerminZwrotu)
        {
            CzyPrzekroczonoTermin = true;
            
            TimeSpan opóźnienie = FaktycznyZwrot.Value - TerminZwrotu;
            int ilośćDniOpóźnienia = opóźnienie.Days;
            DodatkoweKoszty = ilośćDniOpóźnienia * 5;
            Console.WriteLine("Zwrot opóźniony. Dodatkowe koszty: " + DodatkoweKoszty + " 5zł za każdy dzień opóźnienia");
            
            Sprzęt.UstawJakoDostępny();
        }
        else
        {
            Console.WriteLine("Zwrócono sprzęt bez dodatkowych opłat.");
            Sprzęt.UstawJakoDostępny();
        }
    }
}
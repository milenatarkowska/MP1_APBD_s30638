using MP1_APBD_s30638.Users;
using MP1_APBD_s30638.Items;

namespace MP1_APBD_s30638;

public class Wypożyczenie
{
    private DateTime DataWypożyczenia { get; set; }
    public DateTime TerminZwrotu { get; set; }
    public DateTime? FaktycznyZwrot { get; set; }
    public double DodatkoweKoszty { get; set; }
    public Użytkownik Użytkownik { get; set; }
    public Sprzęt Sprzęt  { get; set; }
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
        Console.WriteLine("Sprzęt: " + sprzęt.ToString() + "Użytkownik: " + użytkownik.ToString() );
    }
    
}
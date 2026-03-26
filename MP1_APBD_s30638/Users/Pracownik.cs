namespace MP1_APBD_s30638.Users;

public class Pracownik : Użytkownik
{
    private string Stanowisko { get; set; }

    public Pracownik(string imie, string nazwisko, TypUżytkownika typ, string stanowisko) : base(imie, nazwisko, typ)
    {
        Stanowisko = stanowisko;
    }
    
    public override string ToString()
    {
        return "Pracownik \n" + "Imie: " + Imie + "\n" + "Nazwisko: " + Nazwisko + "\n" + "Stanowwisko: " + Stanowisko + "\n";
    }
}
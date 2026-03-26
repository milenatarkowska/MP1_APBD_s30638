namespace MP1_APBD_s30638.Users;

public class Student : Użytkownik
{
    private string NumerIndeksu { get; set; }
    private int SemestrStudiów { get; set; }
    private int RokStudiów { get; set; }


    public Student(string imie, string nazwisko, TypUżytkownika typ, string numerIndeksu, int semestrStudiów, int rokStudiów) : base(imie, nazwisko, typ)
    {
        NumerIndeksu = numerIndeksu;
        SemestrStudiów = semestrStudiów;
        RokStudiów = rokStudiów;
    }

    public override string ToString()
    {
        return "Student \n" + "Imie: " + Imie + "\n" + "Nazwisko: " + Nazwisko + "\n" + "Numer indeksu: " + NumerIndeksu + "\n";
    }
}
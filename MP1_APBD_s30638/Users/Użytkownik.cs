namespace MP1_APBD_s30638.Users;

public abstract class Użytkownik
{
   protected string Imie { get; set; }
   protected string Nazwisko { get; set; }
   protected TypUżytkownika Typ { get; set; }

   protected Użytkownik(string imie, string nazwisko, TypUżytkownika typ)
       {
           Imie = imie;
           Nazwisko = nazwisko;
           Typ = typ;
       }
}
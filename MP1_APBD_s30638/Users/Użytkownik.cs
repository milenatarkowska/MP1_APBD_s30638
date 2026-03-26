namespace MP1_APBD_s30638.Users;

public abstract class Użytkownik
{
   public string Imie { get; private set; }
   public string Nazwisko { get; private set; }
   protected string Id {get; set;}
   protected TypUżytkownika Typ { get; set; }

   protected Użytkownik(string imie, string nazwisko, TypUżytkownika typ)
       {
           Id = Guid.NewGuid().ToString();
           Imie = imie;
           Nazwisko = nazwisko;
           Typ = typ;
       }
   
}
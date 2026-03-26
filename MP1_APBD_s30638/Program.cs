using MP1_APBD_s30638.Users;
using MP1_APBD_s30638.Items;
using Monitor = MP1_APBD_s30638.Items.Monitor;

namespace MP1_APBD_s30638;

public class Program
{
    static void Main(String[] args)
    {
        Console.WriteLine("========== SYSTEM UCZELNIANY DO WYPOŻYCZANIA SPRZĘTU ELEKTRONICZNEGO ==========");

        var serwis = new Serwis();
        
        Console.WriteLine("DODAWANIE SPRZĘTU");
        var macbook = new Komputer("MacBook Pro", StatusSprzętu.Dostępny, "Apple", "12345ABCDE", "M5 PRO", 48, "Mac OS", TypKomputera.Laptop);
        var pc = new Komputer("Dell Pro MAx Tower T2 Ultra 9", StatusSprzętu.Dostępny, "Dell", "09876MLKIU", "Intel Core Ultra 9 285", 32, "Windows 11 Pro", TypKomputera.Desktop);
        var monitor = new Monitor("Samsung Odyssey OLED G9", StatusSprzętu.Dostępny, "Samsung", "10293UHBGT", 49, "5120 x 1440");
        var projektor = new Projektor("Epson EH-TW840", StatusSprzętu.Dostępny, "Epson", "67543VSKTE", 4000, "16000:1");
        
        serwis.DodajSprzęt(macbook);
        serwis.DodajSprzęt(pc);
        serwis.DodajSprzęt(monitor);
        serwis.DodajSprzęt(projektor);
        
        Console.WriteLine("DODAWANIE UŻYTKOWNIKÓW");
        var student1 = new Student("Anna", "Nowak", TypUżytkownika.Student, "s12345", 5, 3);
        var student2 = new Student("Jan", "Kowalski", TypUżytkownika.Student, "s09876", 2, 1);
        var wykładowca = new Pracownik("Piotr", "Cymer", TypUżytkownika.Wykładowca, "Profesor uczelni");
        var pracownikAdministracji = new Pracownik("Katarzyna", "Wojciechowska", TypUżytkownika.PracownikAdministracji,
            "Specjalista ds. rekrutacji");
        
        serwis.DodajUżytkownika(student1);
        serwis.DodajUżytkownika(student2);
        serwis.DodajUżytkownika(wykładowca);
        serwis.DodajUżytkownika(pracownikAdministracji);
        
        Console.WriteLine("WYPOŻYCZANIE");
        serwis.Wypożycz(macbook, student1);
        Console.WriteLine("\n");
        serwis.Wypożycz(monitor, student1);
        Console.WriteLine("\n");
        serwis.Wypożycz(pc, student1); //nie powinno działac
        Console.WriteLine("\n");
        serwis.Wypożycz(monitor, student2); //nie powinno działac
        
        Console.WriteLine("\n");
        
        Console.WriteLine("WYŚWIETLANIE LISTY CAŁEGO SPRZĘTU ZE STATUSEM");
        serwis.WyświetlCałySprzęt();
        
        Console.WriteLine("\n");
        
        Console.WriteLine("USTAWIENIE SPRZĘTU JAKO NIEDOSTĘPNY");
        projektor.UstawJakoNiedostępny();
        
        Console.WriteLine("\n");
        
        Console.WriteLine("ZWROTY");
        serwis.Zwróć(macbook); //terminowy
        Console.WriteLine("\n");
        serwis.Zwróć(monitor); //po terminie
        
        Console.WriteLine("\n");
        
        Console.WriteLine("WYŚWIETLANIE LISTY SPRZĘTU DOSTĘPNEGO DO WYPOŻYCZENIA");
        serwis.WyświetlDostępne();
        
        Console.WriteLine("\n");
        
        Console.WriteLine("AKTYWNE WYPOŻYCZENIA DLA UŻYTKOWNIKA");
        serwis.WyswietlAktywneDlaUzytkownika(student1);
        
        Console.WriteLine("\n");
        
        Console.WriteLine("PRZETERMINOWANE WYPOŻYCZENIA");
        serwis.WyswietlPrzeterminowane();
        
        Console.WriteLine("\n");
        
        Console.WriteLine("RAPORT KOŃCOWY");
        serwis.GenerujRaport();
    }
}
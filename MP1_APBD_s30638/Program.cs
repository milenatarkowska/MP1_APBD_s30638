using MP1_APBD_s30638.Users;
using MP1_APBD_s30638.Items;
using Monitor = MP1_APBD_s30638.Items.Monitor;

namespace MP1_APBD_s30638;

public class Program
{
    static void Main(String[] args)
    {
        Console.WriteLine("========== SYSTEM UCZELNIANY DO WYPOŻYCZANIA SPRZĘTU ELEKTRONICZNEGO ==========");

        var Serwis = new Serwis();
        
        Console.WriteLine("DODAWANIE SPRZĘTU");
        var macbook = new Komputer("MacBook Pro", StatusSprzętu.Dostępny, "Apple", "12345ABCDE", "M5 PRO", 48, "Mac OS", TypKomputera.Laptop);
        var pc = new Komputer("Dell Pro MAx Tower T2 Ultra 9", StatusSprzętu.Dostępny, "Dell", "09876MLKIU", "Intel Core Ultra 9 285", 32, "Windows 11 Pro", TypKomputera.Desktop);
        var monitor = new Monitor("Samsung Odyssey OLED G9", StatusSprzętu.Dostępny, "Samsung", "10293UHBGT", 49, "5120 x 1440");
        var projektor = new Projektor("Epson EH-TW840", StatusSprzętu.Dostępny, "Epson", "67543VSKTE", 4000, "16000:1");
        
        Serwis.DodajSprzęt(macbook);
        Serwis.DodajSprzęt(pc);
        Serwis.DodajSprzęt(monitor);
        Serwis.DodajSprzęt(projektor);
        
        Console.WriteLine("DODAWANIE UŻYTKOWNIKÓW");
        var student1 = new Student("Anna", "Nowak", TypUżytkownika.Student, "s12345", 5, 3);
        var student2 = new Student("Jan", "Kowalski", TypUżytkownika.Student, "s09876", 2, 1);
        var wykładowca = new Pracownik("Piotr", "Cymer", TypUżytkownika.Wykładowca, "Profesor uczelni");
        var pracownikAdministracji = new Pracownik("Katarzyna", "Wojciechowska", TypUżytkownika.PracownikAdministracji,
            "Specjalista ds. rekrutacji");
        
        Serwis.DodajUżytkownika(student1);
        Serwis.DodajUżytkownika(student2);
        Serwis.DodajUżytkownika(wykładowca);
        Serwis.DodajUżytkownika(pracownikAdministracji);
        
        Console.WriteLine("WYPOŻYCZANIE");
        var wypożyczenie1 = new Wypożyczenie(student1, macbook);
        Console.WriteLine("\n");
        var wypożyczenie2 = new Wypożyczenie(student1, monitor);
        Console.WriteLine("\n");
        var wypożyczenie3 = new Wypożyczenie(student1, pc); // powinno nie działać
        Console.WriteLine("\n");
        var wypożyczenie4 = new Wypożyczenie(student2, macbook); //powinno nie działać
        
        Console.WriteLine("WYŚWIETLANIE LISTY CAŁEGO SPRZĘTU ZE STATUSEM");
        Serwis.WyświetlCałySprzęt();
        
        Console.WriteLine("\n");
        
        Console.WriteLine("WYŚWIETLANIE LISTY SPRZĘTU DOSTĘPNEGO DO WYPOŻYCZENIA");
        Serwis.WyświetlDostępne();
    }
}
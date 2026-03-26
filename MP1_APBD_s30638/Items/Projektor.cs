namespace MP1_APBD_s30638.Items;

public class Projektor : Sprzęt
{
    private int Jasnosc { get; set; }
    private string Kontrast { get; set; }

    public Projektor(string nazwa, StatusSprzętu status, string producent, string numerSeryjny, int jasnosc, string kontrast) : base(nazwa, status, producent, numerSeryjny)
    {
        Jasnosc = jasnosc;
        Kontrast = kontrast;
    }
    
    public override string ToString()
    {
        return "Projektor \n" + "Nazwa: " + Nazwa + "\n" + "Producent: " + Producent + "\n"  + "NumerSeryjny: " + NumerSeryjny+ "\n";
    }
}
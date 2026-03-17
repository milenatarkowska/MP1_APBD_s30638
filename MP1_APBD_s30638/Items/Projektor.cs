namespace MP1_APBD_s30638.Items;

public class Projektor : Sprzęt
{
    private int Jasnosc { get; set; }

    public Projektor(string nazwa, StatusSprzętu status, string producent, string numerSeryjny, int jasnosc) : base(nazwa, status, producent, numerSeryjny)
    {
        Jasnosc = jasnosc;
    }
}
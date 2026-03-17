namespace MP1_APBD_s30638.Items;

public class Komputer : Sprzęt
{
    private string Procesor { get; set; }
    private int RamGB { get; set; }
    private string SystemOperacyjny { get; set; }
    private TypKomputera TypKomputera { get; set; }

    public Komputer(string nazwa, StatusSprzętu status, string producent, string numerSeryjny, string procesor, int ramGb, string systemOperacyjny, TypKomputera typKomputera) : base(nazwa, status, producent, numerSeryjny)
    {
        Procesor = procesor;
        RamGB = ramGb;
        SystemOperacyjny = systemOperacyjny;
        TypKomputera = typKomputera;
    }
}
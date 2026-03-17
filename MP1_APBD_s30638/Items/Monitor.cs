namespace MP1_APBD_s30638.Items;

public class Monitor : Sprzęt
{
    private double Przekatna { get; set; }
    private string Rozdzielczosc { get; set; }

    public Monitor(string nazwa, StatusSprzętu status, string producent, string numerSeryjny, double przekatna, string rozdzielczosc) : base(nazwa, status, producent, numerSeryjny)
    {
        Przekatna = przekatna;
        Rozdzielczosc = rozdzielczosc;
    }
}
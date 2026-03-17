namespace MP1_APBD_s30638.Items;

public abstract class Sprzęt
{
    private string Id {get;}
    private string Nazwa { get; set; }
    private StatusSprzętu Status {get; set;}
    private string Producent {get; set;}
    private string NumerSeryjny {get; set;}

    protected Sprzęt(string nazwa, StatusSprzętu status, string producent, string numerSeryjny)
    {
        Nazwa = nazwa;
        Status = status;
        Producent = producent;
        NumerSeryjny = numerSeryjny;
        Id = Guid.NewGuid().ToString();
    }
}
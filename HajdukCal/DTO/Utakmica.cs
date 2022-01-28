namespace HajdukCal.DTO;

public class Utakmica
{
    public string Naziv { get; set; }
    public string Opis { get; set; }
    public DateOnly? Datum { get; set; }
    public TimeOnly? Vrijeme { get; set; }
    public Stadion Stadion { get; set; }
    public Natjecanje Natjecanje { get; set; }
    public Mjesto? Mjesto { get; set; }
}
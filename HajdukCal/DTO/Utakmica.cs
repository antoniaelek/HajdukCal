namespace HajdukCal.DTO;

public class Utakmica
{
    public long Id { get; set; }
    public string Naziv { get; set; }
    public string Opis { get; set; }
    public DateOnly? Datum { get; set; }
    public TimeOnly? Vrijeme { get; set; }
    public Stadion Stadion { get; set; }
    public Natjecanje Natjecanje { get; set; }
}
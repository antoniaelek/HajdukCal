using System.Globalization;
using HajdukCal.DTO;
using Newtonsoft.Json;

namespace HajdukCal.Service.Hajduk;

public partial class OdigranaUtakmica
{
    [JsonProperty("url_vj")] public string UrlVj { get; set; }

    [JsonProperty("url_eng_vj")] public string UrlEngVj { get; set; }

    [JsonProperty("klub_domacin")] public string KlubDomacin { get; set; }

    [JsonProperty("klub_gost")] public string KlubGost { get; set; }

    [JsonProperty("rezultat")] public string Rezultat { get; set; }

    [JsonProperty("status_utakmice")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long StatusUtakmice { get; set; }

    [JsonProperty("rezultat_penali")] public string RezultatPenali { get; set; }

    [JsonProperty("status_penali")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long StatusPenali { get; set; }

    [JsonProperty("status_ponistena")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long StatusPonistena { get; set; }

    [JsonProperty("napomena_bb")] public string NapomenaBb { get; set; }

    [JsonProperty("datum_utakmice")] public string DatumUtakmice { get; set; }

    [JsonProperty("datum_utakmice_eng")] public string DatumUtakmiceEng { get; set; }

    [JsonProperty("id_utakmice")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long IdUtakmice { get; set; }

    [JsonProperty("tip_utakmice")] public TipUtakmice TipUtakmice { get; set; }

    [JsonProperty("tip_utakmice_eng")] public TipUtakmiceEng TipUtakmiceEng { get; set; }
    
    [JsonProperty("dan")]
    public string Dan { get; set; }
    
    [JsonProperty("dan_eng")]
    public string DanEng { get; set; }
    
    [JsonProperty("strijelci")]
    public string Strijelci { get; set; }
    
    [JsonProperty("broj_gledatelja")]
    public string BrojGledatelja { get; set; }
    
    [JsonProperty("broj_gledatelja_eng")]
    public string BrojGledateljaEng { get; set; }
    
    [JsonProperty("prosjek_godina")]
    public string ProsjekGodina { get; set; }
    
    [JsonProperty("zuti_kartoni")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long ZutiKartoni { get; set; }
    
    [JsonProperty("crveni_kartoni")]
    [JsonConverter(typeof(ParseStringConverter))]
    public long CrveniKartoni { get; set; }
    
    [JsonProperty("sudac_prezime")]
    public string SudacPrezime { get; set; }

    public Utakmica ToDTO(ProtekliMisec misec)
    {
        DateOnly? gameDate = default;
        TimeOnly? gameTime = default;
        if (DateOnly.TryParseExact($"{DatumUtakmiceEng} {misec.GetYear()}", "MMMM d yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None, out var date))
        {
            gameDate = date;
        }

        gameTime = new TimeOnly(17, 0);

        return new DTO.Utakmica()
        {
            Naziv = $"{KlubDomacin} - {KlubGost}",
            Natjecanje = TipUtakmice.ToDTO(),
            Stadion = KlubDomacin == "Hajduk" ? DTO.Stadion.Doma : DTO.Stadion.Gost,
            Opis = Rezultat,
            Datum = gameDate,
            Vrijeme = gameTime
        };
    }
}
namespace HajdukCal.Service.Hajduk;

public static class EnumConverters
{
    public static DTO.Natjecanje ToDTO(this TipUtakmice natjecanje)
    {
        switch (natjecanje)
        {
            case TipUtakmice.Eur:
                return DTO.Natjecanje.Europa;
            case TipUtakmice.Kup:
                return DTO.Natjecanje.Kup;
            case TipUtakmice.Prv:
                return DTO.Natjecanje.Prvenstvo;
            default:
                return DTO.Natjecanje.Nepoznato;
        }
    }
    
    public static DTO.Natjecanje ToDTO(this Natjecanje natjecanje)
    {
        switch (natjecanje)
        {
            case Natjecanje.Eur:
                return DTO.Natjecanje.Europa;
            case Natjecanje.Kup:
                return DTO.Natjecanje.Kup;
            case Natjecanje.Prv:
                return DTO.Natjecanje.Prvenstvo;
            default:
                return DTO.Natjecanje.Nepoznato;
        }
    }
    
    public static DTO.Stadion ToDTO(this Stadion stadion)
    {
        switch (stadion)
        {
            case Stadion.Doma:
                return DTO.Stadion.Doma;
            case Stadion.Gost:
                return DTO.Stadion.Gost;
            default:
                return DTO.Stadion.Nepoznato;
        }
    }
}
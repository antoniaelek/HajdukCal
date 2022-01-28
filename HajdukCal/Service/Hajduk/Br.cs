namespace HajdukCal.Service.Hajduk;

public partial struct Br
{
    public Rezultat4? Enum;
    public long? Integer;

    public static implicit operator Br(Rezultat4 Enum) => new Br {Enum = Enum};
    public static implicit operator Br(long Integer) => new Br {Integer = Integer};
}
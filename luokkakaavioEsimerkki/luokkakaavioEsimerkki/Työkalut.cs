using System;

namespace luokkakaavioEsimerkki;

class Työkalu
{
    
    public Työkalu() { }

    public Työkalu(string nimi)
    {
        Nimi = nimi ?? throw new ArgumentNullException(nameof(nimi));
        Tyyppi = string.Empty;
    }

    public Työkalu(string nimi, string tyyppi)
    {
        Nimi = nimi ?? throw new ArgumentNullException(nameof(nimi));
        Tyyppi = tyyppi ?? throw new ArgumentNullException(nameof(tyyppi));
    }

    public string Nimi { get; set; }
    public string Tyyppi { get; set; } = string.Empty;

    public void Info()
    {
        if (string.IsNullOrEmpty(Tyyppi))
            Console.WriteLine($"Työkalu: {Nimi}");
        else
            Console.WriteLine($"Työkalu: {Nimi}, tyyppi: {Tyyppi}");
    }

    public override string ToString() => string.IsNullOrEmpty(Tyyppi) ? Nimi : $"{Nimi} ({Tyyppi})";
}



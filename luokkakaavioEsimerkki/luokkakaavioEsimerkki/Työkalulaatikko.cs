using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace luokkakaavioEsimerkki;

class Työkalulaatikko
{
    
    public Työkalulaatikko() { }

    public Työkalulaatikko(string nimi)
    {
        Nimi = nimi ?? throw new ArgumentNullException(nameof(nimi));
        Työkalut = new List<Työkalu>();
    }

    public string Nimi { get; set; }

    
    public List<Työkalu> Työkalut { get; set; } = new List<Työkalu>();

    public virtual void Info()
    {
        Console.WriteLine($"Työkalulaatikko: {Nimi} ({Työkalut.Count} työkalua)");
    }




    private string _laatikko;

    private List<Työkalu> _työkalut = new List<Työkalu>();

    public void LisääTyökalu(Työkalu työkalu)
    {
        if (työkalu == null) throw new ArgumentNullException(nameof(työkalu));
        Työkalut.Add(työkalu);
    }

    public bool PoistaTyökalu(Työkalu työkalu)
    {
        if (työkalu == null) throw new ArgumentNullException(nameof(työkalu));
        return Työkalut.Remove(työkalu);
    }

    public void TallennaTiedostoon(string polku)
    {
        if (string.IsNullOrWhiteSpace(polku)) throw new ArgumentException("Invalid path", nameof(polku));
        var options = new JsonSerializerOptions { WriteIndented = true };
        var json = JsonSerializer.Serialize(this, options);
        File.WriteAllText(polku, json);
    }

    public static Työkalulaatikko LataaTiedostosta(string polku)
    {
        if (string.IsNullOrWhiteSpace(polku)) throw new ArgumentException("Invalid path", nameof(polku));
        if (!File.Exists(polku)) throw new FileNotFoundException("File not found", polku);
        var json = File.ReadAllText(polku);
        var box = JsonSerializer.Deserialize<Työkalulaatikko>(json);
        return box ?? new Työkalulaatikko();
    }
}

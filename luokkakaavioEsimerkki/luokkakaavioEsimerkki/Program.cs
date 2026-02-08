using System;
using luokkakaavioEsimerkki;

class Program
{
    static void Main()
    {
        var laatikko = new Työkalulaatikko("Punainen laatikko"); 
        laatikko.Info();

        var tyokalu1 = new Työkalu("Vasara");
        var tyokalu2 = new Työkalu("Ruuvimeisseli");

        laatikko.LisääTyökalu(tyokalu1);
        laatikko.LisääTyökalu(tyokalu2);

        Console.WriteLine("Laatikon sisältö:");
        foreach (var t in laatikko.Työkalut)
            Console.WriteLine($" - {t}");

        var polku = "laatikko.json";
        laatikko.TallennaTiedostoon(polku);
        Console.WriteLine($"Tallennettu {polku}");

        var ladattu = Työkalulaatikko.LataaTiedostosta(polku);
        Console.WriteLine("Ladattu laatikko:");
        ladattu.Info();
        foreach (var t in ladattu.Työkalut)
            Console.WriteLine($" * {t}");
    }
}

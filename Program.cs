using CA220103;
using System.Text;

List<JatekosLovese> lista = new();

Feladat04();
Feladat05();
Feladat07();
Feladat09();
Feladat10();
Feladat11_12_13();


void Feladat11_12_13()
{
    var jl = lista.GroupBy(x => x.Nev);
    Console.WriteLine("11. feladat: Lövések száma:");
    foreach (var j in jl)
    {
        Console.WriteLine($"\t{j.Key} - {j.Count()} db");
    }

    Console.WriteLine("12. feladat: Átlagpontszámok:");
    (string Nev, float Atlag) gyoztes = ("", 0F);
    foreach (var j in jl)
    {
        var jn = j.Key;
        var jap = j.Average(x => x.Pontszam);
        if (jap > gyoztes.Atlag) gyoztes = (jn, jap);
        Console.WriteLine($"\t{jn} - {jap} db");
    }
    Console.WriteLine($"13. feladat: A játék nyertese: {gyoztes.Nev}");
}
void Feladat10()
{
    int jsz = lista.DistinctBy(x => x.Nev).Count();
    Console.WriteLine($"10. feladat: Játékosok száma: {jsz}");
}
void Feladat09()
{
    int np = lista.Count(x => x.Pontszam == 0);
    Console.WriteLine($"9. feladat: Nulla pontos lövések száma: {np} db");
}
void Feladat04()
{

    using StreamReader sr = new(
        "..\\..\\..\\Resources\\lovesek.txt",
        Encoding.UTF8);

    var es = sr.ReadLine().Split(';');

    JatekosLovese.Celtabla = (float.Parse(es[0]), float.Parse(es[1]));

    int ssz = 1;
    while (!sr.EndOfStream)
    {
        lista.Add(new JatekosLovese(ssz, sr.ReadLine()));
        ssz++;
    }
}
void Feladat05()
{
    Console.WriteLine($"5. feladat: Lövések száma: {lista.Count} db");
}
void Feladat07()
{
    var gy = lista.Where(x => x.Tavolsag == lista.Min(y => y.Tavolsag)).First();
    Console.WriteLine("7. feladat: Legpontosabb lövés: \n\t" +
        $"{gy.Sorszam}.; {gy.Nev}; x={gy.Loves.X}; y={gy.Loves.Y}; távolság:{gy.Tavolsag}");
}
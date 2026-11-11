List<Videogames> videogames = [];

const string FilePath = "..\\..\\..\\data\\videogames.csv";

using StreamReader sr = new StreamReader(FilePath);
_ = sr.ReadLine();

while (!sr.EndOfStream)
{
    var tmp = sr.ReadLine().Split(',');

    videogames.Add(new()
    {
        Cim = tmp[0],
        Mufaj = tmp[1],
        KiadasDatum = Convert.ToDateTime(tmp[2]),
        AktivJatekosok = Convert.ToInt32(tmp[3]),
        Ertekeles = double.Parse(tmp[4].Replace('.', ','))
    });
        
}
//1.feladat
var ertekeles = videogames.Count(v => v.Ertekeles > 4.5);
Console.WriteLine($"1.feladat: az össze olyan játek, amiknek 4.5-nel nagyobb az ertekelese: {ertekeles}");

//2.feladat
var maxaktiv = videogames.MaxBy(v => v.AktivJatekosok);
Console.WriteLine($"2.feladat: legtobb aktiv jatekos: \n{maxaktiv}");

//3.feladat
var vaneregebbi = videogames.Any(v => v.KiadasDatum < new DateTime(2020, 1, 1));
Console.WriteLine($"3.feladat: van-e regebbi jatek?: {(vaneregebbi ? "van" : "nincs")}");

//4.feladat
var atlag = videogames.Average(v => v.Ertekeles);
Console.WriteLine($"4.feladat: összes jatek altagos ertekelese: {atlag:0.00}/5.0");

//5.feladat
var egyetlen = videogames.Single(v => v.Cim == "Cyber City 2077");
Console.WriteLine($"5.feladat: \n{egyetlen}");

//9.feladat
var csoport = videogames.GroupBy(p => p.Mufaj);
Console.WriteLine("9.feladat: játékok műfajonként:");
foreach (var jatekok in csoport)
{
    Console.WriteLine($"\t{jatekok.Key} ({jatekok.Count()} db)");
}




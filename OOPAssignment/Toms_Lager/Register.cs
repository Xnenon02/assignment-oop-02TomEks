using System;
using System.Linq;
using Toms_Lager;

namespace Toms_Lager
{
    internal class Register
    {
        private Lager _lager;

        public Register(Lager lager)
        {
            _lager = lager;
        }

        public void RedigeraProdukt()
        {
            Console.Write("Ange produkt-ID att redigera: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ogiltigt ID.");
                return;
            }

            var produkt = _lager.Produkter.FirstOrDefault(p => p.Id == id);
            if (produkt == null)
            {
                Console.WriteLine("Ingen produkt hittades med det ID:t.");
                return;
            }

            Console.WriteLine($"Vald produkt: {produkt.Namn}, Pris: {produkt.Pris}, Antal: {produkt.AntalLager}");
            Console.WriteLine("1. Ändra namn");
            Console.WriteLine("2. Ändra pris");
            Console.WriteLine("3. Ändra antal i lager");
            Console.Write("Välj alternativ: ");
            string val = Console.ReadLine();

            switch (val)
            {
                case "1":
                    Console.Write("Nytt namn: ");
                    produkt.Namn = Console.ReadLine();
                    break;

                case "2":
                    Console.Write("Nytt pris: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal nyttPris))
                        produkt.Pris = nyttPris;
                    else
                        Console.WriteLine("Ogiltigt pris.");
                    break;

                case "3":
                    Console.Write("Nytt antal: ");
                    if (int.TryParse(Console.ReadLine(), out int nyttAntal))
                        produkt.AntalLager = nyttAntal;
                    else
                        Console.WriteLine("Ogiltigt antal.");
                    break;

                default:
                    Console.WriteLine("Ogiltigt val.");
                    return;
            }

            
            _lager.SparaProdukterTillCsv("C:\\Users\\minep\\Desktop\\assignment-oop-02TomEks\\OOPAssignment\\Toms_Lager\\produkter.csv");
            Console.WriteLine("Produkten har uppdaterats och sparats.");
        }

        public void LäggTillProdukt()
        {
            var nyProdukt = new Produkt();

            Console.Write("Ange produkt-ID: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Ogiltigt ID.");
                return;
            }
            if (_lager.Produkter.Any(p => p.Id == id))
            {
                Console.WriteLine("En produkt med detta ID finns redan.");
                return;
            }
            nyProdukt.Id = id;

            Console.Write("Ange produktnamn: ");
            nyProdukt.Namn = Console.ReadLine();

            Console.Write("Ange pris: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal pris))
            {
                Console.WriteLine("Ogiltigt pris.");
                return;
            }
            nyProdukt.Pris = pris;

            Console.Write("Ange antal i lager: ");
            if (!int.TryParse(Console.ReadLine(), out int antal))
            {
                Console.WriteLine("Ogiltigt antal.");
                return;
            }
            nyProdukt.AntalLager = antal;

            
            _lager.Produkter.Add(nyProdukt);

            //fråga chatgpt att hjälpa lösa vart jag skulle lägga till nedanstånde kod för att spara nya produkter
            _lager.SparaProdukterTillCsv("C:\\Users\\minep\\Desktop\\assignment-oop-02TomEks\\OOPAssignment\\Toms_Lager\\produkter.csv");

            Console.WriteLine("Ny produkt har lagts till och sparats.");
        }
    }
}

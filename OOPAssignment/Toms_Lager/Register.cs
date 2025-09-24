using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Toms_Lager;

namespace Toms_Lager
{
    internal class Register

    {
        private string exeFolder;
        private string projectFolder;
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

            // Add product to list
            _lager.Produkter.Add(nyProdukt);

            // Save changes to CSV
            _lager.SparaProdukterTillCsv("produkter.csv");

            Console.WriteLine("Ny produkt har lagts till och sparats.");
            string exeFolder = AppContext.BaseDirectory;
            // Go up three levels from exe folder to reach Toms_Lager
            string projectFolder = Path.GetFullPath(Path.Combine(exeFolder, "..", "..", ".."));
            string filePath = Path.Combine(projectFolder, "produkter.csv");
            _lager.SparaProdukterTillCsv(filePath);
        }
        public void VisaOrdrarMedProduktInfo(List<Order> orders)
        {
            foreach (var order in orders)
            {
                var produkt = _lager.Produkter.FirstOrDefault(p => p.Id == order.ProduktId);
                if (produkt != null)
                {
                    Console.WriteLine($"Kund: {order.KundNamn}, Produkt: {produkt.Namn}, Pris: {produkt.Pris}, Antal: {order.Antal}");
                }
                else
                {
                    Console.WriteLine($"Kund: {order.KundNamn}, ProduktId: {order.ProduktId} (Produkt ej hittad), Antal: {order.Antal}");
                }
            }
        }
        public void BearbetaOrdrar(List<Order> orders, Lager lager)
        {
            foreach (var order in orders)
            {
                var produkt = lager.Produkter.FirstOrDefault(p => p.Id == order.ProduktId);
                if (produkt == null)
                {
                    Console.WriteLine($"Produkt med ID {order.ProduktId} hittades inte för kund {order.KundNamn}.");
                    continue;
                }

                if (produkt.AntalLager >= order.Antal)
                {
                    produkt.AntalLager -= order.Antal;
                    Console.WriteLine($"Order från {order.KundNamn}: {order.Antal} st {produkt.Namn} - godkänd.");
                }
                else
                {
                    Console.WriteLine($"Order från {order.KundNamn}: {order.Antal} st {produkt.Namn} - EJ godkänd. Endast {produkt.AntalLager} i lager.");
                }
            }

            // Spara uppdaterat lager
            lager.SparaProdukterTillCsv("produkter_uppdaterat.csv");
            Console.WriteLine("Lageruppdatering sparad till produkter_uppdaterat.csv.");
        }
    }
}

    

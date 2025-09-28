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
        public void RestockeraProdukt()
        {
            Console.WriteLine("Vill du:");
            Console.WriteLine("1. Fylla på en enskild produkt");
            Console.WriteLine("2. Fylla på alla produkter");
            Console.Write("Välj alternativ (1 eller 2): ");
            string val = Console.ReadLine();

            switch (val)
            {
                case "1":
                    RestockeraEnskildProdukt();
                    break;
                case "2":
                    RestockeraAllaProdukter();
                    break;
                default:
                    Console.WriteLine("Ogiltigt val.");
                    break;
            }
        }

        private void RestockeraEnskildProdukt()
        {
            Console.Write("Ange produkt-ID att fylla på: ");
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

            Console.WriteLine($"Nuvarande antal av {produkt.Namn}: {produkt.AntalLager}");
            Console.Write("Hur många vill du lägga till i lager? ");
            if (!int.TryParse(Console.ReadLine(), out int antal))
            {
                Console.WriteLine("Ogiltigt antal.");
                return;
            }

            produkt.AntalLager += antal;

            // Spara ändringarna till CSV
            SparaTillCsv();

            Console.WriteLine($"Produkten {produkt.Namn} har fyllts på. Nytt antal: {produkt.AntalLager}");
        }

        public void RestockeraAllaProdukter() // chatgpt hjälpte lite här och snabb med att fixa så att jag kan fylla på alla produkter med en under menu
        {
            Console.Write("Hur många vill du lägga till för varje produkt i lager? ");
            if (!int.TryParse(Console.ReadLine(), out int antal))
            {
                Console.WriteLine("Ogiltigt antal.");
                return;
            }

            foreach (var produkt in _lager.Produkter)
            {
                produkt.AntalLager += antal;
                Console.WriteLine($"Produkten {produkt.Namn} har fyllts på med {antal}. Nytt antal: {produkt.AntalLager}");
            }

            // Spara ändringarna till CSV
            SparaTillCsv();

            Console.WriteLine("Alla produkter har fyllts på och lagret har sparats.");
        }

        private void SparaTillCsv()
        {
            string exeFolder = AppContext.BaseDirectory;
            string projectFolder = Path.GetFullPath(Path.Combine(exeFolder, "..", "..", ".."));
            string filePath = Path.Combine(projectFolder, "produkter.csv");
            _lager.SparaProdukterTillCsv(filePath);
        }





    }

}
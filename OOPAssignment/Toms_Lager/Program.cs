using Toms_Lager;

internal class Program
{
    private static void Main()
    {
        Lager lager = new Lager();
        lager.LaddaProdukterFranCsv("produkter.csv");

        Register register = new Register(lager);

        bool kör = true;
        while (kör)
        {
            Console.WriteLine("=== LAGERMENY ===");
            Console.WriteLine("1. Visa alla produkter");
            Console.WriteLine("2. Avsluta");
            Console.WriteLine("3. Redigera produkt");
            Console.WriteLine("4 Lägg till ny produkt");
            Console.WriteLine("5 Välj alternativ: ");
            string val = Console.ReadLine();

            if (val == "1")
                lager.VisaAllaProdukter();
            else if (val == "2")

                kör = false;
            else if (val == "3")
            {
                register.RedigeraProdukt();
            }
            else if (val == "4")
            {
                register.LäggTillProdukt();
                
            }
            else if (val == "5")
            {
                Console.WriteLine("inte tillgänglit för nuvarande eller någonsin");
            }
            else
            {
                Console.WriteLine("Ogiltigt val, försök igen.");
            }
        }
    }
}
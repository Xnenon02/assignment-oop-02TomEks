using Toms_Lager;

internal class Program
{
    // to do mer fel söking program så att den läser korrekt i csv filer
    // to do en restock function
    // to do mer dumma kommentarer
    private static void Main()
    {
        Lager lager = new Lager();

        lager.LaddaProdukterFranCsv("produkter.csv");

        Register register = new Register(lager);

        bool kör = true;
        while (kör)
        {
            Console.WriteLine("=== LAGERMENY ===");
            Console.WriteLine("1.Visa alla produkter");
            Console.WriteLine("2.Redigera produkt");
            Console.WriteLine("3.Lägg till ny produkt");
            Console.WriteLine("4 Order Lista");
            Console.WriteLine("5 Bearbeta order");
            Console.WriteLine("6 Restockera produkt");
            Console.WriteLine("7 Avsluta");
            string val = Console.ReadLine();

            switch (val)
            {
                case "1":
                    lager.VisaAllaProdukter();
                    break;

                case "2":
                    register.RedigeraProdukt();
                    break;

                case "3":
                    register.LäggTillProdukt();
                    break;

                case "4":
                    {
                        var orderService = new OrderService("ordrar.csv");
                        var orders = orderService.LäsOrder();
                        register.VisaOrdrarMedProduktInfo(orders);
                        break;
                    }

                case "5":
                    {
                        var orderService = new OrderService("ordrar.csv");
                        var orders = orderService.LäsOrder();

                        register.BearbetaOrdrar(orders, lager);
                        break;
                    }

                case "6":
                    register.RestockeraProdukt();
                    break;

                case "7":
                    kör = false;
                    break;

                default:
                    Console.WriteLine("Ogiltigt val, försök igen.");
                    break;
            }
        }
    }
}
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

            if (val == "1")
                lager.VisaAllaProdukter();
            else if (val == "2")

                register.RedigeraProdukt();
            else if (val == "3")
            {
                register.LäggTillProdukt();
            }
            else if (val == "4") // drar fram listan
            {
                var orderService = new OrderService("ordrar.csv");
                var orders = orderService.LäsOrder();
                register.VisaOrdrarMedProduktInfo(orders);
            }
            else if (val == "5") // ser om det finns tillräckligt i lagret för dessa scalpers
            {
                var orderService = new OrderService("ordrar.csv");
                var orders = orderService.LäsOrder();

                register.BearbetaOrdrar(orders, lager);
            }else if (val == "6")
            {
                register.RestockeraProdukt();

            }


            else if (val == "7")
            {
                kör = false;
            }
            else
            {
                Console.WriteLine("Ogiltigt val, försök igen.");
            }
        }
    }
}
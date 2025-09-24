using System;
using System.Collections.Generic;
using System.IO;

namespace Toms_Lager
{
    public class OrderService
    {
        private readonly string _orderFil;

        public OrderService(string orderFil)
        {
            _orderFil = orderFil;
        }

        public List<Order> LäsOrder()
        {
            var orders = new List<Order>();

            if (!File.Exists(_orderFil))
            {
                Console.WriteLine($"Filen {_orderFil} finns inte.");
                return orders;
            }

            var lines = File.ReadAllLines(_orderFil);

            if (lines.Length < 2)
            {
                Console.WriteLine("Orderfilen är tom eller saknar data.");
                return orders;
            }

            for (int i = 1; i < lines.Length; i++) // Hoppa över header
            {
                var line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;

                var delar = line.Split(';');
                if (delar.Length < 3)
                {
                    Console.WriteLine($"Felaktig rad i orderfil: {line}");
                    continue;
                }

                string kundNamn = delar[0];
                if (!int.TryParse(delar[1], out int produktId))
                {
                    Console.WriteLine($"Felaktigt produkt-ID i rad: {line}");
                    continue;
                }
                if (!int.TryParse(delar[2], out int antal))
                {
                    Console.WriteLine($"Felaktigt antal i rad: {line}");
                    continue;
                }

                orders.Add(new Order
                {
                    KundNamn = kundNamn,
                    ProduktId = produktId,
                    Antal = antal
                });
            }

            return orders;
        }
       

    }
}

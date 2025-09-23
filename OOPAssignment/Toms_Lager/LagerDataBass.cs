using System;
using System.Collections.Generic;
using System.IO;

namespace Toms_Lager
{
    public class Produkt
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public decimal Pris { get; set; }
        public int AntalLager { get; set; }

    }

    public class Lager
    {
        public List<Produkt> Produkter { get; set; } = new List<Produkt>();

        public void LaddaProdukterFranCsv(string filnamn)
        {
            string[] rader = File.ReadAllLines(filnamn);
            for (int i = 1; i < rader.Length; i++)
            {
                string[] kolumner = rader[i].Split(';');
                Produkter.Add(new Produkt
                {
                    Id = int.Parse(kolumner[0]),
                    Namn = kolumner[1],
                    Pris = decimal.Parse(kolumner[2]),
                    AntalLager  = int.Parse(kolumner[3])
                });
            }
        }

        public void VisaAllaProdukter()
        {
            foreach (var produkt in Produkter)
            {
                Console.WriteLine($"ID: {produkt.Id}, Namn: {produkt.Namn}, Pris: {produkt.Pris} kr, Antal i lager: {produkt.AntalLager }");
            }
        }
    }
}

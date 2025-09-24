using System;

namespace Toms_Lager
{
    public class Order
    { // för dig som undar så är detta bara en typ av liten data holder
        public string KundNamn { get; set; }
        public int ProduktId { get; set; }
        public int Antal { get; set; }
    }
}

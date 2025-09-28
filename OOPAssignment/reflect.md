Reflektion över Toms_Lager
Planering

Jag började med att planera projektets struktur genom att identifiera huvudklasserna: Produkt, Order, Lager och Register. Fokus låg på att ha tydliga ansvarsområden för varje klass. Jag ritade upp en enkel flödesbild över hur användaren skulle interagera med systemet via menyval och hur dessa skulle kopplas till respektive metod i Register-klassen. Jag prioriterade grundfunktioner som att lägga till och visa produkter, och byggde därefter vidare med mer avancerade funktioner som orderhantering och restockning.

Problem

En av de svåraste delarna var att hantera användarens inmatning korrekt, särskilt vid konvertering av strängar till siffror. Det var lätt att få programmet att krascha om användaren skrev in fel typ av data. Jag löste det genom att konsekvent använda int.TryParse() och decimal.TryParse() istället för direkta konverteringar.

Ett annat problem var att hålla koden återanvändbar och att undvika upprepning — till exempel vid sparning till CSV. Detta löste jag genom att bryta ut en gemensam metod för det (SparaTillCsv()). Det uppstod också vissa problem med att få CSV-filen att bevara de nya ändringarna efter att programmet stängts ner. Det löste jag genom att spara filen på rätt plats varje gång en uppdatering sker.

Stolthet

Jag är mest stolt över att ha byggt ett system som är både användarvänligt och flexibelt. Jag lade till en undermeny för restock-funktionen där man kan välja att fylla på enskilda eller alla produkter — något som visar att jag kan tänka användarcentrerat och samtidigt skriva strukturerad kod som är lätt att bygga vidare på. Jag är också nöjd med hur jag använt LINQ-metoder för att effektivisera kodlogiken.

Reflektion för Väl Godkänt (VG)
Datastrukturer

Jag använde huvudsakligen List<Produkt> och List<Order> i mitt projekt. Dessa listor används för att lagra alla produkter respektive ordrar i minnesstrukturen under programmets gång.

Jag valde List<T> eftersom:

De har dynamisk storlek (jag vet inte i förväg hur många produkter som kommer att finnas).

De är enkla att söka i med LINQ-metoder som .FirstOrDefault() och .Any().

De stödjer iteration med foreach-loopar, vilket gör koden mer läsbar.

Alternativ:

Jag hade kunnat använda en Dictionary<int, Produkt> för snabbare uppslagning av produkter via ID. Det hade förbättrat prestandan något, men gjort viss logik mer komplex, särskilt när man ska spara tillbaka till CSV.

Arrays hade inte fungerat lika bra eftersom deras storlek är fast.

Clean Code och Struktur

Jag har försökt följa principerna för "Clean Code" så långt som möjligt, men jag är kanske inte den bästa på det ännu – så det är något jag vill utveckla vidare.

Klasser och metoder är namngivna tydligt efter vad de gör, t.ex. LäggTillProdukt(), RedigeraProdukt() och RestockeraAllaProdukter().

Jag bröt ut gemensam kod, t.ex. sparningslogiken, till en egen metod SparaTillCsv() för att undvika upprepning.

Jag delade upp restock-logiken i två metoder: en för enskild produkt (RestockeraEnskildProdukt) och en för alla produkter (RestockeraAllaProdukter). Båda kallas från en undermeny i RestockeraProdukt(), vilket gör koden mer modulär.

Variabelnamn som produkt, antal, id och projectFolder är valda för att tydligt visa vad de används till.

Jag kommenterade inte varje rad, men koden är självdokumenterande genom sina tydliga namn och struktur.

En annan sak jag kunde ha gjort bättre är att skapa en metod som kontrollerar att orderlistan visar korrekt värde — alltså att den inte bara letar efter produktnamn, utan även matchar priset och tilldelar rätt ID om det saknas. Det hade förbättrat robustheten i orderhanteringen.

Framtida utveckling

Projektet är uppbyggt för att kunna byggas vidare på utan att börja om från början. Några exempel:

Det är enkelt att lägga till fler funktioner i menygränssnittet genom att lägga till nya case i switch-satsen.

Klasserna har tydliga ansvarsområden. Register hanterar användarinteraktionen, medan Lager är ansvarig för datalagring.

Metoderna är korta och fokuserade, vilket gör dem enkla att testa och felsöka.

Jag har separerat produktdatahantering från ordrar, vilket gör det lätt att t.ex. lägga till kategorier, rabatter eller rapportgenerering i framtiden.

En sak som kan förbättras framöver är att lägga till bättre felhantering vid filinläsning och -sparning, samt att kanske refaktorera bort filvägshanteringen till en separat hjälparklass för att minska kodupprepning.



Denna reflektion är skapad som del av inlämningsuppgiften i kursen "Grundläggande objektorienterad programmering i C#" vid Yrkeshögskolan Campus Mölndal.
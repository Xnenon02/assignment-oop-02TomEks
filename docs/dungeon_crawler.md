# Alternativ 2: Textäventyr / Dungeon Crawler

## Koncept
Ett rollspel där spelaren navigerar i en värld av sammankopplade rum genom textkommandon som "gå norr" och "ta nyckel".

*Detta är ett klassiskt textbaserat äventyrsspel där spelaren utforskar en värld, samlar föremål och löser enkla pussel för att nå målet.*

## Spelets gång

### 1. Spelstart
- Spelaren startar i ett startrum med en beskrivning
- Spelaren kan se vilka riktningar som går att gå åt
- Spelaren kan se eventuella föremål i rummet

### 2. Navigation och utforskning
- Spelaren skriver kommandon som "gå norr", "ta nyckel", "titta"
- Varje rum har en unik beskrivning och eventuella föremål
- Spelaren samlar föremål i sitt inventory

### 3. Vinstvillkor
- Spelaren ska hitta ett specifikt föremål eller nå ett specifikt rum för att vinna
- Exempel: "Hitta den magiska kristallen och ta dig tillbaka till startpunkten"

## Förslag på klassstruktur

```csharp
// Hanterar huvudloopen och tolkar spelarens kommandon
public class Game
{
    private Player player;
    private bool gameOver = false;
    private Dictionary<string, Room> allRooms; // Alla rum i spelet

    // Metoder: Start(), ProcessCommand(string command), CreateWorld()
}

// Representerar spelaren
public class Player
{
    public Room CurrentRoom { get; set; }
    public List<Item> Inventory { get; set; }

    // Metoder: MoveToRoom(Room room), TakeItem(Item item), HasItem(string itemName)
}

// Representerar en plats i världen
public class Room
{
    public string Name { get; set; }        // "Mörk skog", "Gammal slott"
    public string Description { get; set; } // Längre beskrivning
    public List<Item> ItemsInRoom { get; set; }
    public Dictionary<string, Room> Exits { get; set; } // "norr" -> Room objekt

    // Metoder: GetDescription(), RemoveItem(Item item), AddItem(Item item)
}

// Representerar ett föremål
public class Item
{
    public string Name { get; set; }        // "nyckel", "fackla"
    public string Description { get; set; } // Vad spelaren ser när den undersöks
}
```

## Tekniska ledtrådar

### Kommandotolkning
```csharp
// Tips: Dela upp spelarens input i delar
// Exempel: "ta nyckel" blir ["ta", "nyckel"]
// Använd string.Split(' ') och kolla första ordet för att veta vad spelaren vill göra
// Andra ordet (om det finns) är ofta objektet spelaren vill interagera med
```

### Skapa världen
```csharp
// Tips: Skapa alla rum först, sedan koppla ihop dem
Room startRoom = new Room();
Room forest = new Room();
Room castle = new Room();

// Sedan sätt exits (kopplingar mellan rum)
startRoom.Exits["norr"] = forest;
forest.Exits["syd"] = startRoom;
forest.Exits["öster"] = castle;
// osv...
```

### Grundläggande kommandon som behöver stödjas
- **gå [riktning]** - "gå norr", "gå syd", "gå öster", "gå väster"
- **titta** - Visa rummets beskrivning igen
- **ta [föremål]** - Ta ett föremål från rummet
- **inventory** - Visa spelarens föremål
- **hjälp** - Visa tillgängliga kommandon
- **avsluta** - Avsluta spelet

### Exempel på spelloop
```csharp
while (!gameOver)
{
    Console.WriteLine(player.CurrentRoom.GetDescription());
    Console.Write("> ");
    string input = Console.ReadLine().ToLower();

    ProcessCommand(input);
}
```

## Grundkrav för Godkänt

### Obligatoriska funktioner
1. **Minst 5 rum** som är sammankopplade
2. **Navigation:** Spelaren kan röra sig mellan rum med "gå [riktning]"
3. **Föremålshantering:**
   - Spelaren kan ta föremål med "ta [föremål]"
   - Visa inventory med "inventory"
   - Föremål försvinner från rummet när de tas
4. **Rumsbeskrivningar:** Varje rum har en unik beskrivning
5. **Felhantering:** Meddelanden när spelaren försöker gå åt ogiltiga riktningar eller ta föremål som inte finns
6. **Vinstvillkor:** Ett tydligt sätt att vinna spelet

### Exempel på enkelt spel-scenario
```
Rum 1: Startpunkt - "Du står vid ingången till en gammal ruin"
Rum 2: Skog - "En mörk skog omger dig. Du hör konstiga ljud"
Rum 3: Sjö - "En kristallklar sjö. Något glimmar i vattnet"
Rum 4: Grotta - "En stor grotta. Det ekar av dina fotsteg"
Rum 5: Skattkammare - "En skattkammare! Här ligger den magiska kristallen"

Föremål: fackla (rum 2), nyckel (rum 3), skattkista (rum 4)
Mål: Ta kristallen från skattkammaren
```

### Kommandoexempel för spelaren
```
> titta
Du står vid ingången till en gammal ruin. Det går att gå norr.

> gå norr
Du kommer till en mörk skog. En gammal fackla ligger på marken.
Det går att gå syd eller öster.

> ta fackla
Du tar facklan.

> inventory
Du har: fackla

> gå öster
Du kommer till en kristallklar sjö...
```

## Krav för Väl Godkänt

Välj **minst en** av följande utbyggnader:

### 1. Större värld (minst 10 rum)
Skapa en mer komplex värld med fler rum och alternativa vägar. Tänk på att rita en karta på papper först så du inte tappar koll.

### 2. Låsta dörrar och nycklar
```csharp
// Tips: Lägg till en IsLocked property på Room-klassen
// Kontrollera om spelaren har rätt nyckel innan rörelse tillåts
public class Room
{
    public bool IsLocked { get; set; }
    public string RequiredKey { get; set; } // Vilken nyckel som behövs
}
```

### 3. NPCs (Non-Player Characters)
```csharp
public class NPC
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<string> Dialogue { get; set; } // Vad de säger
}

// Lägg till i Room-klassen:
public List<NPC> NPCsInRoom { get; set; }
```

Lägg till kommando "prata med [namn]" för att interagera.

## Bedömningsfokus

### Teknisk implementation (40%)
- Fungerar navigation mellan rum?
- Korrekt användning av Dictionary för exits
- Lämplig användning av listor för inventory och föremål

### Speldesign (30%)
- Är spelet logiskt och går att slutföra?
- Intressant värld med varierande rumsbeskrivningar
- Tydliga instruktioner för spelaren

### Kodkvalitet (30%)
- Välstrukturerade klasser med tydligt ansvar
- Bra hantering av användarinput
- Kommentarer och läsbar kod

## Tips för framgång

1. **Rita en karta:** Skissa världen på papper innan du börjar koda
2. **Börja litet:** Få 3 rum att fungera innan du lägger till fler
3. **Testa kommandona:** Prova olika input och se att felhantering fungerar
4. **Skriv intressanta beskrivningar:** Gör världen levande med bra texter
5. **Planera vinstvillkoret:** Bestäm tidigt hur spelaren ska vinna

## Vanliga fallgropar att undvika

- Glöm inte koppla rum åt båda hållen (om man kan gå norr från rum A till rum B, ska man kunna gå syd från rum B till rum A)
- Kontrollera alltid att föremål finns innan du försöker ta det
- Hantera både versaler och gemener i användarinput
- Se till att spelaren inte kan "vinna" spelet innan de samlat nödvändiga föremål

---

*Lycka till med ditt textäventyr! Kom ihåg att fokusera på att få grundfunktionaliteten att fungera innan du går vidare till VG-funktionerna.*

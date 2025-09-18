# Alternativ 1: Havsforskarna

## Koncept

Ett vetenskapligt äventyr på djupt vatten där du tävlar mot en datorstyrd motståndare om att bli först med att kartlägga dolda marina formationer på ett 10x10-rutnät.

_Detta är en fredlig version av "Sänka Skepp" där man istället ska utforska och upptäcka._

## Spelets gång

### 1. Spelstart

- Båda spelarna (du och datorn) placerar ut 5 marina formationer på varsitt 10x10-rutnät
- Formationerna har olika storlekar: 1 formation på 5 rutor, 2 på 3 rutor, 2 på 2 rutor
- Spelaren placerar manuellt, datorn placerar slumpmässigt

### 2. Utforskning

- Spelarna turas om att skicka "sonder" till motståndarens område
- En sond avslöjar om det finns en formation på den rutan eller inte
- Målet: Kartlägga alla motståndarens formationer först

### 3. Specialutrustning

Varje spelare har tillgång till specialutrustning som kan användas 1-2 gånger per spel:

- **Sonarsvep:** Avslöjar en hel rad eller kolumn
- **Multi-sond:** Undersöker ett 2x2-område
- **Data-analys:** Ger ledtrådar om en redan funnen formation

## Förslag på klassstruktur

```csharp
// Ansvarar för spellogiken, turer och vinstvillkor
public class Game
{
    private OceanGrid playerGrid;
    private OceanGrid aiGrid;
    private Player currentPlayer;
    private bool gameOver;

    // Metoder: StartGame(), PlayerTurn(), AiTurn(), CheckWinCondition()
}

// Representerar ett spelbräde (10x10)
public class OceanGrid
{
    private char[,] grid = new char[10, 10];
    private char[,] exploredGrid = new char[10, 10]; // Vad motståndaren har sett
    private List<Formation> formations;

    // Metoder: PlaceFormation(), ReceiveSonde(int row, int col),
    //          DisplayOwnGrid(), DisplayExploredGrid(), IsValidPosition()
}

// Representerar en marin formation
public class Formation
{
    public string Name { get; set; }        // "Korallrev", "Undervattensbergskedja"
    public int Size { get; set; }           // 2, 3 eller 5 rutor
    public int HitsReceived { get; set; }   // Antal träffar
    public List<Position> Positions { get; set; } // Vilka koordinater

    // Metoder: IsFullyMapped(), AddHit()
}

// Hjälpklass för koordinater
public class Position
{
    public int Row { get; set; }
    public int Col { get; set; }
}
```

## Tekniska ledtrådar

### Koordinatsystem

```csharp
// Tips: Låt spelaren skriva koordinater som "A5" eller "C7"
// Du behöver omvandla bokstav till rad-nummer och siffra till kolumn-nummer
// A=0, B=1, C=2 osv... och 1=0, 2=1, 3=2 osv...
// Använd input[0] för att få första tecknet (bokstaven)
// Använd input.Substring(1) för att få resten (siffran)
```

### Rutnätsvisning

```csharp
// Tips: Visa kolumnrubriker (1-10) och radrubriker (A-J)
// Använd char[,] grid för att lagra symboler
// Loopa igenom och skriv ut varje position
```

### Symboler att använda

- `~` Vatten (outforskat)
- `F` Formation (endast på egen spelplan)
- `X` Träff (formation hittad)
- `O` Miss (tomt vatten)
- `?` Okänt (på motståndarens karta)

### Färgkodning (VG-nivå)

För extra visuell tydlighet kan du använda `Console.ForegroundColor` för att färgkoda olika symboler.

## Grundkrav för Godkänt

### Obligatoriska funktioner

1. **Spelplan 10x10** med korrekt koordinatsystem (A1-J10)
2. **Formation-placering:**
   - Spelaren placerar manuellt genom att ange startkoordinat och riktning
   - Validering att formationer inte överlappar eller går utanför spelplan
3. **Sond-funktionalitet:**
   - Spelaren anger koordinat (t.ex. "C7")
   - Systemet svarar "träff" eller "miss"
   - Träffar markeras tydligt på kartan
4. **Två spelkartor:**
   - Din egen spelplan (visar dina formationer)
   - Motståndarens område (visar endast dina sondresultat)
5. **AI-motståndare (datorspelare):**
   - Placerar sina formationer slumpmässigt
   - Skickar sonder till slumpmässiga, ej testade koordinater
   - _OBS: Med "AI" menar vi här en datorspelare med programmerad logik, INTE generativ AI som ChatGPT/Claude_
6. **Vinstvillkor:** Spelet avslutas när alla formationer på ena sidan kartlagts

### Obligatorisk specialutrustning (välj minst en)

#### Sonarsvep

Avslöjar en hel rad eller kolumn som spelaren väljer. Implementera logik för att välja riktning ('R' för rad, 'C' för kolumn) och vilken rad/kolumn som ska undersökas.

#### Multi-sond

Undersöker ett 2x2-område med given startposition. Tänk på att kontrollera att området inte går utanför spelplanen.

#### Data-analys

Ger information om en redan träffad formation, t.ex. hur många rutor som återstår att hitta. Kräver att du kan hitta vilken formation som finns på en specifik position.

## Förslag på programflöde

```csharp
static void Main(string[] args)
{
    Game game = new Game();

    // 1. Välkomstmeddelande
    Console.WriteLine("=== HAVSFORSKARNA ===");
    Console.WriteLine("Kartlägg alla marina formationer först för att vinna!");

    // 2. Placera formationer
    game.SetupPlayerFormations();
    game.SetupAIFormations();

    // 3. Spelloop
    while (!game.IsGameOver())
    {
        game.ShowCurrentState();

        if (game.IsPlayerTurn())
            game.PlayerTurn();
        else
            game.AITurn();

        game.SwitchTurn();
    }

    // 4. Visa vinnare
    game.ShowGameResult();
}
```

## Krav för Väl Godkänt

Välj **minst en** av följande utbyggnader:

### 1. Smart AI (datorspelare)

_OBS: Detta är programmerad spellogik, inte generativ AI som ChatGPT/Claude_

Implementera en datorspelare som:

- Kommer ihåg var den har träffat formationer
- Söker systematiskt i närområdet efter träffar
- Använder olika strategier beroende på vad den hittat

### 2. Spara/Ladda spel

Implementera funktionalitet för att spara spelstatus till fil och ladda ett pågående spel. Tänk på vad som behöver sparas: spelarnas rutnät, aktuell tur, osv.

### 3. AI med specialutrustning

- Låt datorn använda specialutrustning slumpmässigt eller strategiskt
- Balansera så att spelet förblir utmanande för spelaren

## Bedömningsfokus

### Teknisk implementation (40%)

- Fungerar grundfunktionaliteten?
- Korrekt användning av 2D-arrayer och listor
- Lämplig användning av klasser och metoder

### Användarvänlighet (30%)

- Tydlig presentation av spelkartor
- Intuitivt interface för spelaren
- Bra feedback vid fel input

### Kodkvalitet (30%)

- Välstrukturerade klasser med tydligt ansvar
- Bra namngivning på variabler och metoder
- Kommentarer vid komplexa delar

## Tips för framgång

1. **Börja enkelt:** Få grundspelet att fungera innan du lägger till specialutrustning
2. **Testa ofta:** Kör programmet efter varje större förändring
3. **Validera input:** Kontrollera att användaren matar in giltiga koordinater
4. **Planera klasserna:** Tänk igenom vilket ansvar varje klass ska ha
5. **Använd debuggern:** Sätt breakpoints för att förstå programflödet

---

_Lycka till med ditt havsforskningsprojekt! Kom ihåg att fokusera på att få grundfunktionaliteten att fungera väl innan du går vidare till VG-funktionerna._

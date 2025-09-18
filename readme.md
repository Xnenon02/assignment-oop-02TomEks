# Inlämningsuppgift: Spelprojekt

**Inlämning:** 26 september 2025

## Mål

Målet med denna uppgift är att du ska tillämpa dina kunskaper om listor, loopar, if-satser och klasser för att bygga ett fungerande program. Du ska visa att du kan strukturera din kod på ett objektorienterat sätt och lösa ett större problem steg för steg.

## Uppgift

Välj ett av de tre projekten och implementera det. De tre alternativen är:

- **Havsforskarna** (se `sea_stuff.md`): Ett strategispel där du ska hitta dolda formationer på havsbotten.
- **Textäventyr / Dungeon Crawler** (se `dungeon_crawler.md`): Ett interaktivt textbaserat äventyrsspel.
- **Lagerhanteringssystem** (se `storage.md`): En simulation av ett lagersystem som hanterar produkter och ordrar via filer.

Läs den specifika projektbeskrivningen för det alternativ du väljer för detaljerade krav.

## Krav för inlämning (gäller alla projekt)

Oavsett vilket projekt du väljer ska din inlämning, utöver programmets kod, innehålla följande delar:

### 1) Git-repository

- Projektet ska finnas i ett Git-repository på [Campus Mölndals GitHub](https://github.com/orgs/Campus-Molndal-CLO25/repositories).
- Namnge ditt repository enligt mönstret: `assignment-oop-GAFEANVÄNDARNAMN` (t.ex. `assignment-oop-kalle-andersson`).
- Lämna in länken till ditt repository.
- Ladda även upp en zip-fil med hela projektet till klassrummet.

### 2) README.md

- Skapa en `README.md` i projektets rot. **Använd mallen `README-mall.md` som grund.**
- Din README måste innehålla:
  - Kort beskrivning av programmet och vilket alternativ du valt
  - **Minst ett screenshot** av ditt program i körning
  - Tydliga instruktioner för hur man startar och använder programmet
  - Länk till ditt GitHub-repo
- **Ta bort alla placeholders** (t.ex. `[Projektnamn]`) och ersätt med din egen text.

### 3) reflection.md

- Skapa en `reflection.md` i projektet och **använd `reflection-mall.md` som grund.**
- Besvara frågorna i mallen:
  - **För Godkänt:** Besvara G-frågorna (Planering, Problem, Stolthet)
  - **För Väl Godkänt:** Besvara både G- och VG-frågorna utförligt
- **Ta bort alla placeholders** (`[Ditt svar här...]`) och exempel i kursiv stil när du skriver dina svar.

## Tips

- Börja tidigt och gör en minimal fungerande version (MVP) först.
- Dela upp projektet i tydliga klasser och ansvar.
- Skriv små tester eller kör manuella scenarier för att validera logik under arbetets gång.
- Ta screenshots under utvecklingen så du har material till README.

## Hjälp och samarbete

### Tillåtet stöd

Det är **helt okej** att:

- Fråga läraren om hjälp och vägledning
- Diskutera idéer och lösningsstrategier med kurskamrater
- Använda AI (ChatGPT, Claude, etc.) för att:
  - Förklara koncept du inte förstår
  - Få förslag på hur du kan lösa specifika delproblem
  - Hjälpa med felsökning av din egen kod
  - Få kodgranskningar och förbättringsförslag

### Dokumentationskrav

Om du använder kod som kommer från andra källor än dig själv måste du **tydligt dokumentera** detta:

```csharp
// Denna metod för koordinatkonvertering är inspirerad av hjälp från ChatGPT
// för att lösa problemet med att omvandla "A5" till array-index
public static int[] ParseCoordinates(string input)
{
    // Min egen implementation baserat på förslaget...
}
```

Eller i din `reflection.md`:

> "Jag fick hjälp av AI för att förstå hur Dictionary fungerar och för att lösa ett specifikt problem med felhantering i min CSV-läsning."
> Kalle hjälpte mig att förstå hur jag kunde strukturera mina klasser bättre för att separera ansvar.

### Vad som räknas som plagiat

**Inte acceptabelt:**

- Låta AI eller någon annan skriva hela klasser eller stora delar av din kod
- Kopiera kod från guider, Stack Overflow eller GitHub utan att förstå vad den gör
- Låta kurskamrater göra ditt arbete åt dig
- Använda färdiga lösningar på hela uppgiften

**Riktlinjen:** Du ska kunna förklara och förstå varje rad kod du lämnar in. Om du inte kan förklara hur din kod fungerar under presentation/diskussion, räknas det som plagiat.

### Osäker på gränsen?

Fråga läraren! Det är alltid bättre att fråga i förväg än att riskera misstankar om fusk.

---

_Lycka till med ditt projekt! Kom ihåg att fokusera på att få grundfunktionaliteten att fungera innan du går vidare till VG-funktionerna._

# Reflektion över [Projektnamn]

**VIKTIGT:** Ersätt `[Projektnamn]` i rubriken med ditt faktiska projektnamn. Ta bort alla placeholders som `[Ditt svar här...]`
och exempel i kursiv stil när du skriver dina egna svar.

_Skriv dina svar under varje rubrik._

## Planering

Hur planerade du ditt arbete från start till mål?

[Ditt svar här...]

## Problem

Vad var den svåraste delen av uppgiften och varför? Hur löste du de problem du stötte på?

[Ditt svar här...]

## Stolthet

Vad är du mest stolt över med ditt projekt?

[Ditt svar här...]

---

## Reflektion för Väl Godkänt (VG)

_Besvara dessa frågor utförligt för att visa på VG-kompetens._
_Tips: förklara för en nybörjare i programmering._

### Datastrukturer

Vilka datastrukturer (t.ex. listor, arrays, dictionaries) använde du i ditt program? Varför valde du just dessa?
Finns det andra datastrukturer som hade kunnat fungera och vilka för- eller nackdelar hade de haft i just ditt projekt?

_Exempel på vad du kan diskutera:_

- _Lista alla datastrukturer du använt (List<T>, Array, Dictionary, etc.)_
- _Förklara varför varje datastruktur var lämplig för sitt syfte_
- _Diskutera alternativ: Hade du kunnat använda något annat? Vad hade varit för- och nackdelar?_

**Exempel:**

```
Jag använde List<Formation> för att lagra marina formationer eftersom:
- Listor har dynamisk storlek (jag visste inte exakt hur många formationer som skulle behövas)
- Lätt att iterera igenom med foreach-loopar
- Inbyggda metoder som Add() och Remove() förenklade hanteringen

Alternativ hade kunnat vara:
- Array: Snabbare åtkomst, men fast storlek
- Dictionary: Snabbare uppslagning om jag hade namngivna formationer, men mer komplext för denna användning
```

[Ditt svar här...]

### Clean Code och Struktur

Hur har du arbetat för att göra din kod "ren" och välstrukturerad? Reflektera över hur du har organiserat dina klasser och metoder för att göra koden läsbar, återanvändbar och lätt att underhålla (modularitet). Ge konkreta exempel från din kod.

_Diskutera din kodkvalitet:_

- _Hur namngav du klasser, metoder och variabler?_
- _Hur följde du grundregeln att klasser och metoder ska göra vad de heter och inget annat?_
- _Vilka metoder bröt du ut för att undvika upprepning?_
- _Hur kommenterade du din kod?_

**Konkreta exempel:**

```
Exempel på tydligt ansvar: Min Formation-klass ansvarar endast för att hålla reda på
en formations tillstånd (namn, storlek, träffar), medan OceanGrid-klassen ansvarar för
spelplanens hantering (visa rutnät, ta emot skott). Detta följer grundregeln att varje
klass gör vad namnet säger.

Exempel på undvikande av upprepning: Jag skapade metoden ValidateCoordinates() som används
både när spelaren placerar formationer och när sonder skickas, istället för att upprepa
samma validering på flera ställen.

Exempel på tydliga namn: Istället för att använda 'x' och 'y' använde jag 'rowIndex'
och 'columnIndex' för att göra det tydligt vad variablerna representerar.
```

[Ditt svar här...]

### Framtida utveckling

Kan du fortsätta att utveckla ditt projekt utan att behöva göra om allt från grunden? Hur har du designat din kod för att den ska vara möjlig att bygga vidare på i framtiden?

_Reflektion över koddesign:_

- _Vilka delar av din kod skulle vara lätta att ändra eller utöka?_
- _Vad skulle vara svårt att ändra och varför?_
- _Har du tänkt på att separera olika ansvarsområden?_

[Ditt svar här...]

---

_Denna reflektion är skapad som del av inlämningsuppgiften i kursen "Grundläggande objektorienterad programmering i C#" vid Yrkeshögskolan Campus Mölndal._

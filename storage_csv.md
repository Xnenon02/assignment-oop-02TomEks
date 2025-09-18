# CSV-exempel för Lagerhanteringssystem

## lager.csv
*Denna fil innehåller alla produkter som finns i lagret.*

```csv
Name,Category,Price,Quantity
Laptop Dell XPS,Electronics,15999.00,12
Trådlös mus,Electronics,299.00,45
Mekaniskt tangentbord,Electronics,899.00,23
iPhone 15,Electronics,12999.00,8
Samsung Galaxy S24,Electronics,11499.00,15
Office-stol,Furniture,2499.00,6
Skrivbord,Furniture,3999.00,4
Bokhylla,Furniture,1599.00,9
Kaffemugg,Kitchen,79.00,50
Termosflaska,Kitchen,249.00,30
Tallrik-set,Kitchen,399.00,18
Penna,Office,12.00,200
Anteckningsblock,Office,45.00,85
Häftapparat,Office,159.00,12
```

## ordrar.csv
*Denna fil innehåller alla kundordrar som ska bearbetas.*

```csv
CustomerId,CustomerName,ProductName,QuantityOrdered
CUST001,Anna Andersson,Laptop Dell XPS,2
CUST002,Björn Larsson,Trådlös mus,3
CUST003,Cecilia Nilsson,iPhone 15,1
CUST004,David Eriksson,Office-stol,2
CUST005,Emma Johansson,Penna,50
CUST006,Fredrik Petersson,Samsung Galaxy S24,1
CUST007,Gunilla Svensson,Kaffemugg,5
CUST008,Henrik Gustafsson,Laptop Dell XPS,15
CUST009,Ingrid Lindberg,Skrivbord,1
CUST010,Johan Olsson,Mekaniskt tangentbord,2
CUST011,Karin Persson,Termosflaska,4
CUST012,Lars Mattsson,iPhone 15,10
CUST013,Maria Karlsson,Bokhylla,2
CUST014,Nils Jansson,Häftapparat,1
CUST015,Olivia Bengtsson,Tallrik-set,3
```

## Förväntad output efter bearbetning

När programmet körs ska det skriva ut något liknande:

```
Läser produkter från lager.csv...
12 produkter inlästa.

Bearbetar ordrar från ordrar.csv...

✓ Order från Anna Andersson skickad: 2x Laptop Dell XPS
✓ Order från Björn Larsson skickad: 3x Trådlös mus
✓ Order från Cecilia Nilsson skickad: 1x iPhone 15
✓ Order från David Eriksson skickad: 2x Office-stol
✓ Order från Emma Johansson skickad: 50x Penna
✓ Order från Fredrik Petersson skickad: 1x Samsung Galaxy S24
✓ Order från Gunilla Svensson skickad: 5x Kaffemugg
✗ Order från Henrik Gustafsson kunde inte skickas: Otillräckligt lager för Laptop Dell XPS (begärt: 15, finns: 10)
✓ Order från Ingrid Lindberg skickad: 1x Skrivbord
✓ Order från Johan Olsson skickad: 2x Mekaniskt tangentbord
✓ Order från Karin Persson skickad: 4x Termosflaska
✗ Order från Lars Mattsson kunde inte skickas: Otillräckligt lager för iPhone 15 (begärt: 10, finns: 7)
✓ Order från Maria Karlsson skickad: 2x Bokhylla
✓ Order från Nils Jansson skickad: 1x Häftapparat
✓ Order från Olivia Bengtsson skickad: 3x Tallrik-set

Orderbearbetning slutförd!
- 13 ordrar skickade
- 2 ordrar kunde inte skickas

Sparar uppdaterat lager till lager_uppdaterat.csv...
Klart!
```

## lager_uppdaterat.csv
*Denna fil skapas av programmet efter att alla ordrar bearbetats.*

```csv
Name,Category,Price,Quantity
Laptop Dell XPS,Electronics,15999.00,10
Trådlös mus,Electronics,299.00,42
Mekaniskt tangentbord,Electronics,899.00,21
iPhone 15,Electronics,12999.00,7
Samsung Galaxy S24,Electronics,11499.00,14
Office-stol,Furniture,2499.00,4
Skrivbord,Furniture,3999.00,3
Bokhylla,Furniture,1599.00,7
Kaffemugg,Kitchen,79.00,45
Termosflaska,Kitchen,249.00,26
Tallrik-set,Kitchen,399.00,15
Penna,Office,12.00,150
Anteckningsblock,Office,45.00,85
Häftapparat,Office,159.00,11
```

## Tekniska tips för implementation

### Läsa CSV-fil:
```csharp
string[] lines = File.ReadAllLines("lager.csv");
for (int i = 1; i < lines.Length; i++) // Hoppa över första raden (headers)
{
    string[] parts = lines[i].Split(',');
    // parts[0] = Name, parts[1] = Category, osv...
}
```

### Skriva CSV-fil:
```csharp
List<string> csvLines = new List<string>();
csvLines.Add("Name,Category,Price,Quantity"); // Header

foreach (Product product in products)
{
    string line = $"{product.Name},{product.Category},{product.Price},{product.Quantity}";
    csvLines.Add(line);
}

File.WriteAllLines("lager_uppdaterat.csv", csvLines);
```

### Hitta produkt i lista:
```csharp
Product foundProduct = products.FirstOrDefault(p => p.Name == orderProductName);
if (foundProduct != null)
{
    // Produkten hittades
}
```

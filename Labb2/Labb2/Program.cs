using Labb2;

bool run = true;
int menuChoice = 0;
List<KitchenAppliance> Appliance = new List<KitchenAppliance>(); // Skapar lista med Köksapparater

Appliance.Add(new KitchenAppliance("Våffeljärn", "Electrolux", 'j')); // Skapar Köksapparat med egenskaper och lägger till i listan
Appliance.Add(new KitchenAppliance("Blender", "OBH Nordica", 'j'));
Appliance.Add(new KitchenAppliance("Ismaskin", "Logik", 'n'));

while (run)
{
    Menu();
    Console.Write("Val> ");
    try
    {
        menuChoice = Convert.ToInt32(Console.ReadLine());
    }
    catch
    {
        Console.WriteLine("Försök igen!");
    }
    switch(menuChoice)
    {
        case 1:
            UseKitchenAppliance();
            break;
        case 2:
            AddKitchenAppliance();
            break;
        case 3:
            ListKitchenAppliances();
            break;
        case 4:
            RemoveKitchenAppliance();
            break;
        case 5:
            run = false;
            Console.WriteLine("Avslutar...");
            break;
        default:
            break;
    }
}
void Menu()
{
    Console.WriteLine($"======KÖKET======\n" +
        $"1. Använd köksapparat\n" +
        $"2. Lägg till köksapparat\n" +
        $"3. Lista köksapparater\n" +
        $"4. Ta bort köksapparat\n" +
        $"5. Avsluta programmet");
} 

void UseKitchenAppliance() // Använder köksapparat
{

    top:
    ListKitchenAppliances();
    if(Appliance.Count > 0)
    {
    try
    {
    Console.Write("Välj köksapparat> ");
    int input = (Convert.ToInt32(Console.ReadLine())-1);
    Appliance[input].Use();
    }
    catch
    {
        Console.WriteLine("Försök igen.");
        goto top;
    }

    }
} 

void AddKitchenAppliance() // Lägger till Köksapparat med Typ, Märke och om den är Fungerande
{
    Console.Write("Välj typ> ");
    string type = Console.ReadLine();
    Console.Write("Välj märke> ");
    string brand = Console.ReadLine();
    repeat:
    Console.Write("Är den fungerande? [j/n]> ");
    try
    {
        char functioning = Convert.ToChar(Console.ReadLine());
        if(functioning == 'j' || functioning == 'n')
        {
            Appliance.Add(new KitchenAppliance(type, brand, functioning)); // Skapar en ny Köksapparat(objekt)
            Console.WriteLine("Köksapparaten har lagt till.");
        }
        else
        {
            Console.WriteLine("Försök igen!");
            goto repeat; // Användaren får fortsätta att mata in tills han skriver antingen 'j' eller 'n'
        }
    }
    catch 
    {
        Console.WriteLine("Försök igen!");
        goto repeat;
    }
}

void ListKitchenAppliances() // Skriver ut alla Köksapparater med Märke, Typ och om den är Fungerande
{
    if(Appliance.Count > 0)
    {
        for(int i=0; i < Appliance.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{Appliance[i].Brand} {Appliance[i].Type}, Fungerar: {BoolToChar(Appliance[i].IsFunctioning)}");
        }
    }
    else // Om det inte finns några apparater
    {
        Console.WriteLine("Du har inga apparater.");
    }
}

void RemoveKitchenAppliance() // Tar bort en Köksapparat
{
    ListKitchenAppliances();
    if(Appliance.Count > 0)
    {
        Console.WriteLine("Välj apparat att ta bort> ");
        int input = 0;
        try
        {
            input = Convert.ToInt32(Console.ReadLine());
            Appliance.Remove(Appliance[input-1]);
            Console.WriteLine("Apparaten har tagits bort.");
        }
        catch (Exception exception)
        {
            Console.WriteLine("Fel. Tog inte bort någon apparat.");
            Console.WriteLine(exception.Message);
        }
    }
}

string BoolToChar(bool isFunctioning) // Returnerar true till Ja och false till Nej
{
    if(isFunctioning == true)
    {
        return "Ja";
    }
    else
    {
        return "Nej";
    }
}

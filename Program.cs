List<Plant> plants = new List<Plant>()
{
    new Plant()
    {
        Species = "Indian Blanket",
        LightNeeds = 1,
        AskingPrice = 40.00M,
        City = "Chicago",
        Zip = 34785,
        Sold = false,
        AvailableUntil = new DateTime(2024, 3, 2)
    },
    new Plant()
    {
        Species = "Flax",
        LightNeeds = 4,
        AskingPrice = 32.99M,
        City = "Tampa",
        Zip = 73685,
        Sold = false,
        AvailableUntil = new DateTime(2023, 10, 6)
    },
    new Plant()
    {
        Species = "Bamboo",
        LightNeeds = 0,
        AskingPrice = 73.00M,
        City = "Bejing",
        Zip = 65487,
        Sold = false,
        AvailableUntil = new DateTime(2024, 12, 24)
    },
    new Plant()
    {
        Species = "Shrub",
        LightNeeds = 5,
        AskingPrice = 10.00M,
        City = "Murfreesboro",
        Zip = 34876,
        Sold = true,
        AvailableUntil = new DateTime(2024, 11, 15)
    },
    new Plant()
    {
        Species = "Hin",
        LightNeeds = 4,
        AskingPrice = 85.00M,
        City = "Charlotte",
        Zip = 96745,
        Sold = false,
        AvailableUntil = new DateTime(2024, 6, 10)
    }
};


string greeting = @"Welcome to ExtraVert,
                where our mission is to find every plant a home!";

Console.WriteLine(greeting);

MainMenu();

void MainMenu()
{
    string choice = null;
    while (choice == null)
    {
        Console.WriteLine(@"Choose an option:
                            0. Exit
                            1. Display All Plants
                            2. Post A Plant To Be Adopted
                            3. Adopt A Plant
                            4. Delist A Plant
                            5. Plant Of The Day
                            6. Search For Plants By Light Needs
                            7. View Plant Stats");
                        

        choice = Console.ReadLine();

        if (choice == "0")
        {
            Console.WriteLine("Thank you for visiting Extravert! Goodbye!");
        }
        else if (choice == "1")
        {
            DisplayPlants();
        }
        else if (choice == "2")
        {
            NewPlant();
        }
        else if (choice == "3")
        {
            AdoptPlant();
        }
        else if (choice == "4")
        {
            DelistPlant();
        }
        else if (choice == "5")
        {
            PlantOfTheDay();
        }
        else if (choice == "6")
        {
            SearchLightNeeds();
        }
        else if (choice == "7")
        {
            PlantStats();
        }
    }
}

void DisplayPlants()
{
    ListPlants();
    PlantDetails();

}

void NewPlant()
{
    Plant newPlant = new Plant()
    {
        Species = "",
        LightNeeds = 0,
        AskingPrice = 0M,
        City = "",
        Zip = 0,
        Sold = false,
        AvailableUntil = new DateTime() 
    };

    string response = "";
    DateTime dateTime = new DateTime();
    decimal price = 0M;
    int number = 0;
    bool validNumber = false;

    Console.WriteLine("What is the species of the new plant?");
    while (response == "")
    {
        response = Console.ReadLine();
        newPlant.Species = response;
    }

    Console.WriteLine("On a scale of 1-5, what are the light needs of the new plant?");
    response = Console.ReadLine();
    try
    {
        validNumber = int.TryParse(response, out number);

        if (validNumber == true && number >= 1 && number <= 5)
        {
            newPlant.LightNeeds += number;
        }
        else
        {
            Console.WriteLine("Please enter a valid number.");
        }
    }
    catch
    {
        Console.WriteLine("Please enter a number between 1-5 only!");
    }

    Console.WriteLine("What is the asking price of the new plant?");
    response = Console.ReadLine();

    validNumber = decimal.TryParse(response, out price);

    if (validNumber == true)
    {
        newPlant.AskingPrice += price;
    }
    else
    {
        Console.WriteLine("Sorry, you entered an invalid price, please try again.");
    }

    Console.WriteLine("What is the city of the new plant?");
    response = Console.ReadLine();
    newPlant.City += response;

    Console.WriteLine("What is the zip code of the new plant?");
    response = Console.ReadLine();
    try
    {
        validNumber = int.TryParse(response, out number);

        if (validNumber == true && number.ToString().Length == 5)
        {
            newPlant.Zip += number;
        }
    }
    catch
    {
        Console.WriteLine("Please enter a valid zipcode!");
        NewPlant();
    }

    Console.WriteLine("Please enter the date available until in this format 'YYYY, MM, D'");
    response = Console.ReadLine();
    try
    {
        validNumber = DateTime.TryParse(response, out dateTime);
        if (validNumber == true)
        {
            newPlant.AvailableUntil = dateTime;
        }
    }
    catch
    {
        Console.WriteLine("You have entered an invalid date.");
        NewPlant();
    }


    plants.Add(newPlant);

    Console.WriteLine($@"Thank you for adding your new plant!
                You've added a {newPlant.Species}, from the city of {newPlant.City}, zip code {newPlant.Zip},
                which has a light needs rating of {newPlant.LightNeeds}. The asking price is ${newPlant.AskingPrice}.");

    MainMenu();
}

void AdoptPlant()
{
    Console.WriteLine("Please select which plant you would like to adopt.");

    ListAvailablePlants();

    Plant chosen = null;
    string response = "";
    while (chosen == null)
    {
        Console.WriteLine("Enter a product number:");
        try
        {
            int answer = int.Parse(Console.ReadLine().Trim());
            chosen = plants[answer - 1];
            Console.WriteLine(@$"You selected a {chosen.Species}, which costs ${chosen.AskingPrice}.
                             Are you sure you want to adopt this plant?
                                           1. Yes
                                           2. No");
            try
            {
                response = Console.ReadLine();

                if (response == "1")
                {
                    chosen.Sold = true;
                    Console.WriteLine($"Congratulations! You have successfully adopted a {chosen.Species}!");
                    MainMenu();
                }
                else if (response == "2")
                {
                    MainMenu();
                }
            }
            catch
            {
                Console.WriteLine("Please select only 1 or 2 for yes or no!");

            }
        }
        catch
        {
            Console.WriteLine("Please enter a valid number option.");
        }
    }
}

void DelistPlant()
{
    Console.WriteLine("Pleae select which plant you would like to delist.");

    ListPlants();

    Plant chosen = null;
    string response = "";
    while (chosen == null)
    {
        Console.WriteLine("Enter a product number:");
        try
        {
            int answer = int.Parse(Console.ReadLine().Trim());
            chosen = plants[answer - 1];
            Console.WriteLine(@$"Are you sure you want to delete {chosen.Species}?
                                    1. Yes
                                    2. No");
            try
            {
                response = Console.ReadLine();

                if (response == "1")
                {
                    plants.RemoveAt(answer - 1);
                    Console.WriteLine($"You have successfully delisted {chosen.Species}!");
                    MainMenu();
                }
                else if (response == "2")
                {
                    MainMenu();
                }
            }
            catch
            {
                Console.WriteLine("Please select only 1 or 2 for yes or no!");
            }
        }
        catch
        {
            Console.WriteLine("Please enter a valid number option.");
        }
    }
}

void ListPlants()
{
    Console.WriteLine("Plants: ");
    for (int i = 0; i < plants.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {PlantLine(plants[i])}");
    }
}

void ListAvailablePlants()
{

    int count = 0;
    Console.WriteLine("Plants: ");
    for (int i = 0; i < plants.Count; i++)
    {
        if (plants[i].Sold == false && DateTime.Now < plants[i].AvailableUntil)
        {
            count += 1;
            Console.WriteLine($"{count}. A {plants[i].Species} in {plants[i].City} {(plants[i].Sold ? $"was sold for {plants[i].AskingPrice}" : $"is available for {plants[i].AskingPrice} dollars")}");
        }
    }
}

void PlantDetails()
{
    Plant chosen = null;
    while (chosen == null)
    {
        Console.WriteLine("Please enter a product number:");
        try
        {
            int answer = int.Parse(Console.ReadLine().Trim());
            chosen = plants[answer - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please enter only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please enter an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Try again!");
        }
    }

    Console.WriteLine(@$"You chose:
               {PlantDetailsLine(chosen)}");

    MainMenu();
}

void PlantOfTheDay()
{
    Random random = new Random();
    List<Plant> availablePlants = plants.Where(s => s.Sold == false && DateTime.Now < s.AvailableUntil).ToList();
    int randomInteger = random.Next(0, (availablePlants.Count - 1));
    Plant dayPlant = availablePlants[randomInteger];

    Console.WriteLine($@"The plant of the day today is a {dayPlant.Species} from the city of {dayPlant.City}.
                    The light needs rating of the plant is {dayPlant.LightNeeds}, and the asking price is {dayPlant.AskingPrice} dollars.");

    MainMenu();
}

void SearchLightNeeds()
{
    int response = 0;
    List<Plant> availablePlants = plants.Where(s => s.Sold == false && DateTime.Now < s.AvailableUntil).ToList();
    Console.WriteLine("Please enter a max light needs rating on a scale of 1-5.");

    while (response == 0)
    {
        try
        {
            response = int.Parse(Console.ReadLine().Trim());
            if (response >= 1 && response <= 5)
            {
                List<Plant> userLightNeeds = availablePlants.Where(s => s.LightNeeds <= response).ToList();
                foreach (Plant plant in userLightNeeds)
                {
                    Console.WriteLine($"A {plant.Species} from {plant.City}) that is available for {plant.AskingPrice} dollars.");
                }
                MainMenu();

            }
            else
            {
                Console.WriteLine("Please enter only a number between 1-5.");
                SearchLightNeeds();
            }
        }
        catch
        {
            Console.WriteLine("Please enter only a number between 1-5.");
            SearchLightNeeds();
        }
    }

}

void PlantStats()
{
    string lowPricePlantName = "";
    decimal minPrice = plants.Min(p => p.AskingPrice);
    Plant priceMatch = plants.FirstOrDefault(s => s.AskingPrice == minPrice);
    lowPricePlantName = priceMatch.Species;

    int numberPlantsAvailable = 0;
    List<Plant> availablePlants = plants.Where(s => s.Sold == false && DateTime.Now < s.AvailableUntil).ToList();
    numberPlantsAvailable = availablePlants.Count;

    string highLightNeedPlantName = "";
    int maxLight = plants.Max(p => p.LightNeeds);
    Plant lightMatch = plants.FirstOrDefault(s => s.LightNeeds == maxLight);
    highLightNeedPlantName = lightMatch.Species;

    double averageLightNeed = plants.Average(s => s.LightNeeds);

    double percentPlantsAdopted = 0.0;
    double all = plants.Count;
    percentPlantsAdopted = (numberPlantsAvailable / all) * 100;

    Console.WriteLine($@"Here are the current plant stats:
                   - Lowest Price Plant: {lowPricePlantName}
                   - Number of Plants Available: {numberPlantsAvailable}
                   - Plant With Highest Light Needs: {highLightNeedPlantName}
                   - Average Light Needs: {averageLightNeed}
                   - Percentage of Plants Adopted: {percentPlantsAdopted}%");
    MainMenu();
}

string PlantLine(Plant plant)
{
    string plantString = $"A {plant.Species} in {plant.City} {(plant.Sold ? $"was sold for {plant.AskingPrice}" : $"is available for {plant.AskingPrice} dollars")}";

    return plantString;
}

string PlantDetailsLine(Plant plant)
{
    string plantString = $@"{plant.Species}, from the city of {plant.City}, zip code {plant.Zip}, and has a light needs rating of {plant.LightNeeds}.
    The asking price is {plant.AskingPrice}, and it {(plant.Sold ? "is no longer available" : "is currently available")}";

    return plantString;
}
//Screen Sound
string welcomeMessage = "Welcome to R Music";
//List<string> singerList = new List<string> {"Adele", "Jessie J", "Fei Yu Chin", "Hua Chen Yu", "Eric Shou"}; //to start with a clear list use "()". To start a list with elementes use "{"element1, "element2"}"
Dictionary<string,List<int>>singerRecorded = new Dictionary<string,List<int>>();
singerRecorded.Add("Fei Yu Chin", new List<int> { 10, 9, 9,10 });
singerRecorded.Add("Hua Chen Yu", new List<int> { 9, 9, 10, 10, 8 });
singerRecorded.Add("Adele", new List<int> { 9, 9, 7, 6, 8 });
singerRecorded.Add("Anita", new List<int> { 8, 9, 9, 7, 6 });
singerRecorded.Add("Indigo", new List<int> { 9, 9, 8, 7, 8 });

void ShowLogo()
{
    Console.WriteLine(@"
██████╗░  ███╗░░░███╗██╗░░░██╗░██████╗██╗░█████╗░
██╔══██╗  ████╗░████║██║░░░██║██╔════╝██║██╔══██╗
██████╔╝  ██╔████╔██║██║░░░██║╚█████╗░██║██║░░╚═╝
██╔══██╗  ██║╚██╔╝██║██║░░░██║░╚═══██╗██║██║░░██╗
██║░░██║  ██║░╚═╝░██║╚██████╔╝██████╔╝██║╚█████╔╝
╚═╝░░╚═╝  ╚═╝░░░░░╚═╝░╚═════╝░╚═════╝░╚═╝░╚════╝░");
    Console.WriteLine(welcomeMessage);
}



void ShowMenuOptions()
{
    ShowLogo();
    Console.WriteLine("\nType 1 to record a singer");
    Console.WriteLine("Type 2 to show all singers");
    Console.WriteLine("Type 3 to evaluate a singer");
    Console.WriteLine("Type 4 to show the singer's average rating");
    Console.WriteLine("Type 0 to exit");

    Console.Write("\nType your option: ");
    string typedOption = Console.ReadLine()!;
    int typedOptionNumber = int.Parse(typedOption);

    switch(typedOptionNumber)
    {
            case 1: RecordSinger();
            break;
            case 2: ShowSingersRecorded();
            break;
            case 3: EvaluateSinger(); //Console.WriteLine("You trype option " + typedOptionNumber);
            break;
            case 4: SingerAverage();//Console.WriteLine("You trype option " + typedOptionNumber);
            break;
            case 0: Console.WriteLine("Thank you for using Screen Sound! ");
            Thread.Sleep(3000);
            break;
            default: Console.WriteLine("Invalid Option");
            Thread.Sleep(3000);
            break;
    }
}
//develop option 1 to record a singer
void RecordSinger() //Option 1
{
    Console.Clear();
    ShowOptionTitle("Singer Record");
    Console.Write("Type the Singer name: ");
    string singerName = Console.ReadLine()!;
    singerRecorded.Add(singerName, new List<int>());
    Console.WriteLine($"The singer {singerName} was successfully recorded.");
    Thread.Sleep(2000);
    Console.Clear();
    ShowMenuOptions();
}

void ShowSingersRecorded() //Option 2
{
    Console.Clear();
    ShowOptionTitle("Showing all Singers recorded.");
    //for (int i = 0; i < singerList.Count; i++)
    //{
    //    Console.WriteLine($"Singer: {singerList[i]}");
    //}


    foreach(string singer in singerRecorded.Keys)
    {
        Console.WriteLine($"Singer: {singer}");
    }

    Console.WriteLine("\nType any key to go back to the main menu.");
    Console.ReadKey();
    Console.Clear();
    ShowMenuOptions();

}

void ShowOptionTitle(string optionTitle)
{
    int letterQuantity = optionTitle.Length;
    string asterisk = string.Empty.PadLeft(letterQuantity, '*');
    Console.WriteLine(asterisk);
    Console.WriteLine(optionTitle);
    Console.WriteLine(asterisk + "\n");
}

void EvaluateSinger () //Option 3
{
    // 1 - Type the singer you want to evaluate;
    // 2 - verify if singer is already recorded >> if yes, record the grade;
    // 3 - if singer not recorded yet, come back to main menu;

    Console.Clear();
    ShowOptionTitle("Evaluate a Singer.");
    Console.Write("Type the Singer's name you would like to evaluate: ");
    string singerName = Console.ReadLine()!;
    if (singerRecorded.ContainsKey(singerName))
    {
        Console.Write($"What grade does the singer {singerName} deserve: ");
        int grade = int.Parse(Console.ReadLine()!);
        singerRecorded[singerName].Add(grade);
        Console.WriteLine($"\nThe grade {grade} was successfully recorded to the singer {singerName}.");
        Thread.Sleep(3000);
        Console.Clear() ;
        ShowMenuOptions();
    } else 
    {
        Console.WriteLine($"\nThe Singer {singerName} was not found.");
        Console.WriteLine("Type any key to be back to the main menu.");
        Console.ReadKey();
        Console.Clear();
        ShowMenuOptions();
    }
}


void SingerAverage()
{
    Console.Clear();
    ShowOptionTitle("Average singer rating.");
    Console.Write("Type the Singer's name to see the average rating: ");
    string singerName = Console.ReadLine()!;
    if (singerRecorded.ContainsKey(singerName))
    {
        List<int> singerGrades = singerRecorded[singerName]; // or -- double singerAverageRating = singerRecorded[singerName].Average();
        Console.WriteLine($"\nThe average rating of the singer {singerName} is {singerGrades.Average()}."); //Console.WriteLine($"\nThe average rating of the singer {singerName} is {singerAverageRating}.");
        Console.WriteLine("Type any key to be back to the main menu.");
        Console.ReadKey();
        Console.Clear();
        ShowMenuOptions();
    }
    else
    {
        Console.WriteLine($"\nThe Singer {singerName} was not found.");
        Console.WriteLine("\nType any key to be back to the main menu.");
        Console.ReadKey();
        Console.Clear();
        ShowMenuOptions();
    }
}

ShowMenuOptions();
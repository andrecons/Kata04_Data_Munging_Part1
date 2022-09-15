using Kata04_Data_Munging_Part1.StartupConfigs;

//PART 1: print day with lower temperature spread (tSpread = tMax - tMin).

/*Importing the .dat file*/

DatHandler.Importer();

/*Printing the List*/
DatHandler.ListPrinter();

/*Printing smallest spread value*/
Console.WriteLine("\n");
Console.WriteLine("Smallest Spread:" + DatHandler.GetSmallestSpread());

/*Printing days with smallest spread value*/
Console.WriteLine("Registered on the following day/days:");
int[] array = DatHandler.GetIndexSmallerSpread();

foreach (int integer in array)
{
    Console.Write(integer + "*");
}




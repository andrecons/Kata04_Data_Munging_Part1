using Kata04_Data_Munging.StartupConfigs;

//Part 1: print day with lower temperature spread (tSpread = tMax - tMin)

/*Importing the .dat file*/
DatHandler.Importer();

/*Printing the new imported List)*/
Console.WriteLine("Printing values of interest");
DatHandler.ListPrinter();

/*Printing smallest spread value*/
Console.WriteLine("\n");
Console.WriteLine("Smallest Spread:" + DatHandler.GetSmallestSpread());
Console.WriteLine("Registered on day/days");
foreach (int integer in DatHandler.GetIndexSmallerSpread())
{
    Console.WriteLine(integer + "*");
}

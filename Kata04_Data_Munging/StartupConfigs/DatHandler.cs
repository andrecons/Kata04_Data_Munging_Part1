using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Kata04_Data_Munging.Objects;

namespace Kata04_Data_Munging.StartupConfigs

{
    public static class DatHandler
    {
        const String DATFILEPATH = @"..\..\..\InputFiles\weather.dat";

        private static List<Row> rowList = new List<Row>();

        public static void Importer()
        {
            string importedText = "";
            int realDataStartingPoint = 0;

            try

            {
                Console.WriteLine();
                Console.WriteLine("File at " + DATFILEPATH + " found.");
                importedText = System.IO.File.ReadAllText(DATFILEPATH);
                //Console.WriteLine(importedText);
                Console.WriteLine("\n");

                using (var textFile = System.IO.File.OpenText(DATFILEPATH))
                {
                    string line = null;

                    while ((line = textFile.ReadLine()) != null)
                    {
                        //now i have a single line

                        string[] lineToArray = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                        //now there's a splitted line

                        /*TODO: optimize the loop*/
                        for (int i = 0; i < lineToArray.Length; i++)
                        {
                            try
                            {
                                int day = Int16.Parse(lineToArray[0]);
                                decimal firstColumnValue = Decimal.Parse(lineToArray[1].Replace('*', ' '));
                                decimal secondColumnValue = Decimal.Parse(lineToArray[2].Replace('*', ' '));
                                Row tempRow = new Row(day, firstColumnValue, secondColumnValue);
                                rowList.Add(tempRow);
                                break;

                            }
                            catch (Exception e)
                            {
                                //enter when the line hasn't correct data
                                //Console.WriteLine(e.Message);
                                break;

                            }

                        }

                        //Console.WriteLine("ENDING LINE");

                    }
                }
            }
            catch (Exception fileImportException)
            {
                Console.WriteLine(fileImportException.Message);
            }
        }

        public static void ListPrinter()
        {
            Console.WriteLine("Printing values of interest");
            foreach (Row row in rowList)
            {
                Console.WriteLine(row.ToString());
            }
        }

        /*TODO: smaller Spread method*/
        public static decimal GetSmallestSpread()
        {
            decimal smallestSpread = 1000;

            foreach (Row row in rowList)
            {
                if (row.GetSpread() < smallestSpread)
                {
                    smallestSpread = row.GetSpread();
                }
            }
            return smallestSpread;
        }

        public static int[] GetIndexSmallerSpread()
        {
            int sameSpreadDaysCounter = 0;
            foreach (Row row in rowList)
            {
                if (row.GetFirstColumn() - row.GetSecondColumn() == GetSmallestSpread())
                {
                    sameSpreadDaysCounter++;
                }
            }

            int[] daysIndex = new int[sameSpreadDaysCounter];

            decimal smallestSpread = GetSmallestSpread();
 
            int arrayIndex = 0;

            foreach (Row singleRow in rowList)
            {
                if (singleRow.GetSpread() == smallestSpread)
                {
                    daysIndex[arrayIndex] = singleRow.GetId();
                    arrayIndex++;
                }
            }

            return daysIndex;
        }

    }
}

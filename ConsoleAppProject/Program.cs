using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections;
using System.Globalization;
using System.Text.RegularExpressions;

/* TODO:
 * kész | CSV Kiiratás
 * Metódusok nagybetsűsítése
 * osztály adattagok kisbetűsítése
 * nem kell | megoldani hogy a NA (0) érték ne számolódjon bele a statisztikába
 * nem kell | NA kiiratás javítása
 * betöltéskori hiba kezelés tesztelése
    * üres adatbázis probléma
*/

/*
 Paraméteri argumentum amivel használtam: ../../../../athletes.csv ../../../../
*/

namespace ConsoleAppProject
{

    internal class Program
    {
        static IEnumerable<TeamRecord>? dataBase;

        static string inputPath;
        static string outputPath;

        // 6. Feladat
        static void CsvWriter(string path, string fileName, IEnumerable records)
        {
            try
            {
                Console.Write("Creating '" + fileName + "' file at '" + path + "' location....");
                using (var writer = new StreamWriter(path + fileName))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
                {
                    csv.WriteRecords(records);
                }

                Console.WriteLine("DONE");

            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine("FAIL\n" + e.Message);
            }

        }

        // 3. Feladat
        static void Team(string teamName)
        {
            IEnumerable<TeamRecord> teamQuery =
                from record in dataBase
                where record.Team == teamName
                select record;
            int teamCount = teamQuery.ToList<TeamRecord>().Count();

            Console.WriteLine("The number of players in the " + teamName + " team: " + teamCount);
            CsvWriter(outputPath, "team-" + teamName + ".csv", new int[] { teamCount });

        }

        // 4. Feladat
        static void Count(string columnName, int lowerLimit, int upperLimit)
        {
            IEnumerable<TeamRecord> countQuery =
                    from record in dataBase
                    select record;

            if (columnName == "Age")
            {
                countQuery =
                    from record in dataBase
                    where record.Age >= lowerLimit && record.Age <= upperLimit
                    select record;
            }
            else if (columnName == "Height")
            {
                countQuery =
                    from record in dataBase
                    where record.Height >= lowerLimit && record.Age <= upperLimit
                    select record;
            }

            else if (columnName == "Weight")
            {
                countQuery =
                    from record in dataBase
                    where record.Weight >= lowerLimit && record.Age <= upperLimit
                    select record;
            }
            else
            {
                Console.WriteLine("Column name not found");
                return;
            }

            CsvWriter(outputPath, "count-" + columnName + "-" + lowerLimit + "-" + upperLimit + ".csv", countQuery.ToList());

            foreach (var record in countQuery)
            {
                Console.WriteLine(record.ToString());
            }
        }

        // 5. Fealdat
        static void Average(string team, string columnName)
        {
            double averageQuery =
                    (from rec in dataBase.ToList()
                     select rec.Age)
                     .Average(rec => rec);
            try
            {
                if (columnName == "Age")
                {
                    averageQuery =
                        (from rec in dataBase.ToList()
                         where rec.Team == team
                         select rec.Age)
                        .Average(rec => rec);
                }
                else if (columnName == "Height")
                {
                    averageQuery =
                        (from rec in dataBase.ToList()
                         where rec.Team == team
                         select rec.Height)
                        .Average(rec => rec);
                }
                else if (columnName == "Weight")
                {
                    averageQuery =
                        (from rec in dataBase.ToList()
                         where rec.Team == team
                         select rec.Weight)
                        .Average(rec => rec);
                }
                else
                {
                    Console.WriteLine("Column name not found");
                    return;
                }

                double teamAverage = averageQuery;
                Console.WriteLine("The average value of " + columnName + " in the " + team + " team: " + teamAverage);
                CsvWriter(outputPath, "average-" + team + "-" + columnName + ".csv", new double[] { teamAverage });
            }
            catch (System.InvalidOperationException e)
            {
                Console.WriteLine("FAIL\n" + "No such team name found.");
            }
        }

        static void Main(string[] args)
        {

            #region Validate Arguments
            Console.Write("Validateing arguments....");
            if (args == null || args.Length < 2)
            {
                Console.WriteLine("Critical error: Less than 2 parameters");
                return;
            }
            else if (args.Length > 2)
            {
                Console.WriteLine("Critical error: More than 2 parameters");
                return;
            }
            else
            {
                /* argumentumok tartalmának validálása
                // egyáltalán szükség van erre?
                foreach (string arg in args) {

                }

                 Regex locationRegex = new Regex(@"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*\w([\w.])+$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

                if (!locationRegex.Mach(args[0])) Console.WriteLine("this is not a valid file path");
                // TODO: ezt megcsinálni másra is
                */

                inputPath = args[0];
                outputPath = args[1];
                Console.WriteLine("DONE");
            }
            #endregion

            #region CSV loader
            Console.Write("Reading CSV database....");
            try
            {
                using (var reader = new StreamReader(inputPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<TeamMap>();
                    var records = csv.GetRecords<TeamRecord>();
                    dataBase = records.ToList<TeamRecord>();
                }
                Console.WriteLine("DONE");
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine("FAIL\n" + e.Message);
                return;
            }
            #endregion


            #region Terminal Loop

            Regex teamRegex = new Regex(@"^team [a-zA-Z]+", RegexOptions.Compiled);
            Regex countRegex = new Regex(@"^count [a-zA-Z]+ [0-9]+ [0-9]+$", RegexOptions.Compiled);
            Regex averageRegex = new Regex(@"^average [a-zA-Z]+ [a-zA-Z]+$", RegexOptions.Compiled);

            string userInput;
            do
            {
                Console.Write("> ");
                userInput = Console.ReadLine();

                if (teamRegex.Matches(userInput).Count() == 1)
                {
                    string[] subStr = userInput.Split(' ');

                    Team(subStr[1]);

                }
                else if (countRegex.Matches(userInput).Count() == 1)
                {
                    string[] subStr = userInput.Split(' ');
                    Count(subStr[1], int.Parse(subStr[2]), int.Parse(subStr[3]));

                }
                else if (averageRegex.Matches(userInput).Count == 1)
                {
                    string[] subStr = userInput.Split(' ');
                    Average(subStr[1], subStr[2]);

                }
                else if (userInput == "stop")
                {
                    Console.WriteLine("Quitting....DONE");
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("The '" + userInput + "' command not found.");
                }


            } while (userInput != "stop");

            #endregion
        }
    }
}
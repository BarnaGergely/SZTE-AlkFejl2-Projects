using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using static System.Formats.Asn1.AsnWriter;

/* TODO:
 * CSV Kiiratás
 * Metódusok nagybetsűsítése
 * osztály adattagok kisbetűsítése
 * megoldani hogy a NA (0) érték ne számolódjon bele a statisztikába
 * NA kiiratás javítása
 * betöltéskori hiba kezelés tesztelése
    * üres adatbázis probléma
 */

namespace ConsoleAppProject
{

    internal class Program
    {
        static IEnumerable<TeamRecord>? dataBase;

        static string inputPath;
        static string outputPath;

        static void CsvWriter(string path, IEnumerable<TeamRecord>? records)
        {

        }

        static void team(string teamName)
        {
            IEnumerable<TeamRecord> teamQuery =
                from record in dataBase
                where record.Team == teamName
                select record;

            Console.WriteLine(teamQuery.ToList<TeamRecord>().Count());
        }

        static void count(string columnName, int lowerLimit, int upperLimit)
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

            // eredmény kiíratás
            foreach (var record in countQuery)
            {
                Console.WriteLine(record.ToString());
            }
        }

        static void average(string team, string columnName)
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

                Console.WriteLine(averageQuery);
            }
            catch (System.InvalidOperationException e)
            {
                Console.WriteLine("No such team name found.");
            }


        }
        static void Main(string[] args)
        {

            #region validate parameters
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
            }
            #endregion

            #region CSV loader
            try
            {
                using (var reader = new StreamReader(inputPath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<TeamMap>();
                    var records = csv.GetRecords<TeamRecord>();
                    dataBase = records.ToList<TeamRecord>();
                }
            }
            catch (System.IO.FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            #endregion


            #region terminalLoop

            Regex teamRegex = new Regex(@"^team [a-zA-Z]+", RegexOptions.Compiled);
            Regex countRegex = new Regex(@"^count [a-zA-Z]+ [0-9]+ [0-9]+$", RegexOptions.Compiled);
            Regex averageRegex = new Regex(@"^average [a-zA-Z]+ [a-zA-Z]+$", RegexOptions.Compiled);

            string userInput;
            {
                userInput = Console.ReadLine();

                if (teamRegex.Matches(userInput).Count() == 1)
                {
                    string[] subStr = userInput.Split(' ');

                    team(subStr[1]);

                }
                else if (countRegex.Matches(userInput).Count() == 1)
                {
                    string[] subStr = userInput.Split(' ');
                    count(subStr[1], int.Parse(subStr[2]), int.Parse(subStr[3]));

                }
                else if (averageRegex.Matches(userInput).Count == 1)
                {
                    string[] subStr = userInput.Split(' ');
                    average(subStr[1], subStr[2]);

                }
                else if (userInput == "stop")
                {
                    Console.WriteLine("Quitting");
                }
                else
                {
                    Console.WriteLine("The '" + userInput + "' command not found.");
                }


            } while (userInput != "stop") ;

            #endregion
        }
    }
}
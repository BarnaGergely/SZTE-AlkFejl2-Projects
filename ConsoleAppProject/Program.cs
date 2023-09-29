using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using static System.Formats.Asn1.AsnWriter;

namespace ConsoleAppProject
{

    internal class Program
    {
        static IEnumerable<TeamRecord>? dataBase;
        /*
            - Init
                 - parancssori paraméterek betöltése, hibás input kezelés (2 paraméter adható pontosan meg)
                 - adatok betöltése CSV fájlból, hibás input kezelés
            - TerminalLoop
         */
        static void terminate(string message)
        {
            Console.WriteLine(message);
            System.Environment.Exit(1);
        }

        static void init()
        {

        }

        static void validateParameters(string[] args)
        {
        }

        static void terminalLoop()
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

        static void count(string columName, int lowerLimit, int upperLimit)
        {
            IEnumerable<TeamRecord> countQuery =
                    from record in dataBase
                    select record;

            if (columName == "Age")
            {
                countQuery =
                    from record in dataBase
                    where record.Age >= lowerLimit && record.Age <= upperLimit
                    select record;
            }
            else if (columName == "Height")
            {
                countQuery =
                    from record in dataBase
                    where record.Height >= lowerLimit && record.Age <= upperLimit
                    select record;
            }

            else if (columName == "Weight")
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






        static void average(string a, string b)
        {

        }
        static void Main(string[] args)
        {
            string inputPath;
            string outputPath;

            #region init
            #region validateParameters
            if (args == null || args.Length < 2)
            {
                terminate("Critical error: Less than 2 parameters");
                return;
            }
            else if (args.Length > 2)
            {
                terminate("Critical error: More than 2 parameters");
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


            #region loading CSV file
            /* TODO hiba kezelés
            try
            {

            }
            catch ()
            {
                terminate("wrong file path or the file does not exists")
            }
            */

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
                terminate(e.Message);
                return;
            }

            Console.WriteLine("csv successfully loaded.");

            #endregion
            #endregion

            #region terminalLoop

            string userInput;

            Regex teamRegex = new Regex(@"^team [a-zA-Z]+", RegexOptions.Compiled);
            Regex countRegex = new Regex(@"^count [a-zA-Z]+ [0-9]+ [0-9]+$", RegexOptions.Compiled);
            Regex averageRegex = new Regex(@"^avarage [a-zA-Z]+ [0-9]+$", RegexOptions.Compiled);

            do
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


            } while (userInput != "stop");
            #endregion
        }
    }
}
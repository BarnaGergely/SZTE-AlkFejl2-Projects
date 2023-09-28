using System;
using System.Text.RegularExpressions;
using ConsoleAppProject.Team;

namespace ConsoleAppProject
{

    internal class Program
    {
        
        /*
            - Init
                 - parancssori paraméterek betöltése, hibás input kezelés (2 paraméter adható pontosan meg)
                 - adatok betöltése CSV fájlból, hibás input kezelés
            - TerminalLoop
         */
         static void terminate(string message) {
                    Console.WriteLine(message);
                    System.Environment.Exit(1);
         }

         static void init(){
            
         }

         static void validateParameters(string[] args)
         {
         }

         static void terminalLoop(){

         }

        static void team(string teamName)
        {
            return 0;
        }

        static void count(int , int) {

        }

        static void average(string, string) {
            
        }
        static void Main(string[] args)
        {
            string inputPath;
            string outputPath;

            #region init
            #region validateParameters
                if(args == null || args.Length < 2) {
                    terminate("Less than 2 parameters");
                    return;
                } else if(args.Length > 2 ) {
                    terminate("More than 2 parameters");
                    return;
                } else {
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
            // TODO hiba kezelés
            try{

            } catch() {
                terminate("wrong file path or the file does not exists")
            }
            using (var reader = new StreamReader(inputPath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Team>();
            }

            #endregion
            #endregion

            #region terminalLoop

            string userInput;

                Regex teamRegex = new Regex(@"^team [a-zA-Z]+", RegexOptions.Compiled);
                Regex countRegex = new Regex(@"^count [a-zA-Z]+ [1-9]+ [1-9]+", RegexOptions.Compiled);
                Regex averageRegex = new Regex(@"^avarage [a-zA-Z]+ [1-9]+", RegexOptions.Compiled);

            do
            {
                userInput = Console.ReadLine();

                if(teamRegex.Matches(userInput).count() == 1){
                    string[] subStr = userInput.Split(' ');

                    team(subStr[1]);

                } else if (countRegex.Matches(userInput).count() == 1) {
                    string[] subStr = userInput.Split(' ');
                    count(subStr[1], subStr[2]);

                } else if (averageRegex.Matches(userInput). count == 1) {
                    string[] subStr = userInput.Split(' ');
                    average(subStr[1], subStr[2]);
                
                } else {
                    Console.WriteLine("the '"+userInput+"' command not found.");
                }


            } while (userInput != "stop");
            #endregion
        }
    }
}
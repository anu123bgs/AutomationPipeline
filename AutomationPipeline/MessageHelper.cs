using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPipeline
{
    internal static class MessageHelper
    {
        public static void DisplayAllOptions()
        {
            DisplayOptionsMsg();
            Console.WriteLine("1.File Copy");
            Console.WriteLine("2.File Delete");
            Console.WriteLine("3.Query Folder Files");
            Console.WriteLine("4.Create Folder");
            Console.WriteLine("5.Download File");
            Console.WriteLine("6.Wait (in Seconds)");
            Console.WriteLine("7.Row Count");
        }
        public static void DisplayOptionsMsg()
        {
            Console.WriteLine("Choose your option (option#) and press enter to run the command Or Q for closing the app.");
        }
        public static void DisplayWrongParameterMsg()
        {
            Console.WriteLine("Entered Parameter is not correct. Please provide correct parameter values.");
        }        
        public static bool IsInputValid(string firstInput)
        {
            return !string.IsNullOrWhiteSpace(firstInput);
        }
        public static bool AreInputsValid(string firstInput, string secondInput)
        {
            return (!string.IsNullOrWhiteSpace(firstInput)) && (!string.IsNullOrWhiteSpace(secondInput));
        }
    }
}

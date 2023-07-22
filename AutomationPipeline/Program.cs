using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPipeline
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                MessageHelper.DisplayAllOptions();
                int input = -1;
                string inputString = Console.ReadLine();
                if (inputString == "Q" || inputString == "q")
                    break;
                else if (int.TryParse(inputString, out input))
                {
                    switch (input)
                    {
                        case 1:
                            FileCopy();
                            break;
                        case 2:
                            FileDelete();
                            break;
                        case 3:
                            FileList();
                            break;
                        case 4:
                            CreateFolder();
                            break;
                        case 5:
                            DownloadFile();
                            break;
                        case 6:
                            Wait();
                            break;
                        case 7:
                            RowCount();
                            break;
                        default:
                            MessageHelper.DisplayOptionsMsg();
                            break;
                    }
                }
                else
                    MessageHelper.DisplayOptionsMsg();
            }
        }
        private static void FileCopy()
        {
            Console.WriteLine("Enter Source File Path.");
            string sourceFile = Console.ReadLine();
            Console.WriteLine("Enter Destination File Path.");
            string destiationFile = Console.ReadLine();
            bool inputOk = true;
            if (!MessageHelper.AreInputsValid(sourceFile, destiationFile))
            {
                inputOk = false;
                MessageHelper.DisplayWrongParameterMsg();
            }
            if (!inputOk)
                FileCopy();
            else
                fileHandler_.CopyFile(sourceFile, destiationFile);
        }
        private static void FileDelete()
        {
            Console.WriteLine("Enter File Path.");
            string sourceFile = Console.ReadLine();            
            bool inputOk = true;
            if (!MessageHelper.IsInputValid(sourceFile))
            {
                inputOk = false;
                MessageHelper.DisplayWrongParameterMsg();
            }
            if (!inputOk)
                FileDelete();
            else
                fileHandler_.DeleteFile(sourceFile);
        }
        private static void FileList()
        {
            Console.WriteLine("Enter Folder Path.");
            string folderName = Console.ReadLine();
            bool inputOk = true;
            if (!MessageHelper.IsInputValid(folderName))
            {
                inputOk = false;
                MessageHelper.DisplayWrongParameterMsg();
            }
            if (!inputOk)
                FileList();
            else
                fileHandler_.ListFilesInFolder(folderName);
        }
        private static void CreateFolder()
        {
            Console.WriteLine("Enter Folder Path.");
            string folderPath = Console.ReadLine();
            Console.WriteLine("Enter New Folder Name.");
            string folderName = Console.ReadLine();
            bool inputOk = true;
            if (!MessageHelper.AreInputsValid(folderPath, folderName))
            {
                inputOk = false;
                MessageHelper.DisplayWrongParameterMsg();
            }
            if (!inputOk)
                CreateFolder();
            else
                fileHandler_.CreateFolder(folderPath, folderName);
        }
        private static void DownloadFile()
        {
            Console.WriteLine("Enter Source url");
            string sourceUrl = Console.ReadLine();
            Console.WriteLine("Enter output file name.");
            string outputFile = Console.ReadLine();
            bool inputOk = true;
            if (!MessageHelper.AreInputsValid(sourceUrl, outputFile))
            {
                inputOk = false;
                MessageHelper.DisplayWrongParameterMsg();
            }
            if (!inputOk)
                DownloadFile();
            else
            {
                fileHandler_.DownloadFile(sourceUrl, outputFile);
            }
        }
        private static void RowCount()
        {
            Console.WriteLine("Enter Source File Name");
            string filePath = Console.ReadLine();
            Console.WriteLine("Enter string to search.");
            string searchStr = Console.ReadLine();
            bool inputOk = true;
            if (!MessageHelper.AreInputsValid(filePath, searchStr))
            {
                inputOk = false;
                MessageHelper.DisplayWrongParameterMsg();
            }
            if (!inputOk)
                RowCount();
            else
            {
                fileHandler_.RowCount(filePath, searchStr);
            }
        }
        private static void Wait()
        {
            Console.WriteLine("Enter Wait Time in seconds.");
            string waitTime = Console.ReadLine();
            bool inputOk = true;            
            if (!MessageHelper.IsInputValid(waitTime))
            {
                inputOk = false;
                MessageHelper.DisplayWrongParameterMsg();
            }
            if (!inputOk)
                Wait();
            else
            {
                if(int.TryParse(waitTime, out int longTime))
                    fileHandler_.Wait(longTime * 1000);
            }
        }
        private static FileHandler fileHandler_ = new FileHandler();
    }
}

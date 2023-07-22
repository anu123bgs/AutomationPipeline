using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationPipeline
{
    internal class FileHandler
    {
        public FileHandler() { }
        public void CopyFile(string sourceFile, string destinationFile)
        {
            try
            {
                File.Copy(sourceFile, destinationFile);
                Console.WriteLine("File Copied Successfully.");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception occurred while copying file." + ex.Message);
            }            
        }
        public void DeleteFile(string fileName)
        {
            try
            {
                File.Delete(fileName);
                Console.WriteLine("File deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred while deleting file." + ex.Message);
            }            
        }
        public void ListFilesInFolder(string folderPath)
        {
            try
            {
                List<string> fileList = Directory.GetFiles(folderPath).ToList();

                if (fileList != null && fileList.Count() > 0)
                {
                    foreach (string file in fileList)
                    {
                        string fileName = file.Substring(file.LastIndexOf('\\') + 1);
                        Console.WriteLine(fileName + ",");
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception occurred while listing out files in folder" + ex.Message);
            }
        }
        public void CreateFolder(string folderPath, string newFolderName)
        {
            try
            {
                string completePath = folderPath + "\\" + newFolderName;
                if(!Directory.Exists(completePath))
                    Directory.CreateDirectory(completePath);
                Console.WriteLine("Directory Created.");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }            
        }
        public void DownloadFile(string url, string outputFile)
        {
            try
            {
                string fileData;
                using (HttpClient client = new HttpClient())
                {
                    fileData = client.GetStringAsync(url).Result;
                }
                File.WriteAllText(outputFile, fileData);
                Console.WriteLine("File Saved.");
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }        
        public void Wait(int milliseconds)
        {
            try
            {
                Thread.Sleep(milliseconds);
            }
            catch(Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
        public void RowCount(string sourceFile, string searchString)
        {
            try
            {
                int rowCount = File.ReadAllLines(sourceFile).Count(x => x.Contains(searchString));
                Console.WriteLine($"Number of Rows having string {searchString} is {rowCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occurred while counting number of rows \n" + ex.Message);
            }
        }
    }
}

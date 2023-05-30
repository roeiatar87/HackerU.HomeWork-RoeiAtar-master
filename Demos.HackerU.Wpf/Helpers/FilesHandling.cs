using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Demos.HackerU.Wpf.Helpers
{
    public class FilesHandling
    {


        private static string CreateFolder()
        {
            //2--Check If Directory Not Exsist 
            if (!Directory.Exists("AppData\\Images"))
            {
                //--Create New Directory (bin/debug....)
                Directory.CreateDirectory("AppData\\Images");
            }

            return "AppData\\Images";

        }

        public static string ImageUpload()
        {

            string destinationFile = string.Empty;
            string originalFileName = string.Empty;
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == true)
            {
                //Full Path Of Original Image
                string originalFullPath = dialog.FileName;//c:\\Images\animal.jpg
                                                          //Only File Name +Extention Of Original
                originalFileName = Path.GetFileName(originalFullPath);//animal.jpg

                // combine global destination to finel destination
                string destinationFolder = Path.Combine(Environment.CurrentDirectory, CreateFolder());
                // combine global destination to finel destination
                destinationFile = Path.Combine(destinationFolder, originalFileName);
                // File Copy from user folder to our destination

                if (!File.Exists(destinationFile))
                {
                    File.Copy(originalFullPath, destinationFile);
                }

            }
            return CreateFolder() + "\\" + originalFileName;

        }

        //return string array of full path of targetDirectory
        public static string[] GetFolderFilesFull(string targetDirectory)
        {

            var newFileEntries = new string[0];

            if (Directory.Exists(targetDirectory))
            {
                

                string destinationFolder = Path.Combine(Environment.CurrentDirectory, targetDirectory);

                string[] fileEntries = Directory.GetFiles(destinationFolder);

                if (fileEntries != null) 
                {
                    newFileEntries = fileEntries;
                }

                
            }            
            return newFileEntries;

        }
        //return string array of short name of path of targetDirectory
        public static string[] GetFolderFilesShort(string targetDirectory)
        {
            var newFileEntries = new string [0] ; 

            if (Directory.Exists(targetDirectory))
            {
               
            
            string destinationFolder = Path.Combine(Environment.CurrentDirectory, targetDirectory);

            string[] fileEntries = Directory.GetFiles(destinationFolder);



                if (fileEntries != null)
                {
                    for (int i = 0; i < fileEntries.Length; i++)
                    {
                        fileEntries[i] = Path.GetFileName(fileEntries[i]);//animal.jpg
                        fileEntries[i] = fileEntries[i].Replace(".json", "");
                    }

                    newFileEntries = fileEntries;
                }

            }

            return newFileEntries;

        }

        

    }
}

using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string startDirectory = @"D:\Documents";
        TraverseFileSystem(startDirectory, 1);
    }

    static void TraverseFileSystem(string directory, int level)
    {
        try
        {
            string[] files = Directory.GetFiles(directory);
            foreach (string file in files)
            {
                Console.WriteLine($"{new String('-', level + 1)}File: " + file);
            }

            string[] subDirectories = Directory.GetDirectories(directory);
            foreach (string subDirectory in subDirectories)
            {

                Console.WriteLine($"{new String('-', level)}Directory: " + subDirectory);
                TraverseFileSystem(subDirectory, level + 1);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
}

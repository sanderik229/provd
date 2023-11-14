using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        ShowPapka("/");
    }

    static void ShowPapka(string s)
    {
        while (true)
        {
               string[] paths = Directory.GetDirectories(s);
               Console.Clear();
               foreach (string path in paths)
               {

                   DirectoryInfo pathInfo = new DirectoryInfo(path);
                   Console.WriteLine($"   {path}                    {pathInfo.CreationTime}          {pathInfo.Extension}");
               }

               string[] paths1 = Directory.GetFiles(s);
               foreach (string path1 in paths1)
               {
                FileInfo fileInfo = new FileInfo(path1);
                   Console.WriteLine("   " + path1);
               }

               DriveInfo driveInfo = new DriveInfo(Path.GetPathRoot(s));

               Console.WriteLine($"   Свободное место на диске: {driveInfo.AvailableFreeSpace / (1024 * 1024 * 1024)} GB");
               Console.WriteLine($"   Всего места на диске: {driveInfo.TotalSize / (1024 * 1024 * 1024)} GB");

               int pos = Strelki.Pokaz(0, paths.Length + paths1.Length);
               if (pos == -1)
               {
                   return;
               }
                if (pos < paths.Length)
                {
                    ShowPapka(paths[pos -0]);
                }
                else
                {
                    Process.Start(new ProcessStartInfo { FileName = paths1[paths.Length], UseShellExecute = true });
                }
        }
    }
}
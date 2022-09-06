using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ResultsTask3._1
{
    public static class XFile
    {
        public static long count = 0;
             
        public static long size = 0;

        public static int countFile = 0;

        public static long GetSizeDir(string path)
        {

            DirectoryInfo fileAndDirectory = new DirectoryInfo(path);

            if (!fileAndDirectory.Exists)
            {
                Console.WriteLine("папка по заданному адресу не существует");
                return 0;
            }
            else
            {
                try
                {
                    foreach (FileInfo f in fileAndDirectory.GetFiles())
                    {

                        XFile.count = (long)(count + f.Length);
                    }

                    foreach (DirectoryInfo d in fileAndDirectory.GetDirectories())
                    {
                        GetSizeDir(d.FullName);
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Ошибка: ", ex.Message);
                }
            }

            return count;

        }
        public static void DeliteFile(string path)
        {

            DirectoryInfo fileAndDirectory = new DirectoryInfo(path);

            var delay = 1;

            if (!fileAndDirectory.Exists)
            {
                Console.WriteLine("папка по заданному адресу не существует");
            }
            else
            {

                foreach (FileInfo f in fileAndDirectory.GetFiles())
                {

                    if (f.LastWriteTime < DateTime.Now.AddMinutes(-delay))
                    {

                        try
                        {

                            XFile.size = size + f.Length;

                            f.Delete();

                            countFile++;
                        }
                        catch (UnauthorizedAccessException e)
                        {
                            Console.WriteLine("Отсутствует доступ к файлу. Ошибка: " + e.Message);
                        }
                    }

                }

                foreach (DirectoryInfo d in fileAndDirectory.GetDirectories())
                {

                    if (d.LastWriteTime < DateTime.Now.AddMinutes(-delay))
                    {
                        DeliteFile(d.FullName);

                        try
                        {
                            d.Delete();
                        }

                        catch (UnauthorizedAccessException e)
                        {
                            Console.WriteLine("Отсутствует доступ к папке. Ошибка: " + e.Message);
                        }

                    }
                }

            }

        }

    }
}

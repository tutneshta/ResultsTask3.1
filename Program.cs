using System;

namespace ResultsTask3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"E:\Task1\";

            long temp1 = XFile.GetSizeDir(path);

            XFile.DeliteFile(path);

            Console.WriteLine($"Исходный размер папки: {temp1} байт \nОсвобождено: {XFile.size} байт \nФайлов удалено: {XFile.countFile} \nТекущий размер папки: {temp1 - XFile.size} байт");
        }
    }
}

using System;
using System.IO;
using System.Threading.Tasks;

namespace HelloApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string path = @"C:\SomeDir3";
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            Console.WriteLine("INPUT>>");
            string text = Console.ReadLine();

            using (FileStream fstream = new FileStream($"{path}\note.txt", FileMode.OpenOrCreate))
            {
                byte[] array = System.Text.Encoding.Default.GetBytes(text);
                await fstream.WriteAsync(array, 0, array.Length);
                Console.WriteLine("TEXT HAS WRITTEN");
            }

            using (FileStream fstream = File.OpenRead($"{path}\note.txt"))
            {
                byte[] array = new byte[fstream.Length];
                await fstream.ReadAsync(array, 0, array.Length);

                string textFromFile = System.Text.Encoding.Default.GetString(array);
                Console.WriteLine($"YOUR TEXT: {textFromFile}");
            }

            Console.ReadLine();
        }
    }
}
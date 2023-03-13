using System.Text;

namespace NetFileStreamApp
{
    internal class Program
    {
        async static Task Main(string[] args)
        {
            string path = @"D:\RPO\Maxim Efimov\NewDir\file.dat";

            //var stream1 = File.Open(path, FileMode.OpenOrCreate);
            //var streamReader = File.OpenRead(path);
            //var streamWriter = File.OpenWrite(path);

            string text = "Hello world, hello people.";

            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                //byte[] bufferRead = new byte[stream.Length];
                //stream.Read(bufferRead, 0, bufferRead.Length);

                byte[] buffer = Encoding.Default.GetBytes(text);
                //stream.Seek(10, SeekOrigin.Begin);
                await stream.WriteAsync(buffer, 0, buffer.Length);

                //stream.Write(bufferRead, 10, buffer.Length - 10);
            }

            using(FileStream stream = File.OpenRead(path))
            {
                int position = 7;

                byte[] buffer = new byte[position];
                stream.Seek(-position, SeekOrigin.End);
                await stream.ReadAsync(buffer, 0, buffer.Length);

                string textRead = Encoding.Default.GetString(buffer);
                Console.WriteLine(textRead);
            }

            


        }
    }
}
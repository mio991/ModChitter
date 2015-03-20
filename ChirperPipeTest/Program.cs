using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.IO.Pipes;

namespace ChirperPipeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start PipeClient");
            var stream = new NamedPipeClientStream("chirper");
            stream.Connect();

            Console.WriteLine("Create Writer");
            var writer = new StreamWriter(stream);

            Console.WriteLine("You can now start testing");

            while(true)
            {
                writer.WriteLine(Console.ReadLine());
                writer.Flush();
            }
        }
    }
}

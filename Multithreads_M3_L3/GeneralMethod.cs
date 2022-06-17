using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreads_M3_L3
{
    public class GeneralMethod
    {
        public string HelloPath = @"D:\Проекти\Навчання С+\Код\Multithreads_M3_L3\Multithreads_M3_L3\Files\HelloToRead.txt";
        public string WorldPath = @"D:\Проекти\Навчання С+\Код\Multithreads_M3_L3\Multithreads_M3_L3\Files\WorldToRead.txt";

        public string? Hello;
        public string? World;

        public void GenMethod()
        {
            void HelloRead()
            {
                Thread helloThread = new Thread(new ThreadStart(WorldRead));
                helloThread.IsBackground = true;
                helloThread.Priority = ThreadPriority.Highest;
                helloThread.Start();

                Hello = File.ReadAllText(HelloPath);
                Console.WriteLine(Hello);
                Thread.Sleep(100);
            }

            void WorldRead()
            {
                World = File.ReadAllText(WorldPath);
                Console.WriteLine(World);
                Thread.Sleep(150);
            }

            void HelloWorldOutput()
            {
                Console.WriteLine(" ");
                Console.Write(Hello + " " + World);
                Console.WriteLine(" ");
            }

            HelloRead();
            HelloWorldOutput();
        }
    }
}

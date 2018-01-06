using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SampleETLJob;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Running ETL...");

            try
            {
                new MainProcess().Execute();
            }
            catch (Exception ex)
            {
                //your error handler here
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("Complete");
        }
    }
}

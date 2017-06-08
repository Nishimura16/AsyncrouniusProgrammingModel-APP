﻿using ConcurrecnyAPPattern.Example;
using System;

namespace ConcurrecnyAPPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            // Example Claculate Object
            DataCalculator cl = new DataCalculator();
            IAsyncResult Ar = cl.BeginCalculate(1000, 15555, null, null);
            Console.WriteLine("Test");
            Console.WriteLine(cl.EndCalculate(Ar));
            Console.WriteLine("Finished");

            Console.Read();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace ClockClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            int i;

            for (i = 0; i < 86400; i++)
            {
                Thread.Sleep(1000);
                Console.Clear();
                clock.Tick();
                Console.WriteLine(clock.CurrentTime());
            }
        }
    }
}
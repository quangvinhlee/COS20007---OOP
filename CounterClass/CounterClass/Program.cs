public class MainClass
{
    private static void PrintCounters(Counter[] counters)
    {
        foreach (Counter counter in counters)
        {
              Console.WriteLine("{0}:{1}", counter.Name, counter.Ticks);
        }
    }
    private static void Main(string[] args)
    {
        Counter[] myCounters = new Counter[3];
        myCounters[0] = new Counter("Counter 1");
        myCounters[1] = new Counter("Counter 2");
        myCounters[2] = myCounters[0];
        for (int i = 0; i < 9; i++)
        {
            myCounters[0].Increment();
        }
        for (int i = 1; i < 14; i++)
        {
            myCounters[1].Increment();
         
        }
        MainClass.PrintCounters(myCounters);
        myCounters[2].Reset();
        MainClass.PrintCounters(myCounters);
    }
}
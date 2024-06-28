using System.Timers;
using Timer = System.Timers.Timer;

namespace TimerInCSharp
{
    public class Program
    {
        static Timer timer = new Timer(1000);
        public static void Main(string[] args)
        {
            timer.Elapsed += CurrentTime;
            timer.Enabled = true;
            Thread thread1 = new Thread(CountDown);
            Thread thread2 = new Thread(CountUp);
            thread1.Start();
            thread2.Start();

            Console.ReadKey(true);
        }

        public static void CurrentTime(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine(e.SignalTime.ToString("d MMMM yyyy, HH:mm:ss:fff"));
            Console.WriteLine(DateTime.Now.ToString("d MMMM yyyy, HH:mm:ss:fff"));
            Console.WriteLine();
        }
        public static void CountDown()
        {
            for (int i = 10; i > 0; i--)
            {
                Console.WriteLine($"Count down {i}");
                Thread.Sleep(2000);
            }
            Console.WriteLine("Count down ended");
        }
        public static void CountUp()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Count up {i}");
                Thread.Sleep(2000);
            }
            Console.WriteLine("Count up ended");
        }
    }
}

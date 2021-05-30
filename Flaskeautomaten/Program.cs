using System;
using System.Threading;

namespace Flaskeautomaten
{
    class Program
    {
        static Producer producer = new Producer();
        static Splitter splitter = new Splitter();
        static Consumer consumer = new Consumer();

        static void Main(string[] args)
        {
            Thread threadUser = new Thread(producer.CreateDrink);
            Thread threadSplitter = new Thread(splitter.SplitDrinks);
            Thread threadSodaConsumer = new Thread(consumer.ConsumeSoda);
            Thread threadBeerConsumer = new Thread(consumer.ConsumeBeer);

            threadUser.Start();
            threadSplitter.Start();
            threadSodaConsumer.Start();
            threadBeerConsumer.Start();

            Console.ReadLine();
        }
    }
}

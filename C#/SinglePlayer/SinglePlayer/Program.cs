using System;
using SinglePlayer.Entities;
using SinglePlayer.Entities.Interfaces;

namespace SinglePlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            Item item = new Item
            {
                Name = "Trt"
            };
            Console.WriteLine("The item's name is: " + item.Name);
            Console.ReadKey();
        }
    }
}

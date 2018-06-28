using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SinglePlayer.Entities;

namespace SinglePlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            testEntity();


            Console.ReadKey();
        }

        static void testEntity()
        {
            PlayerCharacter entity = new PlayerCharacter();
            Console.WriteLine(entity.EntityID);
        }
    }
}

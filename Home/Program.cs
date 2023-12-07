using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home
{
    public class Program
    {
        static void Main()
        {
            List<string> masty = new List<string> { "Черви", "Бубны", "Крести", "Пики" };
            List<string> tipy = new List<string> { "6", "7", "8", "9", "10", "Валет", "Дама", "Король", "Туз" };

            Game game = new Game(masty, tipy);
            game.Play();
        }
    }
}

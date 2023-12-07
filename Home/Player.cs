using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home
{
    /// <summary>
    /// 2.	Класс Player (набор имеющихся карт, вывод имеющихся карт).
    /// </summary>
    class Player
    {
        public List<Karta> Cards { get; set; } = new List<Karta>();

        public void DisplayCards()
        {
            Console.Write("Имеющиеся карты: ");
            foreach (var card in Cards)
            {
                Console.Write($"{card.Mast} {card.Tip}, ");
            }
            Console.WriteLine();
        }
    }
}

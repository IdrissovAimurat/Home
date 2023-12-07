using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home
{
    /// <summary>
    /// 1.	Класс Game формирует и обеспечивает: 
    ///     a.Список игроков(минимум 2);
    ///     b.Колоду карт(36 карт);
    ///     c.Перетасовку карт(случайным образом);
    ///     d.Раздачу карт игрокам(равными частями каждому игроку);
    ///     e.Игровой процесс.Принцип: Игроки кладут по одной карте.
    ///     У кого карта больше, то тот игрок забирает все карты и кладет их в конец своей колоды.
    ///     Упрощение: при совпадении карт забирает первый игрок, шестерка не забирает туза. 
    ///     Выигрывает игрок, который забрал все карты.
    /// </summary>

    class Game
    {
        private List<Karta> Koloda { get; set; } = new List<Karta>();
        private List<Player> Players { get; set; } = new List<Player>();

        public Game(List<string> masty, List<string> tipy)
        {
            foreach (var mast in masty)
            {
                foreach (var tip in tipy)
                {
                    Koloda.Add(new Karta(mast, tip));
                }
            }

            Random random = new Random();
            Koloda = Koloda.OrderBy(x => random.Next()).ToList();

            Players.Add(new Player());
            Players.Add(new Player());

            for (int i = 0; i < Koloda.Count; i++)
            {
                Players[i % 2].Cards.Add(Koloda[i]);
            }
        }

        public void Play()
        {
            foreach (var player in Players)
            {
                player.DisplayCards();
            }

            for (int i = 0; i < Players[0].Cards.Count; i++)
            {
                Console.WriteLine($"Играем карту {Players[0].Cards[i].Mast} {Players[0].Cards[i].Tip} и {Players[1].Cards[i].Mast} {Players[1].Cards[i].Tip}");

                if (Players[0].Cards[i].Tip.CompareTo(Players[1].Cards[i].Tip) > 0)
                {
                    Console.WriteLine("Игрок 1 забирает карты!");
                    Players[0].Cards.AddRange(Players[1].Cards);
                }
                else
                {
                    Console.WriteLine("Игрок 2 забирает карты!");
                    Players[1].Cards.AddRange(Players[0].Cards);
                }
            }

            if (Players[0].Cards.Count > Players[1].Cards.Count)
            {
                Console.WriteLine("Победил Игрок 1!");
            }
            else if (Players[0].Cards.Count < Players[1].Cards.Count)
            {
                Console.WriteLine("Победил Игрок 2!");
            }
            else
            {
                Console.WriteLine("Ничья!");
            }
        }
    }
}

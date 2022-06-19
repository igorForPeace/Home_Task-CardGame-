using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_Home_Task_CardGame_
{
    /// <summary>
    /// Класс описывающий простую игру в карты
    /// </summary>
    class Game
    {
        /// <summary>
        /// Поля класса
        /// </summary>
        public delegate void KeyDelegate();
        public event KeyDelegate KeyPress;          //любое событие
        public event KeyDelegate KeyPressShuffle;   //событие на перемещивание карт
        public event KeyDelegate KeyPressGiving;    //событие на раздачу карт
        private List<Card> cards;                   //Список карт
        private List<Player> players;               //Список игроков
        private static Random random = new Random();

        /// <summary>
        /// Конструктор по умолчанию создает колоду из 36 кард и 2 игрока
        /// </summary>
        public Game()
        {
            cards = new List<Card>();
            for (int i = 3; i <=6 ; i++)
            {
                int tempPower = 1;  // переменная для обозначения силы карты
                for (int j = 6; j <=14 ; j++)
                {
                    if (j>=6&&j<=10) // если карты от 6 до 10, то они будут со значением 6, 7 и так до 10
                    {
                        cards.Add(new Card(j.ToString(), (char)i, tempPower));
                    }
                    else
                    {
                        switch (j)  //Валет, дама, король и туз
                        {
                            case 11:
                                cards.Add(new Card("V", (char)i, tempPower));
                                break;
                            case 12:
                                cards.Add(new Card("Q", (char)i, tempPower));
                                break;
                            case 13:
                                cards.Add(new Card("K", (char)i, tempPower));
                                break;
                            case 14:
                                cards.Add(new Card("A", (char)i, tempPower));
                                break;
                        }
                    }
                    tempPower++;
                }
            }          
            players = new List<Player>();
            for (int i = 0; i < 2; i++)
            {
                players.Add(new Player());
            }   
        }

        /// <summary>
        /// Метод для перемещивание колоды
        /// </summary>
        private void Shuffle()
        {
            for (int i = cards.Count-1; i >= 1; i--)
            {
                int j = random.Next(i + 1);
                var temp = cards[j];
                cards[j] = cards[i];
                cards[i] = temp;
            }
        }

        /// <summary>
        /// Специальный метод для раздачи карт игрокам
        /// </summary>
        private void GiveCards()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (i < cards.Count / 2)
                {
                    players[0].AddCard(cards[i]);
                }
                else
                {
                    players[1].AddCard(cards[i]);
                }
            }
        }

        /// <summary>
        /// Метод показывающий все карты из колоды, даже не перемещаные 
        /// </summary>
        private void ShowAllCards()
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (i % 9 == 0) Console.WriteLine();
                cards[i].ShowCard();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// показ карт игроков
        /// </summary>
        private void ShowPlayersCard()
        {
            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("Cards of Player #" + (i+1));
                players[i].ShowCards();
            }
        }

        /// <summary>
        /// Метод поиска игрока с наибольшим количество карт
        /// </summary>
        private void FindTheWinner()
        {
            if (players[0].GetSize()>players[1].GetSize())
            {
                Console.WriteLine("\nPlayer #1 is Winner!\n");
                Console.WriteLine("Good bye!\n");
                Environment.Exit(0);
            }
            else if (players[0].GetSize() < players[1].GetSize())
            {
                Console.WriteLine("\nPlayer #2 is Winner!\n");
                Console.WriteLine("Good bye!\n");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("\nWe can not find the winner(\nMake round!");
            }
        }

        /// <summary>
        /// Метод для розыграша карт.
        /// Игроки сравнивают две первые карты
        /// У кого значение карты больше - тот и забирает 2 карты и кладет их в конец колоды
        /// </summary>
        private void Round()
        {
            List<Card> temp = new List<Card>();  //создание временного хранилища двух сравниемых карт
            for (int i = 0; i < 2; i++)
            {
                temp.Add(players[i].GetFirstCard());
            }
            if (players[0].GetPower(0)>players[1].GetPower(0)) //проверка на мощность карт
            {
                players[0].RemoveFirst();
                players[1].RemoveFirst();
                for (int i = 0; i < temp.Count; i++)
                {
                    players[0].AddCard(temp[i]);
                }
            }
            else if (players[0].GetPower(0) < players[1].GetPower(0))
            {
                players[0].RemoveFirst();
                players[1].RemoveFirst();
                for (int i = 0; i < temp.Count; i++)
                {
                    players[1].AddCard(temp[i]);
                }
            }
            else  // если две карты равны
            {
                players[0].RemoveFirst();
                players[1].RemoveFirst();
                for (int i = 0; i < 2; i++)
                {
                    players[i].AddCard(temp[i]);
                }
            }
            if (players[0].GetSize()==0)  // если карты закончились у одного из игроков игра заканчивается 
            {
                Console.WriteLine("\nPlayer #2 is winner!\n");
                Console.WriteLine("Good bye!\n");
                Environment.Exit(0);
            }
            else if (players[1].GetSize() == 0)
            {
                Console.WriteLine("\nPlayer #1 is winner!\n");
                Console.WriteLine("Good bye!\n");
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Метод, который начинает игру
        /// </summary>
        public void PlayGame()
        {
            KeyPressShuffle = null; // событие на перемешивание карт, если карты не перемешаны, то мы не можем их раздать
            KeyPressGiving = null;  // событие на раздачу карт, если карты уже у игроков, то перемешать или посмотреть все карты целиком уже нельзя
            Console.WriteLine("=================================");
            Console.WriteLine("You just started a new card game");
            Console.WriteLine("What do you want?");
            while (true)
            {
                Console.WriteLine("\n1 - Show cards");
                Console.WriteLine("2 - Shuffle");
                Console.WriteLine("3 - Give cards to the Players");
                Console.WriteLine("4 - Show Players cards");
                Console.WriteLine("5 - Make a round");
                Console.WriteLine("6 - Find a winner");
                Console.WriteLine("ESC - EXIT the Game");
                ConsoleKeyInfo key = Console.ReadKey(true); // переменная для реагирование нажатий
                if (key.Key==ConsoleKey.D1)
                {
                    if (KeyPressGiving==null)
                    {
                        Console.WriteLine("\n====\n(function showing the cards)");
                        KeyPress = null;
                        KeyPress += this.ShowAllCards;
                    }
                    else
                    {
                        Console.WriteLine("\n====\n(Card went to the player)");
                        continue;
                    }    
                }
                if (key.Key==ConsoleKey.D2)
                {
                    if (KeyPressGiving == null)
                    {
                        Console.WriteLine("\n====\n(function shuffle the cards done! Press 1 to see result)");
                        KeyPress = null;
                        KeyPress += this.Shuffle;
                        KeyPressShuffle += this.Shuffle;
                    }
                    else
                    {
                        Console.WriteLine("\n====\n(You can not shuffle. Cards were given to the Players)");
                        continue;
                    }
                }
                if (key.Key==ConsoleKey.D3)
                {
                    if (KeyPressGiving!=null)
                    {
                        Console.WriteLine("\n====\n(You have already given the cards to the players)");
                        KeyPress = null;
                        continue;
                    }
                    if (KeyPressShuffle!=null)
                    {
                        Console.WriteLine("\n====\n(Giving the cards to the players)");
                        KeyPress = null;
                        KeyPress += this.GiveCards;
                        KeyPressGiving += GiveCards;
                    }
                    else
                    {
                        KeyPress = null;
                        Console.WriteLine("\n====\n(Before giving cards to the Player you need to shuffle them!!!)");
                    }   
                }
                if (key.Key==ConsoleKey.D4)
                {
                    if (KeyPressGiving!=null)
                    {
                        Console.WriteLine("\n====\n(function show the Players cads)");
                        KeyPress = null;
                        KeyPress += this.ShowPlayersCard;
                    }
                    else
                    {
                        Console.WriteLine("\n====\n(You have not given the cards to the players!)");
                        continue;
                    }
                }
                if (key.Key==ConsoleKey.D5)
                {
                    if (KeyPressGiving!=null)
                    {
                        Console.WriteLine("\n====\n(Function round has been called!)");
                        KeyPress = null;
                        KeyPress += this.Round;
                        KeyPress += this.ShowPlayersCard;
                    }
                    else
                    {
                        Console.WriteLine("\n====\n(You have not given the cards to the players!)");
                        continue;
                    }
                }
                if (key.Key==ConsoleKey.D6)
                {
                    if (KeyPressGiving != null)
                    {
                        Console.WriteLine("\n====\n(Function Find The Winner has been called!)");
                        KeyPress = null;
                        KeyPress += this.FindTheWinner;
                    }
                    else
                    {
                        Console.WriteLine("\n====\n(You have not given the cards to the players!)");
                        continue;
                    }
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("\nHave a good day!\n");
                    break;
                }
                KeyPress?.Invoke();
            }
        }
    }
}

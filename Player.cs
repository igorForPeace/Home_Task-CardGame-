using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_Home_Task_CardGame_
{
    /// <summary>
    /// Класс описывающий одного игрока
    /// </summary>
    class Player
    {
        private List<Card> playerCard;

        /// <summary>
        /// Конструктор по умолчанию, создающий игрока с пустой колодой кард
        /// </summary>
        public Player()
        {
            playerCard = new List<Card>();
        }

        /// <summary>
        /// метод показа всех карт игрока
        /// </summary>
        public void ShowCards()
        {
            foreach (var item in playerCard)
            {
                item.ShowCard();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Метод добавление карты в колоду к игроку
        /// </summary>
        /// <param name="card">Объект класса карты, который необходимо передать в качестве параметра</param>
        public void AddCard(Card card)
        {
            playerCard.Add(card);
        }
        /// <summary>
        /// Удаление первой карты из колоды
        /// </summary>
        public void RemoveFirst()
        {
            this.playerCard.RemoveAt(0);
        }
        /// <summary>
        /// ВОзвращает значение силы карты по заданному индексу из колоды игрока
        /// </summary>
        /// <param name="index">Индекс карты из списка колоды</param>
        /// <returns></returns>
        public int GetPower(int index)
        {
            return playerCard[index].Power;
        }
        /// <summary>
        /// выдает программе первую карту из колоды игрока
        /// </summary>
        /// <returns>возвращает первую карту из колоды</returns>
        public Card GetFirstCard()
        {
            return playerCard[0];
        }
        /// <summary>
        /// Метод для нахождения длины списка из карт
        /// </summary>
        /// <returns>возвращает целочисленное значение длины списка карт</returns>
        public int GetSize()
        {
            return playerCard.Count;
        }
    }
}

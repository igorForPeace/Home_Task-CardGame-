using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1_Home_Task_CardGame_
{
    /// <summary>
    /// Класс описывающий сущность одной карты
    /// </summary>
    class Card
    {
        private string value;
        private char type;
        private int power;
        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="value">Это поле хранит значение от 6 до 10 либо от Валета до Туза</param>
        /// <param name="type">Это поле хранит масть карты, бубен чирва и так далее</param>
        /// <param name="power">Сила карты от 1 до 9</param>
        public Card(string value, char type, int power)  
        {
            this.value = value;
            this.type = type;
            this.power = power;
        }
        /// <summary>
        /// метод показа одной карты
        /// </summary>
        public void ShowCard()
        {
            Console.Write("|" + this.value + this.type + "|");
        }
        /// <summary>
        /// Свойство позволяющее получить значение силы карты
        /// </summary>
        public int Power
        {
            get { return this.power; }
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TransportCardSystem
{
    class Program
    {
        

        
        static void Main (string[] args)
        {

            var menuItems = new string[]
            {
                "Купить траспортную карту",
                "Пополнить транспортную карту",
                "Проверить баланс траспортной карты",
                "Валидировать траспортную карту",
                "Выйти"
            };
            for(var i = 0; i < menuItems.Length; i++)
            {
                if(i % 2 == 0)
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                else
                {
                    //Console.BackgroundColor = ConsoleColor.Black;
                    Console.ResetColor();
                }
                Console.WriteLine($"{i + 1} - {menuItems[i]}");
            }
            Console.ResetColor();
            Console.WriteLine("Выбрать:");

            var userChoice = Console.ReadLine();
        }
    }
}

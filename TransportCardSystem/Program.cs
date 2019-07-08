using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TransportCardSystem
{
    class Program
    {
        
        public enum MenuItemsId
        {
            ID_BUY = 1,
            ID_RECHARGE,
            ID_BALANCE,
            ID_VALIDATE,
            ID_EXIT
        }
        
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
                    Console.ResetColor();
                }
                Console.WriteLine($"{i + 1} - {menuItems[i]}");
            }
            Console.ResetColor();
            Console.WriteLine("Выбрать:");

            var userChoice = Convert.ToInt32(Console.ReadLine());
            switch((MenuItemsId)userChoice)
            {
                case MenuItemsId.ID_BUY:
                    {
                        var transortCard = new TransportCard();
                        break;
                    }
                case MenuItemsId.ID_RECHARGE:
                    {
                        break;
                    }
                case MenuItemsId.ID_BALANCE:
                    {
                        break;
                    }
                case MenuItemsId.ID_VALIDATE:
                    {
                        break;
                    }
                case MenuItemsId.ID_EXIT:
                    {                        
                        break;
                    }
            }
        }
    }
}

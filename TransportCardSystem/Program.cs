using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TransportCardSystem
{
    class Program
    {
        public enum MenuId
        {
            ID_BUY,
            ID_RECHARGE,
            ID_VALIDATE,
            ID_EXIT,
        }

        static void Main (string[] args)
        {

            var menu = new Menu();
            var isExit = false;
            var menuItems = new List<string>();
            var menuItemsId = new List<int>();

            menuItems.Add("Купить траспортную карту");
            menuItems.Add("Пополнить транспортную карту");
            menuItems.Add("Валидировать траспортную карту");
            menuItems.Add("Выйти");

            menuItemsId.Add((int) MenuId.ID_BUY);
            menuItemsId.Add((int) MenuId.ID_RECHARGE);
            menuItemsId.Add((int) MenuId.ID_VALIDATE);
            menuItemsId.Add((int) MenuId.ID_EXIT);
            Console.CursorVisible = false;
            //do
            //{

            while (!isExit)
            {


                var selectMenuItem = menu.ShowMenu(menuItems, menuItemsId);
                switch (selectMenuItem)
                {
                    case (int) MenuId.ID_EXIT:
                        {
                            isExit = true;
                            break;
                        }
                    case (int) MenuId.ID_BUY:
                        {
                            Console.Clear();
                            Console.WriteLine("Купить карту");
                            break;
                        }
                    case (int) MenuId.ID_RECHARGE:
                        {
                            Console.Clear();
                            Console.WriteLine("Пополнить карту");
                            break;
                        }
                    case (int) MenuId.ID_VALIDATE:
                        {
                            Console.Clear();
                            Console.WriteLine("Валидировать карту");
                            break;
                        }

                }
            }
            //} while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
    }
}

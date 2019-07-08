using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportCardSystem
{
    public class Menu
    {
       
        private ConsoleColor _defaultTextColor { get; set; } = ConsoleColor.Gray;
        private ConsoleColor _defaultBGColor { get; set; } = ConsoleColor.Black;
        private ConsoleColor _selectTextColor { get; set; } = ConsoleColor.Yellow;
        private ConsoleColor _selectBGColor { get; set; } = ConsoleColor.DarkBlue;
        private int _selectPosition;

        public Menu (){}

        public int ShowMenu(List<string> menuItems, List<int> menuItemsId)
        {
            
            
            var input = Console.ReadKey();
            
            Console.Clear();
            //do
            //{
            for (var i = 0; i < menuItems.Count; i++)
                {
                Console.SetCursorPosition(left: 0, top: 0 + i);
                    if(_selectPosition == i)
                    {
                        Console.BackgroundColor = _selectBGColor;
                        Console.ForegroundColor = _selectTextColor;
                    }
                    else
                    {
                        Console.BackgroundColor = _defaultBGColor;
                        Console.ForegroundColor = _defaultTextColor;
                    }
                    Console.WriteLine(menuItems[i]);
                }

                Console.ResetColor();

                switch(input.Key)
                {
                    case ConsoleKey.UpArrow:
                        {
                            if(_selectPosition > 0)
                            {
                                _selectPosition--;
                            }
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if(_selectPosition < menuItems.Count - 1)
                            {
                                _selectPosition++;                           
                            }
                            break;
                        }
                    case ConsoleKey.Enter:
                        {
                            return menuItemsId[_selectPosition];
                        }
                }
            //} while (true);
            return -1;
        }
    }
}

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
            var cards = new List<TransportCard>();
            var menuItems = new string[]
            {
                "Купить траспортную карту",
                "Пополнить транспортную карту",
                "Проверить баланс траспортной карты",
                "Валидировать траспортную карту",
                "Выйти"
            };
            var isExit = false;
            while (!isExit)
            {
                Console.WriteLine("\n");
                for (var i = 0; i < menuItems.Length; i++)
                {
                    if (i % 2 == 0)
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
                Console.WriteLine("\nВыбрать:");

                Console.ForegroundColor = ConsoleColor.Yellow;
                var userChoice = Convert.ToInt32(Console.ReadLine());
                Console.ResetColor();

                switch ((MenuItemsId) userChoice)
                {
                    case MenuItemsId.ID_BUY:
                        {
                            var transportCard = new TransportCard();
                            cards.Add(transportCard);
                            Console.Write("\nНомер вашей карты равен ");

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(transportCard.CardId);
                            Console.ResetColor();

                            Console.Write(".");
                            break;
                        }
                    case MenuItemsId.ID_RECHARGE:
                        {
                            Console.WriteLine("\nВведите номер вашей карты:");

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            var userInputId = Convert.ToInt32(Console.ReadLine());
                            Console.ResetColor();

                            TransportCard result = cards.Find(value => value.CardId == userInputId);
                            if(result.IsValid())
                            {
                                Console.WriteLine("Введите сколько хотите внести на баланс:");

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                var userInputMoney = Convert.ToInt32(Console.ReadLine());
                                Console.ResetColor();

                                result.Wallet = userInputMoney;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine($"Истёк срок годности вашей карты № {result.CardId}");
                                Console.ResetColor();
                            }
                            
                            break;
                        }
                    case MenuItemsId.ID_BALANCE:
                        {
                            Console.WriteLine("Введите номер вашей карты:");

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            var userInputId = Convert.ToInt32(Console.ReadLine());
                            Console.ResetColor();

                            TransportCard result = cards.Find(value => value.CardId == userInputId);
                            Console.Write("\nБаланс равен ");

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(result.Wallet);
                            Console.ResetColor();

                            Console.Write(" тг.");

                            Console.Write("\nКарта годна до ");

                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(result.ExpiryDate);
                            Console.ResetColor();

                            Console.Write(".");

                            break;
                        }
                    case MenuItemsId.ID_VALIDATE:
                        {
                            Console.WriteLine("Введите номер вашей карты:");

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            var userInputId = Convert.ToInt32(Console.ReadLine());
                            Console.ResetColor();

                            TransportCard result = cards.Find(value => value.CardId == userInputId);

                            if (result.IsValid())
                            {
                                if(result.IsPaid())
                                {
                                    Console.ForegroundColor = ConsoleColor.Green;
                                    Console.WriteLine("Успешно оплачено!");
                                    Console.ResetColor();
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Magenta;
                                    Console.WriteLine("Недостаточно средств на карте!");
                                    Console.ResetColor();
                                }
                                
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine($"Истёк срок годности вашей карты № {result.CardId}");
                                Console.ResetColor();
                            }

                            break;
                        }
                    case MenuItemsId.ID_EXIT:
                        {
                            isExit = true;
                            break;
                        }
                    default:
                        {
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            Console.WriteLine("Введена неправильная команда");
                            Console.ResetColor();
                            break;
                        }
                }
            }
        }
    }
}

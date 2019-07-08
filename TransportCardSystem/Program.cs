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
                Console.WriteLine();
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

                var userChoice = Convert.ToInt32(Console.ReadLine());
                switch ((MenuItemsId) userChoice)
                {
                    case MenuItemsId.ID_BUY:
                        {
                            var transportCard = new TransportCard();
                            cards.Add(transportCard);
                            Console.WriteLine($"Номер вашей карты равен {transportCard.CardId}");
                            break;
                        }
                    case MenuItemsId.ID_RECHARGE:
                        {
                            Console.WriteLine("\nВведите номер вашей карты:");
                            var userInputId = Convert.ToInt32(Console.ReadLine());
                            TransportCard result = cards.Find(value => value.CardId == userInputId);
                            if(result.IsValid())
                            {
                                Console.WriteLine("Введите сколько хотите внести на баланс:");
                                var userInputMoney = Convert.ToInt32(Console.ReadLine());
                                result.Wallet = userInputMoney;
                            }
                            else
                            {
                                Console.WriteLine($"Истёк срок годности вашей карты № {result.CardId}");
                            }
                            
                            break;
                        }
                    case MenuItemsId.ID_BALANCE:
                        {
                            Console.WriteLine("Введите номер вашей карты:");
                            var userInputId = Convert.ToInt32(Console.ReadLine());
                            TransportCard result = cards.Find(value => value.CardId == userInputId);
                            Console.WriteLine($"Баланс равен {result.Wallet}.");
                            Console.WriteLine($"Карта годна до {result.ExpiryDate}");
                            break;
                        }
                    case MenuItemsId.ID_VALIDATE:
                        {
                            Console.WriteLine("Введите номер вашей карты:");
                            var userInputId = Convert.ToInt32(Console.ReadLine());

                            TransportCard result = cards.Find(value => value.CardId == userInputId);

                            if (result.IsValid())
                            {
                                if(result.IsPaid())
                                {
                                    Console.WriteLine("Успешно оплачено!");
                                }
                                else
                                {
                                    Console.WriteLine("Недостаточно средств на карте!");
                                }
                                
                            }
                            else
                            {
                                Console.WriteLine($"Истёк срок годности вашей карты № {result.CardId}");
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
                            Console.WriteLine("Введена неправильная команда");
                            break;
                        }
                }
            }
        }
        
    }
}

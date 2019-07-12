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
      ID_BUY = 0,
      ID_RECHARGE,
      ID_BALANCE,
      ID_VALIDATE,
      ID_EXIT
    }

    static void Main(string[] args)
    {
      try { 
      int select = 0;
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
          if (Console.KeyAvailable)
          {
            var key = Console.ReadKey();
            Console.WriteLine(key.KeyChar);
            if (key.Key == ConsoleKey.UpArrow)
            {
              if (select == 0)
                select = menuItems.Length;
              select--;
            }
            else if (key.Key == ConsoleKey.DownArrow)
            {
              if (select == menuItems.Length - 1)
                select = -1;
              select++;
            }
            else if (key.Key == ConsoleKey.Enter)
            {
              switch (select)
              {
                case (int)MenuItemsId.ID_BUY:
                  {
                    Console.Clear();
                    var transportCard = new TransportCard();
                    cards.Add(transportCard);
                    Console.Write("\nНомер вашей карты равен ");

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write(transportCard.CardId);
                    Console.ResetColor();

                    Console.Write(".");
                    Console.ReadLine();
                    Console.Clear();
                    break;
                  }
                case (int)MenuItemsId.ID_RECHARGE:
                  {
                    Console.Clear();
                    Console.WriteLine("\nВведите номер вашей карты:");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    var userInputId = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();

                    TransportCard result = cards.Find(value => value.CardId == userInputId);
                    if (result.IsValid())
                    {
                      Console.WriteLine("Введите сколько хотите внести на баланс:");

                      Console.ForegroundColor = ConsoleColor.Yellow;
                      var userInputMoney = Convert.ToInt32(Console.ReadLine());
                      Console.ResetColor();

                      result.Wallet += Math.Abs(userInputMoney);
                    }
                    else
                    {
                      Console.ForegroundColor = ConsoleColor.Magenta;
                      Console.WriteLine($"Истёк срок годности вашей карты № {result.CardId}");
                      Console.ResetColor();
                    }
                    Console.Clear();
                    break;
                  }
                case (int)MenuItemsId.ID_BALANCE:
                  {
                    Console.Clear();
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
                    Console.ReadLine();
                    Console.Clear();
                    break;
                  }
                case (int)MenuItemsId.ID_VALIDATE:
                  {
                    Console.Clear();
                    Console.WriteLine("Введите номер вашей карты:");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    var userInputId = Convert.ToInt32(Console.ReadLine());
                    Console.ResetColor();

                    TransportCard result = cards.Find(value => value.CardId == userInputId);

                    if (result.IsValid())
                    {
                      if (result.IsPaid())
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
                    Console.ReadLine();
                    Console.Clear();
                    break;
                  }
                case (int)MenuItemsId.ID_EXIT:
                  {
                    Console.Clear();
                    Console.Write($"Вы уверены что хотите выйти?(y/n): ");
                    var ans = Console.ReadLine();
                    if (ans == "y" || ans == "Y")
                    {
                      Console.Clear();
                      Console.WriteLine($"До свидания! ");
                      Console.ReadLine();
                      isExit = true;
                    }
                    Console.Clear();
                    break;
                  }
              }
            }

            Console.SetCursorPosition(0, 0);
            for (var i = 0; i < menuItems.Length; i++)
            {
              if (select == i)
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
          }
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.Message);
        Console.ReadLine();
      }
    }
  }
}

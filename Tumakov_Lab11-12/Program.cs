using System;
using System.Collections.Generic;
using BankAccount;
using Building;

namespace Tumakov_Lab11_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Лабораторная работа Тумаков 11, упражнения 11.1,11.2");
            AccountFactory factory = new AccountFactory();
            Account account1 = factory.CreateAccount( 1000, AccountType.Debit);
            Account account2 = factory.CreateAccount( 2000, AccountType.Credit);
            Console.WriteLine("Счет 1:");
            Console.WriteLine(account1);
            Console.WriteLine("Счет 2:");
            Console.WriteLine(account2);
            factory.CloseAccount(1);
            if (AccountFactory.IsBankAccountClosed(1))
            {
                Console.WriteLine("Первый аккаунт закрыт");
            }
            Console.WriteLine("Нажмите Enter");
            Console.ReadKey();

            Console.WriteLine("Лабораторная работа Тумаков 11, домашнее задание 11.1,11.2");
            Build building1 = Creator.CreateBuilding(100, 10, 100, 5);
            Build building2 = Creator.CreateBuilding(200, 20, 200, 10);
            Console.WriteLine(building1);
            Console.WriteLine(building2);
            Creator.RemoveBuilding(building1.GetUniqueNumber());
            if (Creator.IsBuildingClosed(building1.GetUniqueNumber()))
            {
                Console.WriteLine("Первое здание закрыто");
            }
            Console.WriteLine("Нажмите Enter");
            Console.ReadKey();

            Console.WriteLine("Лабораторная работа Тумаков 12, упражнение 12.1");
            Console.WriteLine("Сравниваем аккаунты");
            Console.WriteLine($"== { account1 == account2}");
            Console.WriteLine($"!={ account1 != account2}");
            account2.SetBalance(3000);
            Console.WriteLine($"=={account1 == account2}");
            Console.WriteLine($"!={account1 != account2}");
            Console.WriteLine("Нажмите Enter");
            Console.ReadKey();

            Console.WriteLine("Лабораторная работа Тумаков 12, упражнение 12.2");
            Rational rational1 = new Rational(1, 2);
            Console.WriteLine(rational1);
            Rational rational2 = new Rational(1, 3);
            Console.WriteLine(rational2);
            Rational product = rational1 * rational2;
            Console.WriteLine($"Перемножение {product}");
            Console.WriteLine("Нажмите Enter");
            Console.ReadKey();

            Console.WriteLine("Лабораторная работа Тумаков 12, Домашнее задание 12.1");
            Complex c1 = new Complex(1, 2);
            Complex c2 = new Complex(3, 4);
            Console.WriteLine($"Первое число {c1}");
            Console.WriteLine($"Второе число {c2}");
            Console.WriteLine($"Сложение {c1 + c2}");
            Console.WriteLine($"Умножение {c1 * c2}");
            Console.WriteLine($"Вычитание {c1 - c2}");
            Console.WriteLine($"Равенство {c1 == c2}");
            Console.WriteLine("Нажмите Enter");
            Console.ReadKey();

            Console.WriteLine("Лабораторная работа Тумаков 12, Домашнее задание 12.2");
            List<Book> books = new List<Book>{ new Book("Война и мир", "Лев Толстой", "Эксмо") ,
                new Book("Преступление и наказание", "Фёдор Достоевский", "АСТ"),
                new Book("Гарри Поттер и философский камень", "Джоан Роулинг", "Махаон"),
                new Book("Три мушкетёра", "Александр Дюма", "Эксмо")
            };
            BookCollection bookCollection = new BookCollection(books);
            bookCollection.SortBooks((b1, b2) => b1.Title.CompareTo(b2.Title));
            Console.WriteLine("Нажмите Enter");
            Console.ReadKey();
        }
    }
}

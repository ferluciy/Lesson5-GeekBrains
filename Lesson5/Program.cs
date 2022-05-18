using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GBcool;
using System.Text.RegularExpressions;
using System.IO;

namespace Lesson5
{
    internal class Program
    {
        struct user
        {
            public string FIO;
            public double ball;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Classes.LogoLesson("5");
                Classes.PrintCenter("█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█", ConsoleColor.Green);
                Classes.PrintCenter("█                       ГЛАВНОЕ МЕНЮ                       █", ConsoleColor.Green);
                Classes.PrintCenter("█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█", ConsoleColor.Green);
                Console.WriteLine("");
                Classes.PrintLeft("Задача 1: Проверка корректности пароля", false, ConsoleColor.White);
                Classes.PrintLeft("Задача 2: Разработать статический класс Message", false, ConsoleColor.White);
                Classes.PrintLeft("Задача 3: Метод, определяющий, является ли одна строка перестановкой другой", false, ConsoleColor.White);
                Classes.PrintLeft("Задача 4: Задача ЕГЭ", false, ConsoleColor.White);
                Console.WriteLine("");
                Classes.PrintLeft("Задача 5: Выход", false, ConsoleColor.White);
                Console.WriteLine("");
                Classes.PrintLeft("Какую задачу ты хочешь выполнить: ", true, ConsoleColor.Yellow);
                Classes.PrintLeft("", true, ConsoleColor.Green);

                switch (int.Parse(Console.ReadLine()))
                {
                    case 1:
                        Task1();
                        Console.WriteLine("");
                        Classes.PrintLeft("Для возврата нажми любую клавишу...", false, ConsoleColor.Yellow);
                        Console.ReadKey();
                        break;

                    case 2:
                        Task2();
                        Console.WriteLine("");
                        Classes.PrintLeft("Для возврата нажми любую клавишу...", false, ConsoleColor.Yellow);
                        Console.ReadKey();
                        break;

                    case 3:
                        Task3();
                        Console.WriteLine("");
                        Classes.PrintLeft("Для возврата нажми любую клавишу...", false, ConsoleColor.Yellow);
                        Console.ReadKey();
                        break;

                    case 4:
                        Task4();
                        Console.WriteLine("");
                        Classes.PrintLeft("Для возврата нажми любую клавишу...", false, ConsoleColor.Yellow);
                        Console.ReadKey();
                        break;

                    case 5:
                        return;
                }
            }
        }
        static void Task1()
        {
            Classes.LogoLesson("5");
            Classes.PrintCenter("█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█", ConsoleColor.White);
            Classes.PrintCenter("█             < Проверка корректности пароля >             █", ConsoleColor.White);
            Classes.PrintCenter("█  Корректным логином будет строка от 2 до 10 символов,    █", ConsoleColor.White);
            Classes.PrintCenter("█  содержащая только буквы латинского алфавита или цифры,  █", ConsoleColor.White);
            Classes.PrintCenter("█  при этом цифра не может быть первой                     █", ConsoleColor.White);
            Classes.PrintCenter("█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█", ConsoleColor.White);
            Console.WriteLine("");
            StringBuilder str1 = new StringBuilder();
            Regex regex = new Regex("^[A-Za-z]{1}[A-Za-z0-9]{1,9}$");

            //проверка БЕЗ регулярного выражения
            bool flag = false;
            do {
                Classes.PrintLeft("Введите ваш логин: ", true, ConsoleColor.Yellow);
                Classes.PrintLeft("", true, ConsoleColor.Green);
                str1.Clear();
                str1.Append(Console.ReadLine()); //получаем строку с логином
                if (str1.Length >= 2 && str1.Length <= 10 && !char.IsDigit(str1[0])) //проверяем длину и первый символ
                {
                    for (int i = 0; i < str1.Length; i++) //перебираем все символы логина для проверки соответствия
                    {
                        if ((str1[i] >= 'a' && str1[i] <= 'z') || (str1[i] >= 'A' && str1[i] <= 'Z') || char.IsDigit(str1[i])) flag = true;
                        else
                        {
                            flag = false; //если хотя бы один символ не соответсвует прерываем цикл
                            break;
                        }
                    }
                } 
                if (!flag) Classes.PrintLeft("Логин не соответвует условию! ", false, ConsoleColor.Red);

            } while (!flag); //продолжаем цикл пока логин не будет указан корректно
            Classes.PrintLeft(String.Format($"Логин {str1.ToString()} соответвует условию"), false, ConsoleColor.Green);
            Console.WriteLine("");

            //проверка С помощью регулярного выражения
            Classes.PrintLeft("****** А теперь проверка с помощью регулярного выражения! ******", false, ConsoleColor.Yellow);
            flag = false;
            do
            {
                Classes.PrintLeft("Введите ваш логин: ", true, ConsoleColor.Yellow);
                Classes.PrintLeft("", true, ConsoleColor.Green);
                str1.Clear();
                str1.Append(Console.ReadLine());
                flag = regex.IsMatch(str1.ToString()) ? true : false;
                Console.WriteLine("");
                if (!flag) { Classes.PrintLeft("Логин не соответвует условию! ", false, ConsoleColor.Red); }
            } while (!flag);
            Classes.PrintLeft(String.Format($"Логин {str1.ToString()} соответвует условию"), false, ConsoleColor.Green);
            Console.WriteLine("");
        
        }
        static void Task2()
        {
            Classes.LogoLesson("5");
            Classes.PrintCenter("█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█", ConsoleColor.White);
            Classes.PrintCenter("█           Разработать статический класс Message          █", ConsoleColor.White);
            Classes.PrintCenter("█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█", ConsoleColor.White);
            Console.WriteLine("");
            StringBuilder str1 = new StringBuilder("Слово не воробей, вылетит не поймаешь. Всё не воробей, кроме воробья. ");
            Classes.PrintLeft(str1.ToString(), false, ConsoleColor.Green);
            Console.WriteLine("");
            Classes.PrintLeft("Слова, которые содержает не более 5 букв:", false, ConsoleColor.Yellow);
            Classes.PrintLeft(Message.WordsLength(str1.ToString(), 5).ToString(), false, ConsoleColor.White);
            Console.WriteLine("");
            Classes.PrintLeft("Удалить из сообщения все слова, которые заканчиваются на символ <ь>:", false, ConsoleColor.Yellow);
            Classes.PrintLeft(Message.RemoveWordsLength(str1.ToString(),'ь').ToString(), false, ConsoleColor.White);
            Console.WriteLine("");
            Classes.PrintLeft("Одно самое длинное слово:", false, ConsoleColor.Yellow);
            Classes.PrintLeft(Message.MaxWordLength(str1.ToString()), false, ConsoleColor.White);
            Console.WriteLine("");
            Classes.PrintLeft("Предложение из самых длинных слов:", false, ConsoleColor.Yellow);
            Classes.PrintLeft(Message.MaxWords(str1.ToString()).ToString(), false, ConsoleColor.White);
            Console.WriteLine("");
            Classes.PrintLeft("Частотный анализ:", false, ConsoleColor.Yellow);
            string[] str2 = new string[] { "Воробей", "Слово" };
            Message.ChastotaSlov(str2, str1.ToString());
            Console.WriteLine("");

        }
        static void Task3()
        {
            Classes.LogoLesson("5");
            Classes.PrintCenter("█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█", ConsoleColor.White);
            Classes.PrintCenter("█       Метод, определяющий, является ли одна строка       █", ConsoleColor.White);
            Classes.PrintCenter("█                   перестановкой другой                   █", ConsoleColor.White);
            Classes.PrintCenter("█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█", ConsoleColor.White);
            Console.WriteLine("");
            string str1 = "колобок";
            string str2 = "боколок";
            string str3 = "соколок";
            string str4 = "лобокок";
            Classes.PrintLeft(String.Format($"Строка <{str2}>" + (Message.isPerestanovka(str1, str2) ? " " : " не ") 
                + $"является перестановкой <{str1}>"), false, ConsoleColor.Yellow);
            Classes.PrintLeft(String.Format($"Строка <{str3}>" + (Message.isPerestanovka(str1, str3) ? " " : " не ") 
                + $"является перестановкой <{str1}>"), false, ConsoleColor.Yellow);
            Classes.PrintLeft(String.Format($"Строка <{str4}>" + (Message.isPerestanovka(str1, str4) ? " " : " не ") 
                + $"является перестановкой <{str1}>"), false, ConsoleColor.Yellow);
        }
        static void Task4()
        {
            Classes.LogoLesson("5");
            Classes.PrintCenter("█▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█", ConsoleColor.White);
            Classes.PrintCenter("█                       Задача ЕГЭ                         █", ConsoleColor.White);
            Classes.PrintCenter("█                   Трое худших учеников                   █", ConsoleColor.White);
            Classes.PrintCenter("█▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█", ConsoleColor.White);
            Console.WriteLine("");
            string filename = AppDomain.CurrentDomain.BaseDirectory + "ocenki.txt";
            StreamReader sr = new StreamReader(filename);
            int counter = 0;
            int max = int.Parse(sr.ReadLine()); //берем число из первой строки, в не указано количество учеников по заданию
            string[] strs = new string[5];
            string fio;
            user[] student_list = new user[max];
            user student = new user();

            //получаем список из файла
            while (!sr.EndOfStream)
            {
                strs = sr.ReadLine().Split(' ');
                student.FIO = strs[0]+" "+ strs[1];
                student.ball =  Math.Round(((double.Parse(strs[2]) + double.Parse(strs[3]) + double.Parse(strs[4])) / 3), 1); //округляем до 1 знака после запятой
                student_list[counter] = student;
                counter++;
                if (counter == max) break;
            }
            Classes.PrintLeft("Список и средний балл:", false, ConsoleColor.Yellow);
            for (int i = 0; i < student_list.Length; i++) Classes.PrintLeft((i+1)+") "+ student_list[i].FIO 
                + ": "+ student_list[i].ball, false, ConsoleColor.Yellow);

            //сортируем список по среднему баллу от меньшего к большему
            for (int i = 0; i < student_list.Length; i++)
            {
                for (int j = 0; j < student_list.Length - 1; j++)
                {
                    double b = student_list[j].ball;
                    fio = student_list[j].FIO;
                    if (student_list[j].ball > student_list[j + 1].ball)
                    {
                        student_list[j].ball = student_list[j + 1].ball;
                        student_list[j + 1].ball = b;
                        student_list[j].FIO = student_list[j + 1].FIO;
                        student_list[j + 1].FIO = fio.ToString();
                    }
                }
            }
            Console.WriteLine("");
            Classes.PrintLeft("Худшие:", false, ConsoleColor.Yellow);
            for (int i = 0; i < student_list.Length; i++)
            {
               if (student_list[i].ball <= student_list[2].ball) 
                    Classes.PrintLeft((i + 1) + ") " + student_list[i].FIO + ": " + student_list[i].ball, false, ConsoleColor.Yellow);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Fraction.Hello();
            Fraction.Start();           
        }
    }


    class Fraction
    {

        //Поля и конструктор класса дробей
        #region
        int a;
        int b;

        //В моём решении задания я использую лишь конструктор без параметров
        public Fraction()
        {
            a = 0;
            b = 1;
        }
        #endregion

        //Геттеры и сеттеры для числителя и знаменателя
        #region
        public int A { get; set; } //числитель может быть целым числом
       
        public int B
        {
            get { return b; }
            set
            {
                if (value > 0) b = value; // знаменатель может быть натуральным неотрицательным числом
            }
        }
        #endregion

        //Приветствие
        #region
        public static void Hello()
        {
            Console.ForegroundColor = ConsoleColor.Black; // устанавливаем цвет
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine(" Здравствйте! \n Данная программа поможет Вам выполнить простые операции с дробями. \n Приятного использования!\n", Console.WindowWidth/2);
            Console.ResetColor();
        }
        #endregion

        //Инициализация дробей вводом значений с клавиатуры и выполнение желаемой операции
        #region
        public static void Start()
        {
            //Инициализация первой дроби
            Fraction x1 = new Fraction();
            Console.WriteLine("\nВведите числитель первой дроби:");
            x1.a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите знаменатель первой дроби:");
            x1.b = int.Parse(Console.ReadLine());

            //Инициализация второй дроби
            Fraction x2 = new Fraction();
            Console.WriteLine("Введите числитель второй дроби:");
            x2.a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите знаменатель второй дроби:");
            x2.b = int.Parse(Console.ReadLine());

            //Вызываем меню с доступными операциями
            int operation = OperationNumber();     
            
            //Вызываем методы в соответствии с выбранной операцией       
            if (operation >= 1 && operation <= 4)
            {
                if (operation == 1)
                {
                    x1.Plus(x2);
                }
                else if (operation == 2)
                {
                    x1.Minus(x2);
                }
                else if (operation == 3)
                {
                    x1.Multiple(x2);
                }
                else x1.Division(x2);
            } else OperationNumber(); //повторный вызов меню в случае некорректного ввода

            //Самовызываемся для выполнения последующих операций
            Start();
        }
        #endregion

        //Выбираем номер действия (сложение/вычитание/умножение/деление) через ввод пользователем нужного числа
        #region
        public static int OperationNumber()
        {
            Console.WriteLine("\n Введите номер желаемой операции с дробями и нажмите Enter: \n\n   1. Сложение \n   2. Вычитание \n   3. Умножение \n   4. Деление \n");
            int operation = int.Parse(Console.ReadLine());
            return operation;
        }
        #endregion

        //Сложение
        #region
        public void Plus(Fraction x2)
        {
            Fraction x3 = new Fraction(); //описываем и создаём результирующую дробь

            //сразу пишем начальные значения, пока она не изменились в ходе вычислений,
            //поэтому используем Console.Write вместо .WriteLine
            Console.Write($"\n {ToString()} + {x2.ToString()} = ");

            if (b != x2.b) //проверка на наличие необходимости приводить к общему знаменателю
            {
                //если - да, то перемножаем числители с чужими знаменателями...
                a *= x2.b;
                x2.a *= b;

                //...находим общий знаменатель...
                x2.b *= b; 

                //...и записываем значения в поля результирующей дроби
                x3.a = a + x2.a;
                x3.b = x2.b;
            }
            else
            {
                //если - нет, то сразу записываем значения в поля результирующей дроби
                x3.a = a + x2.a;
                x3.b = x2.b;
            }

            Console.Write(x3.ToString()); //дописываем результат в строку, но всё равно Console.Write на случай,
            ReductionCheck(x3.a, x3.b); // если дробь можно сократить и дописать строчку
        }
        #endregion

        //Вычитание
        #region
        public void Minus(Fraction x2)
        {
            Fraction x3 = new Fraction(); //описываем и создаём результирующую дробь

            //сразу пишем начальные значения, пока она не изменились в ходе вычислений,
            //поэтому используем Console.Write вместо .WriteLine
            Console.Write($"\n {ToString()} - {x2.ToString()} = ");

            if (b != x2.b) //проверка на наличие необходимости приводить к общему знаменателю
            {
                //если - да, то перемножаем числители с чужими знаменателями...
                a *= x2.b;
                x2.a *= b;

                //...находим общий знаменатель...
                x2.b *= b;

                //...и записываем значения в поля результирующей дроби
                x3.a = a - x2.a;
                x3.b = x2.b;
            }
            else
            {
                //если - нет, то сразу записываем значения в поля результирующей дроби
                x3.a = a - x2.a;
                x3.b = x2.b;
            }

            Console.Write(x3.ToString()); //дописываем результат в строку, но всё равно Console.Write на случай,
            ReductionCheck(x3.a, x3.b); // если дробь можно сократить и дописать строчку
        }
        #endregion

        //Умножение
        #region
        public void Multiple(Fraction x2)
        {
            Fraction x3 = new Fraction(); //описываем и создаём результирующую дробь

            //сразу пишем начальные значения, пока она не изменились в ходе вычислений,
            //поэтому используем Console.Write вместо .WriteLine
            Console.Write($"\n {ToString()} * {x2.ToString()} = ");

            //записываем перемноженные числители и перемноженные знаменатели в поля результирующей дроби
                x3.a = a * x2.a;
                x3.b = b * x2.b;

            Console.Write(x3.ToString()); //дописываем результат в строку, но всё равно Console.Write на случай,
            ReductionCheck(x3.a, x3.b); // если дробь можно сократить и дописать строчку
        }
        #endregion

        //Деление
        #region
        public void Division(Fraction x2)
        {
            Fraction x3 = new Fraction(); //описываем и создаём результирующую дробь

            //сразу пишем начальные значения, пока она не изменились в ходе вычислений,
            //поэтому используем Console.Write вместо .WriteLine
            Console.Write($"\n {ToString()} / {x2.ToString()} = ");

            //записываем накрест перемноженные числители и знаменатели в поля результирующей дроби
                x3.a = a * x2.b;
                x3.b = b * x2.a;
            
            Console.Write(x3.ToString()); //дописываем результат в строку, но всё равно Console.Write на случай,
            ReductionCheck( x3.a, x3.b); // если дробь можно сократить и дописать строчку
        }
        #endregion

        //Пауза после выполнения желаемой операции с дробями
        #region
        public static void Pause()
        {
            Console.WriteLine("\nДля выполнения новой операции нажмите `Enter`");
            Console.ReadKey();
        }
        #endregion

        //Сокращатель дроби
        #region
        public void ReductionCheck(int a , int b)
        {
            //В целях оптимизации кода решил использовать пространство имён System.Numerics,
            //а конкретно - метод GreatestCommonDivisor структуры BigInteger, находящий наибольший общий делитель

            //записываем НОД в переменную типа int
            int gcd = (int) BigInteger.GreatestCommonDivisor(a, b);

            //проверяем, равна ли дробь целому числу
                if (a % b == 0)
                {
                //если - да, то дописываем результат в строку
                    Console.WriteLine(" = " + (a / b));
                }
                else
                {
                //если - нет, то проверяем есть ли потенциал для сокращения дроби
                    if (gcd > 1)
                    {
                    //если - да, то сокращаем значения и дописываем результат в строку
                        a = a / gcd;
                        b = b / gcd;
                        Console.WriteLine($" = {a}/{b}");
                    }
                    //если - нет, то значит, дробь некуда сокращать - просто перемещаем курсор в консоли на новую строчку
                    else Console.WriteLine();
                }            
            Pause(); //предлагаем пользователю нажать Enter для продолжения работы в программе
        }
        #endregion

        //Строковой конвертер
        #region
        public string ToString()
        {
            return a + "/" + b;
        }
        #endregion
    }
}

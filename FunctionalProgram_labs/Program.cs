using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;

namespace FunctionalProgram_labs
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            task1_2();
            
        }

        //1.1. Печать через Action<T> 
        public static void task1_1()
        {
            var str = Console.ReadLine();

            Action<string> print = word => { Console.WriteLine(word); };
            string[] words = str.Split(' ');
            foreach (var word in words)
            {
                print(word);
            }
        }
        //1.2.  «Бумажный» релиз  
        public static void task1_2()
        {
            var str = Console.ReadLine();

            Action<string> print = word => { Console.WriteLine($"{word} (нет в наличии)"); };
            foreach (var word in  str.Split(' '))
            {
                print(word);
            }
        }
        //1.3. Минимальное число  
        public static void task1_3()
        {
            string input = Console.ReadLine();
            Func<string, int> parser = n => int.Parse(n);
            int[] numbers = input.Split(new string[] {" "},
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(parser).ToArray();
            Console.WriteLine(numbers.Min());

        }
        //1.4.Четные/Нечетные из диапазона
        public static void task1_4()
        {
            string input = Console.ReadLine();
            Func<string, int> parser = n => int.Parse(n);
            int[] numbers = input.Split(new string[] {" "},
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(parser).ToArray();

            int num1 = numbers[0];
            int num2 = numbers[1];
            string property = Console.ReadLine();
            Func<int, int, string, string> print = (first, second, str) =>
            {
                StringBuilder result = new StringBuilder();

                if (str == "odd")
                {
                    for (int i = first; i <= second; i++)
                    {
                        if (i % 2 == 0)
                        {
                            result.Append(i + " ");
                        }
                    }
                    
                } else if (str == "even"){
                    for (int i = first; i <= second; i++)
                    {
                        if (i % 2 != 0)
                        {
                            result.Append(i + " ");
                        }
                    }
                }
                return result.ToString();
            };
            
            Console.WriteLine(print(num1,num2,property));
        }
        //2.1 Арифметические операции 
        public static void task2_1()
        {
            string input = Console.ReadLine();
            Func<string, int> parser = n => int.Parse(n);
            int[] numbers = input.Split(new string[] {" "},
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(parser).ToArray();

            Action<int[]> add = num => { for(int i =0; i <num.Length; i++)
            {
                num[i] += 1;
            } };
            Action<int[]> print = num => { 
                for(int i =0; i <num.Length; i++){
                    Console.Write($"{num[i]} ");
                }
                Console.WriteLine();
            };
            Action<int[]> multiply = num => { for(int i =0; i <num.Length; i++)
            {
                num[i] *= 2;
            } };
            Action<int[]> subtract = num => { for(int i =0; i <num.Length; i++)
            {
                num[i] -= 1;
            } };


            Func<string, Action<int[]>> choice = condition =>
            {
                switch (condition)
                {
                    case "add": return add;
                    case "print": return print;
                    case "multiply": return multiply;
                    case "subtract": return subtract;
                    default: return null;
                }
            };
            
            string operation = Console.ReadLine();
            while (operation != "end")
            {
                choice(operation)(numbers);
                operation = Console.ReadLine();
            }
        }
        //2.2. Реверсирование 
        public static void task2_2()
        {
            int[] numbers = Console.ReadLine()
                .Split(new string[] {" "},
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();
            int divider = Convert.ToInt32(Console.ReadLine());
            
            Func<int[], int, List<int>> reverse = (arr, n) =>
            {
                
                List<int> result = new List<int>();
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i] % n != 0)
                    {
                        result.Add(arr[i]);
                    }
                }
                result.Reverse();
                foreach (var i in result)
                {
                    Console.Write($"{i} ");
                }
                return result;
            };
            reverse(numbers, divider);
        }
        //2.3. Фильтрация имен
        public static void task2_3()
        {
            int length = Convert.ToInt32(Console.ReadLine());
            string[] names = Console.ReadLine().Split(' ').ToArray();


            Func<string[], int, List<string>> filter = (arr, n) =>
            {
                List<string> result = new List<string>();
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[i].Length <= n)
                    {
                        result.Add(arr[i]);
                    }
                }
                return result;
            };
            Action<List<string>> print = filteredNames => Console.WriteLine(string.Join(" ", filteredNames));
            print(filter(names, length));

        }
        
        //2.4. Компаратор
        public static void task2_4()
        {
            var comparer = Comparer<int>.Create((num1, num2) =>
            {
                var even1 = num1 % 2 == 0;
                var even2 = num2 % 2 == 0;
                if (even1 && !even2)
                    return -1;
                if (!even1 && even2)
                    return +1;
                
                return -num2.CompareTo(num1);
            });
            int[] numbers = Console.ReadLine()
                .Split(new string[] {" "},
                    StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();
            Array.Sort(numbers, comparer);
            string result = string.Join(" ", numbers);
            Console.WriteLine(result);
        }
       
    }
}
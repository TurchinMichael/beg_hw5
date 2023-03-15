using System;

namespace HW5
{
    class Program
    {
        static void Main(string[] args)
        {
            #region задаем массив из случайных положительных трехзначных чисел и показываем количество четных чисел в массиве
            int[] array = CreateRandomIntArray(printInputInt("Введите размер массива для генерации случайных, трехзначных чисел"), 100, 999);
            print($"Был создан массив:\n{string.Join(", ", array)}");// IntArrayToString(array, ", ")}");
            print($"Количество четных чисел в массиве:\n{QuantityEvenInIntArray(array)}");
            #endregion

            #region одномерный массив со случайными числами, найти в этом массиве сумму элементов, стоящих на нечетных позициях
            print($"Сумма элементов, находящихся на нечетных позициях заданного массива равна:\n{SumNotEvenPositionsInIntArray(array)}");
            #endregion

            #region массив вещественных чисел, найти разницу между максимальным и минимальным элементом массива
            double[] arrayDouble = CreateRandomDoubleArray(printInputInt("\nВведите размер массива для генерации случайных, вещественных, трехзначных (до запятой) чисел"), 100, 999);
            print($"Был создан массив:\n{string.Join(", ", arrayDouble)}");
            print($"разница между максимальным и минимальным элементом массива\n{DifferenceBetweenMinMaxNumbersInDoubleArray(arrayDouble)}");
            #endregion
        }

        /// <summary>
        /// удобство вывода без лишнего текста
        /// </summary>
        /// <param name="mes">текст для вывода в консоль</param>
        static void print(string mes)
        {
            Console.WriteLine(mes);
        }

        /// </summary>
        /// отображение сообщения, прием из консоли значения, перевод полученного значения в число
        /// <param name="mes">сообщение перед запросом числа</param>
        /// <returns>число, введенное пользователем в консоли</returns>
        static int printInputInt(string mes)
        {
            Console.WriteLine(mes);
            int.TryParse(Console.ReadLine(), out int userNumber);
            return userNumber;
        }

        /// <summary>
        /// Создание массива случайных, целых чисел
        /// </summary>
        /// <param name="size">размер массива</param>
        /// <param name="min">минимальное число для случайного разброса</param>
        /// <param name="max">максимальное число для случайного разброса</param>
        /// <returns>массив случайных, целых чисел</returns>
        static int[] CreateRandomIntArray (int size, int min, int max) //[min, max] включительно
        {
            int[] arr = new int[size];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] += new Random().Next(min, max + 1); // Next[min, max)
            }

            return arr;
        }

        /// <summary>
        /// Создание массива случайных, вещественных чисел
        /// </summary>
        /// <param name="size">размер массива</param>
        /// <param name="min">минимальное число для случайного разброса</param>
        /// <param name="max">максимальное число для случайного разброса</param>
        /// <returns>массив случайных, вещественных чисел</returns>
        static double[] CreateRandomDoubleArray(int size, double min, double max) //[min, max] включительно
        {
            double[] arr = new double[size];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] += new Random().NextDouble() * (max - min) + min; // Next[min, max)
            }
            return arr;
        }

        /// <summary>
        /// Рассчет количества всех четных чисел в массиве целых чисел
        /// </summary>
        /// <param name="arr">массив целых чисел</param>
        /// <returns>количество всех четных чисел в массиве целых чисел</returns>
        static int QuantityEvenInIntArray (int [] arr)
        {
            int tempCount = 0;

            foreach (var item in arr)
            {
                tempCount += item % 2 == 0 ? 1 : 0;
            }
            return tempCount;
        }

        /// <summary>
        /// Сумма всех чисел массива, стоящих на нечетных позициях
        /// </summary>
        /// <param name="arr">массив целых чисел</param>
        /// <returns>Сумма всех чисел массива, стоящих на нечетных позициях</returns>
        static int SumNotEvenPositionsInIntArray(int[] arr)
        {
            int tempSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                tempSum += i % 2 == 0 ? arr[i] : 0;
            }
            return tempSum;
        }

        /// <summary>
        /// Нахождение разницы между максимальным и минимальным значением вещественного массива
        /// </summary>
        /// <param name="array">вещественный массив</param>
        /// <returns>разница между максимальным и минимальным значением вещественного массива</returns>
        static double DifferenceBetweenMinMaxNumbersInDoubleArray (double[] array)
        {
            double min = array[0], max = array[0];

            foreach (var item in array)
            {
                min = item < min ? item : min;
                max = item > max ? item : max;
            }
            return max - min;
        }
    }
}
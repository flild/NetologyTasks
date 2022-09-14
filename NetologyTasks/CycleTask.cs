using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NetologyTasks
{
    public class CycleTask
    {
        /// <summary>
        /// Переворачивает целое число 123 --> 321
        /// </summary>
        /// <param name="numberToReverse">целое число</param>
        /// <returns>Целое перевернутое число</returns>
        public int CycleWhile(int numberToReverse)
        {
            int reverseNumber = 0;
            while(numberToReverse > 0)
            {
                reverseNumber = reverseNumber*10 + numberToReverse % 10;
                numberToReverse /= 10;
            }
            return reverseNumber;
        }

        /// <summary>
        /// Вычисляет 3 степени числа квадра, куб и **4, и выводит в консоль
        /// Внутри используется функция Math, пожтому работает только с типом double
        /// </summary>
        /// <param name="number">Число для которого вычислять степени</param>
        /// <returns>tuple вида (**2,**3,**4) где все значения double</returns>
        public Tuple<double, double, double> CycleFor(double number)
        {
            for (double power =2;power<5;power++)
            {
                Console.WriteLine(Math.Pow(number, power));
            }
            return Tuple.Create(Math.Pow(number,2), Math.Pow(number, 3), Math.Pow(number, 4));
        }
    }
}
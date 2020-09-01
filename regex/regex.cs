using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Regex_3
{

    class Regex_3

    {
        static void Main()
        {
            char* buffer = Buffer;
            string input = new string(buffer);

            string pattern = @"\b(\d+\W?руб)";
            Regex regex = new Regex(pattern);

            // Получаем совпадения в экземпляре класса Match
            Match match = regex.Match(input);

            // отображаем все совпадения
            while (match.Success)
            {
                // Т.к. мы выделили в шаблоне одну группу (одни круглые скобки),
                // ссылаемся на найденное значение через свойство Groups класса Match
                Console.WriteLine(match.Groups[1].Value);

                // Переходим к следующему совпадению
                match = match.NextMatch();
            }
        }
    }
}
// using System;
//using System.Text.RegularExpressions;

//class Example
//{
//static void Main()
//  {
// Допустим в исходной строке нужно найти все числа,
// соответствующие стоимости продукта
//string input = "СекцияДокумент=Платежное поручение" +
//"Дата=07.12.2010" +
//"Номер=6" +
//"Сумма=100.00" +
//"ПлательщикСчет=40802810740000000001" +
// "ДатаСписано=08.12.2010" +
// "Плательщик=ИНН 644914186741/0  ИП Иванов И. И." +
//"Плательщик1=ИП Иванов И. И. " +
// "Плательщик2=40802810740000040746" +
// "Плательщик3=Ф. ЗАО АКБ В Г.ЭНГЕЛЬСПлательщик4=Г. ЭНГЕЛЬС";

// Regex regex = new Regex("Дата", RegexOptions.IgnoreCase);

// Получаем совпадения в экземпляре класса Match
// Match match = regex.Match(input);

// отображаем все совпадения
// while (match.Success)
//  {
// Т.к. мы выделили в шаблоне одну группу (одни круглые скобки),
// ссылаемся на найденное значение через свойство Groups класса Match
// Console.WriteLine(match.Groups[1].Value);

// Переходим к следующему совпадению
// match = match.NextMatch();
// }
//  Console.WriteLine();
//  }

//
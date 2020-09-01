using System;
using System.IO;

using System.Text;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
namespace streamreader
{
    internal class Streamreader
    {

        static string GetFileText()
        {           
            FileStream stream = new FileStream("kl_to_1c_TEST.txt", FileMode.Open);
            StreamReader reader = new StreamReader(stream, Encoding.Default, true);
            string str = reader.ReadToEnd();
            stream.Close();

            return str;
        }

        static void Main()
        {

            string input = GetFileText();
            
            var Numberlist = Regex.Matches(input, "Дата=(.*)");
            var Datalist = Regex.Matches(input, "Номер=(.*)");
            var Sumlist = Regex.Matches(input, "Сумма=(.*)");


     
            // строка подключения к БД
            string connStr = "server=localhost;user=root;database=people;password=0000;";
            // создаём объект для подключения к БД
            MySqlConnection conn = new MySqlConnection(connStr);
            // устанавливаем соединение с БД
            conn.Open();
            // запрос
            for (var i = 0; i < Numberlist.Count; i++)
            {

                Console.WriteLine(Numberlist[i].Groups[1].Value);
                Console.WriteLine(Datalist[i].Groups[1].Value);
                Console.WriteLine(Sumlist[i].Groups[1].Value);

                string sql = $"INSERT INTO 'название таблицы' VALUES ({Numberlist[i].Groups[1].Value},{Datalist[i].Groups[1].Value},{Sumlist[i].Groups[1].Value});";
                // объект для выполнения SQL-запроса
                MySqlCommand command = new MySqlCommand(sql, conn);
                // выполняем запрос и получаем ответ
                string name = command.ExecuteScalar().ToString();
            }
            
            // закрываем соединение с БД
            conn.Close();

            while (true) ;
        }

    }
}

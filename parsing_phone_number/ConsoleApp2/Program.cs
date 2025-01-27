using System;
using System.Text;

class Program
{
    static void Main()
    {
        string input;
        char[] numbers = new char[12];
        int digitCount = 0;
        while (true)
        {
                Console.Write("\nДля завершения введите \'q\' \nВведите строку: ");
            input = Console.ReadLine();
            digitCount = 0;
                foreach (char c in input)
                {
                    if (c == 'q')
                    {
                        return;
                    }
                    if (Char.IsDigit(c))
                    {
                        numbers[digitCount++] = c;
                        if (digitCount == 11)
                            break;
                    }
                }
                if (digitCount < 11)
                {
                    Console.WriteLine("Не хватает цифр, попробуйте еще раз");
                    break;
                }

            string number = $"+{numbers[0]}({numbers[1]}{numbers[2]}{numbers[3]}){numbers[4]}{numbers[5]}{numbers[6]}-{numbers[7]}{numbers[8]}-{numbers[9]}{numbers[10]}{numbers[11]}\n";

            try
            {
                using (StreamWriter writer = new StreamWriter("numbers.txt", true, Encoding.UTF8))
                {
                    writer.Write(number);
                }
                Console.WriteLine("Номер успешно записана в файл!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при записи в файл: {ex.Message}");
            }
        }
    }
}
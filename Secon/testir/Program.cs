using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Security.Policy;

namespace testir
{
    public class Under : Exception
    {
        public Under(string message) : base(message)
        {
        }
    }
     
    
    public class NotANumber : Exception
    {
        public NotANumber(string message) : base(message) { }
    }

    public class NotAFile: Exception
    {
        public NotAFile(string message) : base(message) { }    
    }
    internal class Program
    {   
        
        static void Main(string[] args)
        {
            Console.WriteLine("Решение квадратного уравнения");
            
            try
            {
                
                string path = @"C:\уравнение.txt";

                if(File.Exists(path))
                {
                    string str = File.ReadAllText(path);
                    string[] arr = str.Split(' ');

                    int a;
                    int b;
                    int c;
                    if ((int.TryParse(arr[0], out a))&& (int.TryParse(arr[1], out b)) && (int.TryParse(arr[2], out c)))
                    {

                    }
                    else
                    {
                        throw new NotANumber("Введенные данные  не являются числом");
                    }
                    
                    


                    Console.WriteLine("Введенные данные: " + arr[0] + " " + arr[1] + " " + arr[2]);
                    Console.Write("Полученное уравнение: ");
                    Console.WriteLine($"{a}x^2+{b}x+{c}=0");
                    int d = b * b - 4 * a * c;
                    Console.Write("Ответ:");
                    if (d > 0)
                    {
                        double x1 = (-b + Math.Sqrt(d)) / (2 * a);
                        double x2 = (-b - Math.Sqrt(d)) / (2 * a);
                        Console.WriteLine($"x1={x1} x2={x2}");
                    }
                    else if (d == 0)
                    {
                        double x1 = (-b) / (2 * a);
                        Console.WriteLine(x1);
                    }
                    else { throw new Under("Дискриминант меньше нуля"); }                   

                }
                else
                {
                    
                    throw new NotAFile("Файл не найден");
                }
                
                
                
            }
            catch (System.DivideByZeroException e)
            {
                Console.WriteLine($"Деление на ноль! Исключение {e}");
            }
            catch (Under ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message  }") ;
            }
            
            catch(NotANumber ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            catch(NotAFile ex)
            {
                Console.WriteLine ($"Ошибка:{ex.Message}" );
            }
            
            finally
            {
                Console.WriteLine("Завершение программы");
            }
            Console.ReadLine();

        }
    }
}

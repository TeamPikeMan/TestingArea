using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Problem08
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger a = BigInteger.Parse(Console.ReadLine());
            BigInteger b = BigInteger.Parse(Console.ReadLine());

            int[] s = AddAsArrays(ConvertToArray(a), ConvertToArray(b));
            
        }

        static public int[] ConvertToArray(BigInteger n)
        {
            string number = n.ToString();
            char[] temp = number.ToCharArray();
            int[] digits = new int[temp.Count()];
            for (int i = 0; i < digits.Count(); i++)
            {
                digits[i] = int.Parse(temp[i].ToString());
            }
            return digits;

        }

        static public int[] AddAsArrays(int[] a, int[] b)
        {
            int[] result = new int[10000];
            int[] temp1 = new int[10000];
            int[] temp2 = new int[10000];
            Array.Copy(a, 0, temp1, temp1.Count() - a.Count(), a.Count());
            Array.Copy(b, 0, temp2, temp2.Count() - b.Count(), b.Count());

            string number = string.Empty;

            for (int i = 0; i <= result.Count()-2; i++)
            {
                if (i == result.Count() - 2)
                {
                    result[i+1] += (temp1[i+1] + temp1[i+1]) % 10;
                    if (result[i] > 10)
                    {
                        Console.WriteLine("Numbers too big");
                        break;
                    }
                }
                else
                {
                    result[i] += (temp1[i] + temp1[i]) % 10;
                    result[i + 1] += (a[i] + b[i]) / 10;
                }
                
            }

            for (int i = result.Count()-1; i >=0; i--)
            {
                number += a[i].ToString();
            }

            Console.WriteLine(BigInteger.Parse(number));
            return result;
        }

    
    }
}

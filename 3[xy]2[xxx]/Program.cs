using System;
using System.Collections.Generic;

namespace _3_xy_2_xxx_
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "3[xy2[xyz]]2[zz3[y]]2[yyxy]5[x2]";
            Console.WriteLine(SomeFunc(str));

        }
        static string SomeFunc(string str)
        {
            List<int> startArr = new List<int>();
            List<int> endArr = new List<int>();
            SetStartEnd(str, ref startArr, ref endArr);
            while (startArr.Count != 0) 
                str = SomeMethod(str, ref startArr, ref endArr, 0, 0);            
            return str;
        }
        static string SomeMethod(string str, ref List<int> startArr, ref List<int> endArr, int i, int end)
        {
            if (startArr.Count != i + 1)
                if (startArr[i + 1] < endArr[end])
                    str = SomeMethod(str, ref startArr, ref endArr, i + 1, end);
                else
                    Calculation(ref str, ref startArr, ref endArr, i, end);
            else
                Calculation(ref str, ref startArr, ref endArr, i, end);
            return str;
        }
        static void SetStartEnd(string str, ref List<int> startArr, ref List<int> endArr)
        {
            for (int j = 0; j < str.Length; j++)
            {
                if (str[j] == '[')
                    startArr.Add(j);
                if (str[j] == ']')
                    endArr.Add(j);
            }
        }
        static void Calculation(ref string str, ref List<int> startArr, ref List<int> endArr, int i, int end)
        {
            string result = "";
            for (int k = 1; k < endArr[end]; k++)
            {
                if (str[startArr[i] + k] == ']')
                {
                    end = startArr[i] + k;
                    break;
                }
            }
            for (int j = 0; j < Convert.ToInt32($"{str[startArr[i] - 1]}"); j++)
            {
                result += str.Substring(startArr[i] + 1, end - startArr[i] - 1);
            }

            str = str.Remove(startArr[i] - 1, end - startArr[i] + 2);
            str = str.Insert(startArr[i] - 1, result);
            startArr = new List<int>();
            endArr = new List<int>();
            SetStartEnd(str, ref startArr, ref endArr);
        }
    }
}

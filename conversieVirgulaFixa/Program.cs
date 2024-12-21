using System;
using System.Text;

class Program
{
    static void Main()

    {
        #region inputParsing
        Console.WriteLine("Introdu numarul,cu partea zecimala(daca are):");

        string numar = Console.ReadLine();

        Console.WriteLine("Introdu baza numarului:");

        int b1 = int.Parse(Console.ReadLine());

        Console.WriteLine("Introdu baza in care vrei sa transformi numarul:");

        int b2 = int.Parse(Console.ReadLine());

        char[] sep = { (','), ('.') };
        string[] partiNumar = numar.Split(sep);

        #endregion

        #region b1ToB10

        long numarB10Intreg = 0;
        long p = 1;

        for (int i = partiNumar[0].Length - 1; i >= 0; i--)
        {
            if ((char)partiNumar[0][i] > '9')
                numarB10Intreg += (char)(partiNumar[0][i] - 'A' + 10) * p;
            else
                numarB10Intreg += long.Parse(partiNumar[0][i].ToString()) * p;
            p *= b1;

        }

        double numarB10Zecimal = 0;

        if (partiNumar.Length > 1)
        {
            for (int i = 0; i < partiNumar[1].Length; i++)
            {
                if ((char)partiNumar[1][i] > '9')
                    numarB10Zecimal += (char)(partiNumar[1][i] - 'A' + 10) / Math.Pow(b1, i + 1);
                else
                    numarB10Zecimal += long.Parse(partiNumar[1][i].ToString()) / Math.Pow(b1, i + 1);

            }
        }
        #endregion

        if (b2 == 10)
            Console.WriteLine(numarB10Intreg + numarB10Zecimal);
        else
        #region b10ToB2
        if (b2 >= 2 && b2 <= 16)
        {
            Stack<char> chars = new Stack<char>();

            while (numarB10Intreg > 0)
            {
                if (numarB10Intreg % b2 < 10)
                    chars.Push((char)('0' + numarB10Intreg % b2));
                else
                    chars.Push((char)('A' + numarB10Intreg % b2 - 10));
                numarB10Intreg /= b2;

            }

            StringBuilder sbZec = new StringBuilder();

            while (numarB10Zecimal - Math.Truncate(numarB10Zecimal) != 0)
            {
                numarB10Zecimal *= b2;
                if (Math.Truncate(numarB10Zecimal) != 0)
                {
                    sbZec.Append(Math.Truncate(numarB10Zecimal));
                    numarB10Zecimal -= Math.Truncate(numarB10Zecimal);
                }
                else
                    sbZec.Append(0);
            }

            string numarB2Intreg = new string(chars.ToArray());
            string numarB2;

            if (partiNumar.Length > 1)
            {
                string numarB2Zecimal = new string(sbZec.ToString());
                numarB2 = ($"{numarB2Intreg},{numarB2Zecimal}");
            }
            else
            {
                numarB2 = numarB2Intreg;
            }

            Console.WriteLine(numarB2);
        }
        else
            Console.WriteLine($"Baza {b2} nu este intre 2 si 16.");
        #endregion

    }
}

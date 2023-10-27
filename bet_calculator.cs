using System;

public class Program
{
    public static void Main()
    {
        int matchcount = 0;
        int maximumGoal = 0;
        int betprice = 0;

        float totalRevenue = 0;

        Console.WriteLine("Please enter your match count: ");
        matchcount = int.Parse(Console.ReadLine());

        Console.WriteLine("Please enter your maximum goal expectation: ");
        maximumGoal = int.Parse(Console.ReadLine());

        Console.WriteLine("Please enter your bet price: ");
        betprice = int.Parse(Console.ReadLine());

        int chances = (int)Math.Pow(maximumGoal + 1, 2);
        int totalChance = (int)Math.Pow(chances, matchcount);

        float[,] rates = new float[matchcount, chances];

        float totalratio = 0;

        int positiveRevenue = 0;

        for (int z = 0; z < matchcount; z++)
        {
            Console.WriteLine("--------------------");
            Console.WriteLine($"{z + 1} Match Rates");
            Console.WriteLine("--------------------");
            for (int i = 0; i < chances; i++)
            {
                Console.WriteLine($"Please enter {i + 1}. rate: ");
                rates[z, i] = float.Parse(Console.ReadLine());
            }
        }

        float multiplier = 1;


        for (int i = 0; i < totalChance; i++)
        {
            for (int c = 0; c < matchcount; c++)
            {
                multiplier *= rates[c, i % chances];
            }

            totalRevenue += multiplier * betprice;

            if (multiplier > totalChance)
            {
                positiveRevenue++;
            }

            multiplier = 1;
        }



        Console.WriteLine($"Your total investment is: {totalChance * betprice}");
        Console.WriteLine($"Your gross revenue is: {totalRevenue}");
        Console.WriteLine($"Your average income is: {totalRevenue / totalChance}");
        Console.WriteLine($"Your win chance is: {((float)positiveRevenue / totalChance) * 100}");
    }
}
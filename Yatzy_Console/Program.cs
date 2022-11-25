using System.Runtime.InteropServices;

namespace Yatzy_Console
{
    internal class Program
    {
        public class Dice
        {
           public List<Dice> diceList = new List<Dice>();
           public int dieNum;
            public string dieName;
            public bool holdDice = false;

            public Dice(string dieName)
            {
                this.dieName = dieName;
            }
        }
        static void Main(string[] args)
        {
            Random random = new Random();
            List<Dice> dices = new List<Dice>();
            Dice die1 = new Dice("D1");
            Dice die2 = new Dice("D2");
            Dice die3 = new Dice("D3");
            Dice die4 = new Dice("D4");
            Dice die5 = new Dice("D5");

            dices.Add(die1);
            dices.Add(die2);
            dices.Add(die3);
            dices.Add(die4);
            dices.Add(die5);
            
            bool play = true;
            int rollCount = 0;
            bool ask = true;
            ConsoleKey key;

            do
            {
                Console.Write(">");
                key = Console.ReadKey(true).Key;
                //string command = Console.ReadLine();
                if(key == ConsoleKey.Escape)
                {
                    Console.WriteLine($"\nhejdå!");
                    play = false;
                }
                else if(key == ConsoleKey.R)
                {
                    rollCount++;
                    int index = 0;
                    foreach(Dice dice in dices)
                    {
                        if(dice.holdDice == false)
                        dice.dieNum = random.Next(1, 7);
                        index++;
                        Console.Write($"|{dice.dieName}: { dice.dieNum}| ");
                    }
                    Console.WriteLine();
                    Console.WriteLine("Write 'hold /dice/' to hold onto a dice or write 'done' to continue rolling");
                    while (ask == true)
                    {
                        key = Console.ReadKey(true).Key;
                        if (key == ConsoleKey.NumPad1)
                        {
                            die1.holdDice = true;
                            Console.WriteLine($"Dice {die1.dieName} is now held");
                        }
                        else if (key == ConsoleKey.NumPad2)
                        {
                            die2.holdDice = true;
                            Console.WriteLine($"Dice {die2.dieName} is now held");
                        }
                        else if (key == ConsoleKey.NumPad3)
                        {
                            die3.holdDice = true;
                            Console.WriteLine($"Dice {die3.dieName} is now held");
                        }
                        else if (key == ConsoleKey.NumPad4)
                        {
                            die4.holdDice = true;
                            Console.WriteLine($"Dice {die4.dieName} is now held");
                        }
                        else if (key == ConsoleKey.NumPad5)
                        {
                            die5.holdDice = true;
                            Console.WriteLine($"Dice {die5.dieName} is now held");
                        }
                        else if (key == ConsoleKey.Spacebar)
                        {
                            ask = false;
                        }
                    }
                    ask = true;
                    if(rollCount == 3)
                    {
                        int summa = die1.dieNum + die2.dieNum + die3.dieNum + die4.dieNum + die5.dieNum;
                        Console.WriteLine($"Summa: {summa}");
                    }
                }
                else if(key == ConsoleKey.End)
                {
                    Console.Clear();
                    foreach(Dice dice in dices)
                    {
                        dice.holdDice = false;
                    }
                }
            }while(play);

            

        }
    }
}
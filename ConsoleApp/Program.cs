using System;
using System.Collections.Generic;
using System.Linq;

namespace Game21
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            Player player = new Player();
            Bot bot = new Bot();

            var cardSuit = game.GetCardPack();

            bool isPlayerPlay = true;
            bool isBotPlay = true;

            int counter = 0;

            do
            {
                if (isBotPlay)
                {
                    isBotPlay = game.DrawCard(bot, cardSuit, counter);
                    counter++;
                }

                if (isPlayerPlay)
                {
                    isPlayerPlay = game.DrawCard(player, cardSuit, counter);
                    counter++;
                }
            } while (isPlayerPlay || isBotPlay);

            // Определить победителя
            PrintResultDelegate printResult = null;

            if (player._score > 21)
            {
                if (bot._score <= 21)
                {
                    printResult = PrintWinnerBot;
                }
                else
                {
                    printResult = PrintDraw;
                }
            }
            else if (bot._score > 21)
            {
                if (player._score <= 21)
                {
                    printResult = PrintWinnerPlayer;
                }
                else
                {
                    printResult = PrintDraw;
                }
            }
            else if (player._score > bot._score)
            {
                printResult = PrintWinnerPlayer;
            }
            else if (player._score < bot._score)
            {
                printResult = PrintWinnerBot;
            }
            else if (player._score == bot._score)
            {
                printResult = PrintDraw;
            }

            PrintScores(player, bot);
            printResult();
        }



        private static void PrintScores(params IPlayer[] player)
        {
            Console.WriteLine("=== Scores ===");
            Console.WriteLine("Player |\tBot");
            for (int y = 0; y < 1; y++)
            {
                for (int x = 0; x < 1; x++)
                {
                    Console.Write($"{player[0]._score} |\t{player[1]._score}");
                }
                Console.WriteLine();
            }
        }

        private delegate void PrintResultDelegate();

        private static void PrintWinnerBot()
        {
            Console.WriteLine("Вы проиграли! Победил бот!");
        }

        private static void PrintWinnerPlayer()
        {
            Console.WriteLine("Вы победили!");
        }

        private static void PrintDraw()
        {
            Console.WriteLine("Никто не победил!");
        }
    }
}

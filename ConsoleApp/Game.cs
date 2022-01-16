using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game21
{
    public class Game
    {
        // Связанное с вытягиванием карт
        public bool DrawCard(IPlayer player, List<int> cardSuit, int counter)
        {
            Random random = new Random();
            char decide = ' ';

            if (player.GetType() == typeof(Bot))
            {
                if (player._score <= random.Next(15, 22))
                {
                    player._score += cardSuit[counter];
                }
                else
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine($"Ваше количество очков: {player._score} |\tБрать карту(y, n): ");

                    string inputDecide = Console.ReadLine();

                    if (inputDecide.Length > 1)
                    {
                        throw new GameException("Длина вводимого выбора не может быть больше 1 символа");
                    }
                    else
                    {
                        decide = char.Parse(inputDecide);
                    }
                    
                }
                catch (GameException ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }
                

                switch (decide)
                {
                    case 'y':
                    case 'Y':
                        player._score += cardSuit[counter];
                        break;

                    case 'n':
                    case 'N':
                    default:
                        return false;
                }
            }

            return true;
        }


        // Связанное с картами
        public List<int> GetCardPack()
        {
            List<int> cardSuit = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                var cards = Enumerable.Range(1, 11).ToList();
                cardSuit.InsertRange(cardSuit.Count, cards);
            }

            return Shuffle(cardSuit);
        }

        private List<int> Shuffle(List<int> cardSuit)
        {
            List<int> ShuffledCards = new List<int>();
            List<int> usedIndexes = new List<int>();
            Random random = new Random();

            for (int i = 0; i < cardSuit.Count; i++)
            {
                int index;

                do
                {
                    index = random.Next(0, cardSuit.Count);
                } while (usedIndexes.Contains(index)); // Проверяет, есть ли такой индекс в списке

                usedIndexes.Add(index);
                ShuffledCards.Add(cardSuit[index]);
            }

            return ShuffledCards;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.Cards
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] deck = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            List<Card> validCards = new List<Card>();

            foreach (var card in deck)
            {
                string cardFace = card.Split()[0];
                string cardSuit = card.Split()[1];

                try
                {
                    Card currCard = new Card(cardFace, cardSuit);

                    validCards.Add(currCard);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine(string.Join(" ", validCards));
        }
    }

    public class Card
    {
        private readonly string[] validCardFaces = new string[13]
        {
            "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"
        };
        private readonly string[] validCardSuits = new string[4]
        {
            "S", "H", "D", "C"
        };

        private string cardFace;
        private string cardSuit;

        public Card(string cardFace, string cardSuit)
        {
            this.CardFace = cardFace;
            this.CardSuit = cardSuit;
        }

        public string CardFace
        {
            get { return cardFace; }
            set
            {
                if (!validCardFaces.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                cardFace = value;
            }
        }
        public string CardSuit
        {
            get { return cardSuit; }
            set
            {
                if (!validCardSuits.Contains(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                cardSuit = value;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            switch (this.CardSuit)
            {
                case "S":
                    sb.AppendLine($"[{this.CardFace}\u2660]");
                    break;
                case "H":
                    sb.AppendLine($"[{this.CardFace}\u2665]");
                    break;
                case "D":
                    sb.AppendLine($"[{this.CardFace}\u2666]");
                    break;
                case "C":
                    sb.AppendLine($"[{this.CardFace}\u2663]");
                    break;
            }

            return sb.ToString().TrimEnd();
        }
    }
}

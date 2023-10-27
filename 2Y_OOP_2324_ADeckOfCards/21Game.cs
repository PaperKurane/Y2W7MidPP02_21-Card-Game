using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class _21Game
    {
        private int[] handValues = new int[2]; 
        
        public _21Game()
        {
            DeckOfCards doc = new DeckOfCards(true);
            //Card draw = doc.drawACard();
            //Console.WriteLine("Drawing a card");
            //Console.WriteLine($"The Card is the {draw.GetCardFace()} of {draw.GetCardSuit()} with a value of {draw.GetCardValue()}");
            ////doc.DisplayDeck();

            List<Card> hand = new List<Card>();
            hand = doc.drawACard(2);
            Console.WriteLine("\nYour Hand: ");
            foreach (Card c in hand)
            {
                Console.WriteLine($"{c.GetCardValue()} - The {c.GetCardFace()} of {c.GetCardSuit()}");
                handValues[0] = handValues[0] + c.GetCardValue();
            }
            Console.WriteLine($"\nHand Value: {handValues[0]}");

            Console.ReadKey();
        }
    }
}

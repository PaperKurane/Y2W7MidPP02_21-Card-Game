using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class _21Game
    {
        private int[] handValues = new int[2]; // Index 0 is dealer's value, 1 for the player
        private bool playerTurn = true;
        
        public _21Game()
        {
            GameStart();

            Console.ReadKey();
        }

        public void GameStart()
        {
            DeckOfCards doc = new DeckOfCards(true);
            List<Card> playerHand = new List<Card>();
            List<Card> dealerHand = new List<Card>();

            //Card draw = doc.drawACard();
            //Console.WriteLine("Drawing a card");
            //Console.WriteLine($"The Card is the {draw.GetCardFace()} of {draw.GetCardSuit()} with a value of {draw.GetCardValue()}");
            //doc.DisplayDeck();

            playerHand = doc.drawACard(2);
            dealerHand = doc.drawACard(2);

            showHand(dealerHand);
            playerTurn = !playerTurn;
            showHand(playerHand);
            playerTurn = !playerTurn;


            while (true)
            {
                if (playerTurn)
                {
                }
                else
                {
                }

                Console.ReadKey();
            }
        }

        public void showHand(List<Card> eitherHand)
        {
            List<Card> hand = eitherHand;

            if (playerTurn == false)
            {
                Console.WriteLine("\nYour Hand: ");

                foreach (Card c in hand)
                {
                    Console.WriteLine($"{c.GetCardValue()} - The {c.GetCardFace()} of {c.GetCardSuit()}");
                    handValues[1] = handValues[1] + c.GetCardValue();
                }
                Console.WriteLine($"\nHand Value: {handValues[1]}");
            }
            else
            {
                Console.WriteLine("\n\nDealer's Hand: ");

                foreach (Card c in hand)
                {
                    Console.WriteLine($"{c.GetCardValue()} - The {c.GetCardFace()} of {c.GetCardSuit()}");
                    handValues[0] = handValues[0] + c.GetCardValue();
                }
                Console.WriteLine($"\nHand Value: {handValues[0]}");
            }
        }
    }
}

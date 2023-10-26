﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Startup();

            Console.ReadKey();
        }

        static void Startup()
        {
            Console.WriteLine("Welcome to the 21 Card Game! (Not Explicitly Blackjack), ");

            DeckOfCards doc = new DeckOfCards(true);
            Card draw = doc.drawACard();
            Console.WriteLine("Drawing a card");
            Console.WriteLine($"The Card is the {draw.GetCardFace()} of {draw.GetCardSuit()} with a value of {draw.GetCardValue()}");
            //doc.DisplayDeck();

            Console.WriteLine("\n\nDrawing a couple of cards");
            List<Card> hand = new List<Card>();
            hand = doc.drawACard(5);
            foreach (Card c in hand)
            {
                Console.WriteLine($"The Card is the {c.GetCardFace()} of {c.GetCardSuit()} with a value of {c.GetCardValue()}");
            }
            Console.ReadKey();
        }
    }
}

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
            int choice = 0;

            //Card draw = doc.drawACard();
            //Console.WriteLine("Drawing a card");
            //Console.WriteLine($"The Card is the {draw.GetCardFace()} of {draw.GetCardSuit()} with a value of {draw.GetCardValue()}");
            //doc.DisplayDeck();

            playerHand = doc.drawACard(2);
            dealerHand = doc.drawACard(2);

            while (true)
            {
                ShowHand(dealerHand);
                playerTurn = !playerTurn;
                ShowHand(playerHand);
                playerTurn = !playerTurn;
                Console.WriteLine("\n\n");

                if (playerTurn)
                {
                    Console.Write("Will you Hit[1] or Stand[2]? ");
                    choice = PlayerChoice();

                    if (choice == 1)
                    {

                    }
                    else if (choice == 2)
                    {

                    }
                }
                else
                {
                    //
                }

                Console.Clear();
                Console.ReadKey();
            }
        }

        public void ShowHand(List<Card> eitherHand)
        {
            List<Card> hand = eitherHand;
            List<int> totalScore = new List<int>();

            if (playerTurn == false)
            {
                Console.WriteLine("\n\nYour Hand: ");

                foreach (Card c in hand)
                {
                    Console.WriteLine($"{c.GetCardValue()} - The {c.GetCardFace()} of {c.GetCardSuit()}");
                    totalScore.Add(c.GetCardValue());
                }
                Console.WriteLine($"\nHand Value: {handValues[1]}");
            }
            else
            {
                Console.WriteLine("\nDealer's Hand: ");

                foreach (Card c in hand)
                {
                    Console.WriteLine($"{c.GetCardValue()} - The {c.GetCardFace()} of {c.GetCardSuit()}");
                    totalScore.Add(c.GetCardValue());
                }
                Console.WriteLine($"\nHand Value: {handValues[0]}");
            }

            ScoreTally(totalScore);
        }

        public int PlayerChoice()
        {
            while (true)
            {
                string uInput = "";
                int iInput = 0;

                uInput = Console.ReadLine();

                try
                {
                    iInput = int.Parse(uInput);
                    if (iInput == 1 || iInput == 2)
                        return iInput;
                    else
                    {
                        Console.WriteLine("Please pick a number between 1 or 2");
                        Console.ReadKey();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("This program only currently accepts either 1 or 2 as inputs. Please try again!");
                    Console.ReadKey();
                }
            }
        }

        public int ScoreTally(List<int> totalScore)
        {
            int finalScore = 0;

            foreach(int score in totalScore)
                finalScore += score;

            return finalScore;
        }
    }
}

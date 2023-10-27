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
            Console.Write("Welcome to the 21 Card Game! ");
            GameStart();

            Console.ReadKey();
        }

        public void GameStart()
        {
            DeckOfCards doc = new DeckOfCards(true);
            List<Card> playerHand = new List<Card>();
            List<Card> dealerHand = new List<Card>();
            int choice = 0;

            playerHand = doc.drawACard(2);
            dealerHand = doc.drawACard(2);

            while (true)
            {
                ShowHand(dealerHand);
                playerTurn = !playerTurn;
                ShowHand(playerHand);
                playerTurn = !playerTurn;
                Console.WriteLine("\n\n");

                if (playerTurn) // Player's Move
                {
                    Console.Write("Will you Hit[1] or Stand[2]? ");
                    choice = PlayerChoice();

                    if (choice == 1)
                    {
                        Console.WriteLine("Drawing a card.");
                        Card draw = doc.drawACard();
                        playerHand.Add(draw);

                        Console.ReadKey();
                    }
                    else if (choice == 2)
                    {
                        Console.WriteLine("Standing...");

                        Console.ReadKey();
                    }
                }
                else // Dealer's Move
                {
                    //
                }

                Console.Clear();
            }
        }

        public void ShowHand(List<Card> eitherHand)
        {
            List<Card> hand = eitherHand;
            List<int> totalScore = new List<int>();

            Console.WriteLine("Here are the hands: ");

            if (playerTurn == false)
            {
                Console.WriteLine("\n\nYour Hand: ");

                foreach (Card c in hand)
                {
                    Console.WriteLine($"{c.GetCardValue()} - The {c.GetCardFace()} of {c.GetCardSuit()}");
                    totalScore.Add(c.GetCardValue());
                }
                Console.WriteLine($"\nHand Value: {ScoreTally(totalScore)}");
            }
            else
            {
                Console.WriteLine("\nDealer's Hand: ");

                foreach (Card c in hand)
                {
                    Console.WriteLine($"{c.GetCardValue()} - The {c.GetCardFace()} of {c.GetCardSuit()}");
                    totalScore.Add(c.GetCardValue());
                }
                Console.WriteLine($"\nHand Value: {ScoreTally(totalScore)}");
            }

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
                        Console.WriteLine("\nPlease pick a number between 1 or 2");
                        //Console.ReadKey();
                        return iInput;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nThis program only currently accepts either 1 or 2 as inputs. Please try again!");
                    //Console.ReadKey();
                    return iInput;
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

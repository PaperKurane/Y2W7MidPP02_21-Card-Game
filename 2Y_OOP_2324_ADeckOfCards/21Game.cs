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
        private bool playerWin = true;
        private bool gameState = true;

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
            List<int> totalScore = new List<int>();
            int choice = 0;

            playerHand = doc.drawACard(2);
            dealerHand = doc.drawACard(2);

            while (true)
            {
                if (playerTurn == true)
                {
                    Console.Clear();
                    Console.WriteLine("Here are the hands: ");
                    ShowHand(dealerHand);
                    totalScore = ShowHand(playerHand);

                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Here are the hands: ");
                    totalScore = ShowHand(dealerHand);
                    ShowHand(playerHand);
                }
                Console.WriteLine("\n\n");

                ScoreCheck(totalScore);

                if (playerTurn) // Player's Move
                {
                    Console.Write("Will you Hit[1] or Stand[2]? ");
                    choice = PlayerChoice();

                    if (choice == 1)
                    {
                        Console.WriteLine("\nDrawing a card.");
                        Card draw = doc.drawACard();
                        playerHand.Add(draw);
                    }
                    else if (choice == 2)
                        Console.WriteLine("\nStanding...");

                    Console.ReadKey();
                }
                else // Dealer's Move
                {
                    //

                    Console.ReadKey();
                }

                Console.Clear();
            }
        }

        public List<int> ShowHand(List<Card> eitherHand)
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

            playerTurn = !playerTurn;
            return totalScore;
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
                        return iInput;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nThis program only currently accepts either 1 or 2 as inputs. Please try again!");
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

        public void ScoreCheck(List<int> totalScore)
        {
            int finalScore = ScoreTally(totalScore);

            if (finalScore == 21)
            {
                if (playerTurn == true)
                {
                    Console.WriteLine("You won!");
                    playerWin = true;
                }
                else
                {
                    Console.WriteLine("The house wins...");
                    playerWin = false;
                }
                gameState = false;
            }
            else if (finalScore > 21)
            {
                if (playerTurn == true)
                {
                    Console.WriteLine("The house wins...");
                    playerWin = false;
                }
                else
                {
                    Console.WriteLine("You won!");
                    playerWin = true;
                }
                gameState = false;
            }
        }
    }
}

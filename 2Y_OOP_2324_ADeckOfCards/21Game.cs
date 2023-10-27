using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class _21Game
    {
        private bool playerTurn = true;
        private bool gameState = true;

        public _21Game()
        {
            GameStart();
        }

        public void GameStart()
        {
            DeckOfCards doc = new DeckOfCards(true);
            List<Card> playerHand = new List<Card>();
            List<Card> dealerHand = new List<Card>();
            List<int> totalScore = new List<int>();

            playerHand = doc.drawACard(2);
            dealerHand = doc.drawACard(2);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Here are the hands: ");

                if (playerTurn == true)
                {
                    ShowHand(dealerHand);
                    totalScore = ShowHand(playerHand);
                }
                else
                {
                    totalScore = ShowHand(dealerHand);
                    ShowHand(playerHand);
                }

                if (ScoreCheck(totalScore) == false) // Early break in case someone wins
                    break;

                if (playerTurn) // Player's Move
                {
                    int choice = 0;

                    Console.Write("\n\nWill you Hit[1] or Stand[2]? ");
                    choice = PlayerChoice();

                    if (choice == 1)
                    {
                        Console.WriteLine("\nDrawing a card.");
                        Card draw = doc.drawACard();
                        playerHand.Add(draw);
                    }
                    else if (choice == 2)
                        Console.WriteLine("\nStanding...");

                    playerTurn = !playerTurn;
                    Console.ReadKey();
                }
                else // Dealer's Move
                {
                    int choice = 0;

                    choice = DealerMove(dealerHand);

                    if (choice == 1)
                    {
                        Card draw = doc.drawACard();
                        dealerHand.Add(draw);
                    }
                }
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

        public bool ScoreCheck(List<int> totalScore)
        {
            int finalScore = ScoreTally(totalScore);
            Console.WriteLine("\n");

            if (finalScore == 21)
            {
                if (playerTurn == true)
                    Console.WriteLine("You won!");
                else
                    Console.WriteLine("The house wins...");

                gameState = false;
            }
            else if (finalScore > 21)
            {
                if (playerTurn == true)
                    Console.WriteLine("The house wins...");
                else
                    Console.WriteLine("You won!");

                gameState = false;
            }

            return gameState;
        }

        public int DealerMove(List<Card> dealerHand)
        {
            List<int> totalScore = ShowHand(dealerHand);
            int finalScore = ScoreTally(totalScore);

            if (finalScore <= 17)
                return 1;
            else
                return 2;
        }
    }
}

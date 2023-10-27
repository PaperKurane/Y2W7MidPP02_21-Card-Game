using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2Y_OOP_2324_ADeckOfCards
{
    internal class Card
    {
        private int value = 0;
        private char suit = ' ';
        private string faceValue = "";

        public Card(int v, char s, string f)
        {
            value = v;
            suit = s; 
            faceValue = f;
        }

        public int GetCardValue()
        {
            return value;
        }

        public string GetCardSuit()
        {
            string Suit = "";
            switch(suit)
            {
                case 'D':
                    Suit = "Diamonds";
                    break;
                case 'H':
                    Suit = "Hearts";
                    break;
                case 'S':
                    Suit = "Spades";
                    break;
                case 'C':
                    Suit = "Clubs";
                    break;
            }
            return Suit;
        }

        public string GetCardFace()
        {
            string face = faceValue;

            switch(face)
            {
                case "A":
                    face = "Ace";
                    break;
                case "J":
                    face = "Jack";
                    break;
                case "Q":
                    face = "Queen";
                    break;
                case "K":
                    face = "King";
                    break;
            }

            return face;
        }
    }
}

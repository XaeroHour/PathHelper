using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathHelper
{
    class Card
    {
        public enum CardType
        {
            Boon = 0,
            Bane,
            Count
        };

        public enum CardTrait
        {
            Basic = 0,
            Elite,
            Count
        };

        public string CardName = string.Empty;

        public string CardText = string.Empty;

        public List<string> CardPowers;

        public CharacterAbility CardRecharge = null;

        public List<CharacterAbility> CardAbilityChecks;
        public List<CharacterStat> CardStatChecks;

        public Card(string name, string text)
        {
            CardName = name;
            CardText = text;
        }
    }

    class Deck
    {
        public List<Card> Cards = new List<Card>();

        public List<Card> Hand = new List<Card>();

        public int HandSize;

        public Deck(int handSize = 6)
        {
            HandSize = handSize > 0 ? handSize : 6;
            Hand = new List<Card>(HandSize);
        }

        public void AddCard(string name, string text)
        {
            Cards.Add(new Card(name, text));
        }
    }
}

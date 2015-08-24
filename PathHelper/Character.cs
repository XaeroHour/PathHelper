using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PathHelper
{
    static class DiceRoller
    {
        private static readonly Random Roller = new Random();
        public static int Roll(int die = 4, int diceCount = 1) => Roller.Next(die * diceCount) + diceCount;
    }

    class CharacterStat
    {
        // Your die never changes (at least not yet) but your modifier can go up
        public readonly int Die;
        public int Modifier;

        public CharacterStat(int die = 4, int modifier = 0)
        {
            Die = ((die >= 2) && (die <= 20)) ? die : 4;
            Modifier = (modifier >= 0) ? modifier : 0;
        }

        public int Roll(int diceCount = 1) => DiceRoller.Roll(Die, diceCount) + Modifier;
    }

    class CharacterAbility
    {
        public readonly CharacterStat BaseStat;
        public readonly int Modifier;

        public CharacterAbility(ref CharacterStat baseStat, int modifier = 1)
        {
            BaseStat = baseStat;
            Modifier = (modifier > 0) ? modifier : 1;
        }

        public int Roll(int diceCount = 1) => BaseStat.Roll(diceCount) + Modifier;
    }

    class Character
    {
        public enum Stats
        {
            Strength = 0,
            Charisma,
            Intelligence,
            Wisdom,
            Dexterity,
            Constitution,
            Max
        };

        public enum Abilities
        {
            Melee = 0,
            Ranged,
            Perception,
            Survival,
            Arcane,
            Divine,
            Fortitude,
            Knowledge,
            Max
        };

        public string Name;
        public CharacterStat[] MyStats = new CharacterStat[(int)Stats.Max];
        public CharacterAbility[] MyAbilities = new CharacterAbility[(int)Abilities.Max];
        public List<string> MyPowers = new List<string>();
        public Deck MyDeck = new Deck();

        public Character(string name, int strength, int charisma, int intelligence, int wisdom, int dexterity,
            int constitution)
        {
            Name = name;
            MyStats[(int)Stats.Strength] = new CharacterStat(strength);
            MyStats[(int)Stats.Charisma] = new CharacterStat(charisma);
            MyStats[(int)Stats.Intelligence] = new CharacterStat(intelligence);
            MyStats[(int)Stats.Wisdom] = new CharacterStat(wisdom);
            MyStats[(int)Stats.Dexterity] = new CharacterStat(dexterity);
            MyStats[(int)Stats.Constitution] = new CharacterStat(constitution);
        }

        public void AddAbility(Abilities newAbility, Stats baseStat, int modifier) => MyAbilities[(int)newAbility] = new CharacterAbility(ref MyStats[(int)baseStat], modifier);
        public void AddPower(string power) => MyPowers.Add((power));
        public void AddCard(string name, string text) => MyDeck.AddCard(name, text);

        public int RollAbility(Abilities abilityCheck) => MyAbilities[(int)abilityCheck] != null ? MyAbilities[(int)abilityCheck].Roll() : DiceRoller.Roll();
        public int RollStat(Stats statCheck) => MyStats[(int)statCheck] != null ? MyStats[(int)statCheck].Roll() : DiceRoller.Roll();
    }
}

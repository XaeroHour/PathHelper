using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PathHelper
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Character StevesGuy = new Character("Balazar", 6, 10, 8, 6, 6, 6);
        private List<TextBlock> TextBoxes = new List<TextBlock>();

        public MainPage()
        {
            this.InitializeComponent();
            StevesGuy.AddAbility(Character.Abilities.Knowledge, Character.Stats.Intelligence, 2);
            StevesGuy.AddAbility(Character.Abilities.Arcane, Character.Stats.Charisma, 2);
            StevesGuy.AddPower("After you play a spell that has the Attack trait, banish it.");
            StevesGuy.AddPower("You may discard a spell to draw a random monster from the box.");
            StevesGuy.AddPower("When you defeat a monster and would banish it, you may add it to your hand instead.  You may banish a monster form you hand to draw a card.");

            StevesGuy.AddCard("Padrig", "Display this card. While displayed, when you attempt a Strength check and do not play a weapon, you may put a card on top of your deck to add your Arcane skill plus " +
                "the scenario's adventure deck number to that check.  You may banish any number of monsters; for each monster banished, add 1d4 to the check, or 1d6 if you have  aorle card. If you are " +
                "encountering a monster, add another 1d6 for each monster banished that shares a trait other than Basic or Elite with the monster you are encountering.");
            StevesGuy.AddCard("Blessing of Ascension", "If you encounter this card and you have  amythic charge, you automatically acquire it.\n" +
                "Discard this card to add 1 die to any check.\n" +
                "Discard this card to explore your location.\n" +
                "Discard this card to get a mythic charge.\n");
            StevesGuy.AddCard("Blessing of Ascension", "If you encounter this card and you have  amythic charge, you automatically acquire it.\n" +
                "Discard this card to add 1 die to any check.\n" +
                "Discard this card to explore your location.\n" +
                "Discard this card to get a mythic charge.\n");
            StevesGuy.AddCard("Blessing of Ascension", "If you encounter this card and you have  amythic charge, you automatically acquire it.\n" +
                "Discard this card to add 1 die to any check.\n" +
                "Discard this card to explore your location.\n" +
                "Discard this card to get a mythic charge.\n");
            StevesGuy.AddCard("Blessing of Ascension", "If you encounter this card and you have  amythic charge, you automatically acquire it.\n" +
                "Discard this card to add 1 die to any check.\n" +
                "Discard this card to explore your location.\n" +
                "Discard this card to get a mythic charge.\n");
            StevesGuy.AddCard("Vulture", "When you are dealt damage, reveal this card to give 1 card you would discard as damage to a random other character instead.\n" +
                "Discard this card to explore your location.");
            StevesGuy.AddCard("Frilled Lizard", "Discard this card to add 2d4 to your check against a bane that has the Veteran trait.\n" +
                "Discard this card to explore your location.");
            StevesGuy.AddCard("Blackwing Librarian", "Recharge this card to succeed at your check against a boon that has the Arcane trait.\n" +
                "Discard this card to explore your location.");
            StevesGuy.AddCard("Potion of Beast Skin", "Display this card and choose a character at your location. While displayed, reduce combat damage " +
                "dealt to that character by 2. At the end of the turn, banish this card.");
            StevesGuy.AddCard("Blood Periapt", "Discard this card to reduce damage dealt to you by 3.  After playing this card you may succeed at a " +
                "Constitution or Fortitude 6 check to recharge this card instead of discarding it.");
            StevesGuy.AddCard("Padded Armor", "Discard this card to reduce Combat damage dealt to you before or after you act by 2.\n" +
                "Banish this card to reduce all damage dealt to you to 0; if proficient with light armors, bury it instead.");
            StevesGuy.AddCard("Glibness", "Display this card next to acharacter. While displayed add 3 to that character's Charisma checks. At the end of " +
                "the turn, if you do not have either the Arcane or Devine skill, banish this card; otherwise, you may attempt an Arcane or Divine 8 check. " +
                "If you succeed, recharge this card; if you fail, discard it.");
            StevesGuy.AddCard("Enchanted Fang", "When a cahracter at your location attempts a combat check, if he plays an ally that has the Animal traid or does not play cards that " +
                "have the Attack trait or weapons, discard this card to add 1d4 and the Magic trait to that check.\n" +
                "After playing this card, if you do not have either the Arcane or Divine skill, banish it; otherwise, you may succeed at a Arcane or Diving 7 check to " +
                "recharge this card instead of discarding it.");
            StevesGuy.AddCard("Create Pit", "Discard this card to evade a monster you encounter whose highest difficulty to defeat is 12 or lower; you may instead bury this " +
                "card to put the monster on the bottom of its location deck.\n" +
                "After playing this card, if you do not have the Arcane skill banish it; otherwise you may succeed at an Arcane 8 check to recharge this card instead of discarding or burying it.");
            StevesGuy.AddCard("Brilliance", "Display this card next to a character. While displayed, add 3 to that character's intelligence checks. " +
                "At the end of the turn, if you do not have either the Arcane or Divine skill, banish this card; otherwise, you may attempt an Arcane or Divine 8 check. " +
                "If you succeed, recharge this card; if you fail, discard it.");
            StevesGuy.AddCard("Agility", "Display this card next to a character.  While displayed, add 3 to that character's Dexterity checks. " +
                "At the end of the turn, if you do not have either the Arcane or Divine skill, banish this card; otherwise, you may attempt an Arcane or Divine 8 check. " +
                "If you succeed, recharge this card; if you fail, discard it.");

            foreach(Card c in StevesGuy.MyDeck.Cards)
            {
                listBox_Deck.Items.Add(c.CardName);
            }

            TextBoxes.Add(textBlock_Card1);
            TextBoxes.Add(textBlock_Card2);
            TextBoxes.Add(textBlock_Card3);
            TextBoxes.Add(textBlock_Card4);
            TextBoxes.Add(textBlock_Card5);
            TextBoxes.Add(textBlock_Card6);

            listBox_Stats.Items.Add(string.Format("STRENGTH:     d{0} + {1}", StevesGuy.MyStats[(int)Character.Stats.Strength].Die, StevesGuy.MyStats[(int)Character.Stats.Strength].Modifier));
            listBox_Stats.Items.Add(string.Format("DEXTERITY:    d{0} + {1}", StevesGuy.MyStats[(int)Character.Stats.Dexterity].Die, StevesGuy.MyStats[(int)Character.Stats.Dexterity].Modifier));
            listBox_Stats.Items.Add(string.Format("CONSTITUTION: d{0} + {1}", StevesGuy.MyStats[(int)Character.Stats.Constitution].Die, StevesGuy.MyStats[(int)Character.Stats.Constitution].Modifier));
            listBox_Stats.Items.Add(string.Format("INTELLIGENCE: d{0} + {1}", StevesGuy.MyStats[(int)Character.Stats.Intelligence].Die, StevesGuy.MyStats[(int)Character.Stats.Intelligence].Modifier));
            listBox_Stats.Items.Add(string.Format("   KNOWLEDGE: d{0} + {1}", StevesGuy.MyAbilities[(int)Character.Abilities.Knowledge].BaseStat.Die, StevesGuy.MyAbilities[(int)Character.Abilities.Knowledge].Modifier));
            listBox_Stats.Items.Add(string.Format("WISDOM:       d{0} + {1}", StevesGuy.MyStats[(int)Character.Stats.Wisdom].Die, StevesGuy.MyStats[(int)Character.Stats.Wisdom].Modifier));
            listBox_Stats.Items.Add(string.Format("CHARISMA:     d{0} + {1}", StevesGuy.MyStats[(int)Character.Stats.Charisma].Die, StevesGuy.MyStats[(int)Character.Stats.Charisma].Modifier));
            listBox_Stats.Items.Add(string.Format("   ARCANE:    d{0} + {1}", StevesGuy.MyAbilities[(int)Character.Abilities.Arcane].BaseStat.Die, StevesGuy.MyAbilities[(int)Character.Abilities.Arcane].Modifier));
        }

        private void listBoxDeckSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = -1;
            foreach (string selectedName in listBox_Deck.SelectedItems)
            {
                if(++i >= StevesGuy.MyDeck.HandSize)
                {
                    return;
                }

                TextBoxes[i].Text = selectedName + "\n\n" + GetCardText(selectedName);
            }

            for (i = i + 1; i < StevesGuy.MyDeck.HandSize; i++)
                TextBoxes[i].Text = string.Empty;
        }

        private string GetCardText(string cardName)
        {
            foreach(Card c in StevesGuy.MyDeck.Cards)
            {
                if (c.CardName == cardName)
                    return c.CardText;
            }
            return string.Empty;
        }
    }
}

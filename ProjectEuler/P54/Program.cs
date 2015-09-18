using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Common;

namespace P54
{
    public static class HandExtensions
    {
        public static Dictionary<CardValue, int> GroupByValue(this Hand h)
        {
            return h.Cards
                .GroupBy(c => c.Value)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public static Dictionary<CardSuit, int> GroupBySuit(this Hand h)
        {
            return h.Cards
                .GroupBy(c => c.Suit)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        public static bool SameSuit(this Hand h)
        {
            return h.Cards.Select(c => c.Suit).Distinct().Count() == 1;
        }

        public static bool SameValue(this Hand h, int a = 5)
        {
            var kinds = h.Cards
                .Select(c => c.Value)
                .GroupBy(c => c)
                .ToDictionary(c => c, c => c.Count())
                .OrderByDescending(kvp => kvp.Value)
                .ToList();

            return kinds.Any(kvp => kvp.Value == a);
        }

        public static bool ThereIs(this Hand h, CardValue nominal)
        {
            return h.Cards.Any(c => c.Value == nominal);
        }

        public static bool Consecutive(this Hand h)
        {
            if (h.ThereIs(CardValue.Ace)
                && h.ThereIs(CardValue.C2)
                && h.ThereIs(CardValue.C3)
                && h.ThereIs(CardValue.C4)
                && h.ThereIs(CardValue.C5))
            {
                return true;
            }

            var nominals = h.Cards.Select(c => c.Value).OrderBy(c => c).ToList();

            for (int i = 0; i < 4; i++)
            {
                if ((int)nominals[i + 1] != (int)nominals[i] + 1)
                {
                    return false;
                }
            }

            return true;
        }
    }

    public class Card
    {
        public CardValue Value;
        public CardSuit Suit;

        public static Card Parse(string s)
        {
            var d = new Dictionary<char, CardValue>()
            {
                {'2', CardValue.C2},
                {'3', CardValue.C3},
                {'4', CardValue.C4},
                {'5', CardValue.C5},
                {'6', CardValue.C6},
                {'7', CardValue.C7},
                {'8', CardValue.C8},
                {'9', CardValue.C9},
                {'T', CardValue.C10},
                {'J', CardValue.Jack},
                {'Q', CardValue.Queen},
                {'K', CardValue.King},
                {'A', CardValue.Ace},
            };

            var t = new Dictionary<char, CardSuit>() 
            {
                {'D', CardSuit.D},
                {'S', CardSuit.S},
                {'C', CardSuit.C},
                {'H', CardSuit.H},
            };

            return new Card()
            {
                Value = d[s[0]],
                Suit = t[s[1]],
            };
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Suit, Value);
        }

        public void ToConsole()
        {
            var c = Console.BackgroundColor;

            switch(Suit)
            {
                case CardSuit.C: Console.BackgroundColor = ConsoleColor.Red; break;
                case CardSuit.D: Console.BackgroundColor = ConsoleColor.Green; break;
                case CardSuit.H: Console.BackgroundColor = ConsoleColor.Magenta; break;
                case CardSuit.S: Console.BackgroundColor = ConsoleColor.DarkCyan; break;
                default:
                    break;
            }

            Console.Write(Value);

            Console.BackgroundColor = c;
        }

        public static implicit operator int(Card c)
        {
            return (int)c.Value;
        }
    }

    public enum CardValue
    {
        C2 = 1,
        C3,C4,C5,C6,C7,C8,C9,C10,
        Jack,
        Queen,
        King,
        Ace,
    }

    public enum CardSuit
    {
        D,
        S,
        C,
        H,
    }

    public class Hand
    {
        public Card[] Cards;

        public Hand()
        {
            Cards = new Card[5];
        }

        public static Hand Parse(string s)
        {
            var cardsString = s.Split(' ');

            var hand = new Hand();

            for (int i = 0; i < 5; i++)
            {
                hand.Cards[i] = Card.Parse(cardsString[i]);    
            }

            return hand;
        }

        public override string ToString()
        {
            return string.Join(", ", Cards.OfType<Card>());
        }

        public void ToConsole()
        {
            for (int i = 0; i < 5; i++)
            {
                Cards[i].ToConsole();

                Console.Write(" ");
            }

            Console.WriteLine("");
            //Console.Write()
        }
    }

    //High Card: Highest value card.
    //One Pair: Two cards of the same value.
    //Two Pairs: Two different pairs.
    //Three of a Kind: Three cards of the same value.
    //Straight: All cards are consecutive values.
    //Flush: All cards of the same suit.
    //Full House: Three of a kind and a pair.
    //Four of a Kind: Four cards of the same value.
    //Straight Flush: All cards are consecutive values of same suit.
    //Royal Flush: Ten, Jack, Queen, King, Ace, in same suit.

    public enum Combination
    {
        HighCard,
        OnePair,
        TwoPairs,
        ThreeOfALind,
        Straight,
        Flush,
        FullHouse,
        FourOfAKind,
        StraightFlush,
        RoyalFlush,
    }

    public class CombinationTester
    {
        public const int D = 20;

        public int RoyalFlush(Hand h)
        {
            bool ss = h.SameSuit();
            bool cs = h.Consecutive();

            if (ss)
            {
                if (cs)
                {
                    if (h.ThereIs(CardValue.Ace))
                    {
                        return 1;
                    }
                }
            }

            return 0;
        }

        public int StraightFlush(Hand h)
        {
            if (h.SameSuit()
                && h.Consecutive())
            {
                return (int)h.Cards.Select(c => c.Value).OrderByDescending(c => c).First();
            }

            return 0;
        }

        public int Four(Hand h)
        {
            var gv = h.GroupByValue()
                .OrderByDescending(kvp => kvp.Value);

            if (gv.Count() == 2 && gv.First().Value == 4)
            {
                return D * (int)gv.First().Key
                    + (int)gv.Last().Key;
            }

            return 0;
        }

        public int FullHouse(Hand h)
        {
            var gv = h.GroupByValue()
                .OrderByDescending(kvp => kvp.Value);

            if (gv.Count() == 2 && gv.First().Value == 3)
            {
                return D * (int)gv.First().Key
                    + (int)gv.Last().Key;
            }

            return 0;
        }

        public int Flush(Hand h)
        {
            if (h.SameSuit())
            {
                int r = 0;
                int m = 1;

                var v = h.Cards.OrderBy(c => (int)c.Value).ToList();

                for (int i = 0; i < 5; i++)
                {
                    r += m * (int)v[i].Value;

                    m *= D;
                }

                return r;
            }

            return 0;
        }

        public int Straight(Hand h)
        {
            if (h.Consecutive())
            {
                return (int)h.Cards.OrderByDescending(c => (int)c.Value).First().Value;
            }

            return 0;
        }

        public int Three(Hand h)
        {
            var gv = h.GroupByValue()
                .OrderByDescending(kvp => kvp.Value)
                .ThenByDescending(kvp => (int)kvp.Key)
                .ToList();

            if (gv.Count() == 3 && gv.First().Value == 3)
            {
                return D * D * (int)gv[0].Key
                    + D * (int)gv[1].Key
                    + 1 * (int)gv[2].Key;
            }

            return 0;
        }

        public int IsTwoPairs(Hand h)
        {
            var gv = h.GroupByValue()
                .OrderByDescending(kvp => kvp.Value)
                .ThenByDescending(kvp => (int)kvp.Key)
                .ToList();

            if (gv.Count() == 3 && gv[0].Value == 2 && gv[1].Value == 2)
            {
                return D * D * (int)gv[0].Key
                    + D * (int)gv[1].Key
                    + 1 * (int)gv[2].Key;
            }

            return 0;
        }

        public int IsOnePair(Hand h)
        {
            var gv = h.GroupByValue()
                .OrderByDescending(kvp => kvp.Value)
                .ThenByDescending(kvp => (int)kvp.Key)
                .ToList();

            if (gv.Count() == 4 && gv[0].Value == 2)
            {
                return D * D * D * (int)gv[0].Key
                    + D * D * (int)gv[1].Key
                    + D * (int)gv[2].Key
                    + 1 * (int)gv[3].Key;
            }

            return 0;
        }

        public int HighestCard(Hand h)
        {
            var gv = h.GroupByValue()
                .OrderByDescending(kvp => (int)kvp.Key)
                .ToList();

            if (gv.Count() == 5)
            {
                return D * D * D * D * (int)gv[0].Key
                    + D * D * D * (int)gv[1].Key
                    + D * D * (int)gv[2].Key
                    + D * (int)gv[3].Key
                    + 1 * (int)gv[4].Key;
            }

            //throw new Exception();

            return 0;
        }

        public bool IsWin(Hand h1, Hand h2)
        {
            return (
                null 
                ?? Chk(RoyalFlush, h1, h2)
                ?? Chk(StraightFlush, h1, h2)
                ?? Chk(Four, h1, h2)
                ?? Chk(FullHouse, h1, h2)
                ?? Chk(Flush, h1, h2)
                ?? Chk(Straight, h1, h2)
                ?? Chk(Three, h1, h2)
                ?? Chk(IsTwoPairs, h1, h2)
                ?? Chk(IsOnePair, h1, h2)
                ?? Chk(HighestCard, h1, h2)
                )
                .Value;
        }

        public bool? Chk(Func<Hand, int> ev, Hand h1, Hand h2)
        {
            int h1r = ev.Invoke(h1);
            int h2r = ev.Invoke(h2);

            if (h1r != 0)
            {
                (ev.Method.Name + ": " + h1.ToString() + " =" + h1r).Dump();
            }

            if (h2r != 0)
            {
                (ev.Method.Name + ": " + h2.ToString() + " =" + h2r).Dump();
            }

            if (h1r == h2r)
            {
                return null;
            } else if (h1r > h2r)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Hand> all = new List<Hand>();

            int result = 0;
            int a  = 0;
            using (StreamReader r = new StreamReader("p054_poker.txt"))
            {
                while(!r.EndOfStream)
                {
                    string line = r.ReadLine();

                    string hand1String = line.Substring(0, 14);
                    string hand2String = line.Substring(15).Trim();

                    Hand h1 = Hand.Parse(hand1String);
                    Hand h2 = Hand.Parse(hand2String);

                    (a+1).Dump();

                    h1.ToConsole();
                    h2.ToConsole();

                    all.Add(h1);
                    all.Add(h2);

                    var ct = new CombinationTester();

                    if (ct.IsWin(h1, h2))
                    {
                        result += 1;
                    }

                    a += 1;

                    "---".Dump();
                }
            }

            var ss = all.Where(h => h.SameSuit()).ToList();
            var cs = all.Where(h => h.Consecutive()).ToList();

            a.Dump("Total");
            result.Dump("Answer");
        }
    }
}

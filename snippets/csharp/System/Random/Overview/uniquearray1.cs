// <Snippet11>
using System;

// A class that represents an individual card in a playing deck.
public class Card
{
    public Suit Suit;
    public FaceValue FaceValue;

    public override string ToString()
    {
        return string.Format("{0:F} of {1:F}", FaceValue, Suit);
    }
}

public enum Suit { Hearts, Diamonds, Spades, Clubs };

public enum FaceValue
{
    Ace = 1, Two, Three, Four, Five, Six,
    Seven, Eight, Nine, Ten, Jack, Queen,
    King
};

public class Dealer
{
    Random _rnd;
    // A deck of cards, without Jokers.
    Card[] _deck = new Card[52];
    // Parallel array for sorting cards.
    double[] _order = new double[52];
    // A pointer to the next card to deal.
    int _ptr = 0;
    // A flag to indicate the deck is used.
    bool _mustReshuffle = false;

    public Dealer()
    {
        _rnd = new Random();
        // Initialize the deck.
        int deckCtr = 0;
        foreach (object suit in Enum.GetValues(typeof(Suit)))
        {
            foreach (object faceValue in Enum.GetValues(typeof(FaceValue)))
            {
                Card card = new()
                {
                    Suit = (Suit)suit,
                    FaceValue = (FaceValue)faceValue
                };
                _deck[deckCtr] = card;
                deckCtr++;
            }
        }

        for (int ctr = 0; ctr < _order.Length; ctr++)
            _order[ctr] = _rnd.NextDouble();

        Array.Sort(_order, _deck);
    }

    public Card[] Deal(int numberToDeal)
    {
        if (_mustReshuffle)
        {
            Console.WriteLine("There are no cards left in the deck");
            return null;
        }

        Card[] cardsDealt = new Card[numberToDeal];
        for (int ctr = 0; ctr < numberToDeal; ctr++)
        {
            cardsDealt[ctr] = _deck[_ptr];
            _ptr++;
            if (_ptr == _deck.Length)
                _mustReshuffle = true;

            if (_mustReshuffle & ctr < numberToDeal - 1)
            {
                Console.WriteLine($"Can only deal the {ctr + 1} cards remaining on the deck.");
                return cardsDealt;
            }
        }
        return cardsDealt;
    }
}

public class Example21
{
    public static void Main()
    {
        Dealer dealer = new();
        ShowCards(dealer.Deal(20));
    }

    private static void ShowCards(Card[] cards)
    {
        foreach (Card card in cards)
            if (card != null)
                Console.WriteLine("{0} of {1}", card.FaceValue, card.Suit);
    }
}
// The example displays output like the following:
//       Six of Diamonds
//       King of Clubs
//       Eight of Clubs
//       Seven of Clubs
//       Queen of Clubs
//       King of Hearts
//       Three of Spades
//       Ace of Clubs
//       Four of Hearts
//       Three of Diamonds
//       Nine of Diamonds
//       Two of Hearts
//       Ace of Hearts
//       Three of Hearts
//       Four of Spades
//       Eight of Hearts
//       Queen of Diamonds
//       Two of Clubs
//       Four of Diamonds
//       Jack of Hearts
// </Snippet11>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Deck : MonoBehaviour
{
    public List<Card> Cards = new List<Card>();

    public Card GetCurrentCard()
    {
        if (Cards.Count == 0) return null;
        return Cards.First();
    }

    public void RemoveCard()
    {
        Cards.Remove(Cards.First());
    }

    public void AddCard(Card toAdd)
    {
        Cards.Add(toAdd);
    }
}

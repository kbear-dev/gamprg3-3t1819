using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Deck : MonoBehaviour
{
    public List<Card> Cards = new List<Card>();

    public int selectedCard { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
    }

    private void Update()
    {
        if (Cards.Count == 0)
        {
            return;
        }

        if (Input.mouseScrollDelta.y > 0)
        {
            if (selectedCard == Cards.Count - 1)
            {
                selectedCard = 0;
                return;
            }

            selectedCard++;

        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            if (selectedCard == 0)
            {
                selectedCard = Cards.Count - 1;
                return;
            }

            selectedCard--;
        }

        Cards.RemoveAll(c => c == null);
    }

    public Card GetCurrentCard()
    {
        if (Cards.Count == 0) return null;
        return Cards[selectedCard];
    }

    public void AddCard(Card toAdd)
    {
        Cards.Add(toAdd);
    }

    public void RemoveCurrentCard()
    {
        Cards.Remove(Cards[selectedCard]);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckHUD : MonoBehaviour
{
    public Image slot;
    public Text CardName;
    public Text CardDescription;

    public Deck deck;

    public Sprite EmptyCardSprite;

    // Update is called once per frame
    void Update()
    {
        ChangeCard(deck.GetCurrentCard());
    }

    private void ChangeCard(Card currentCard)
    {
        if (currentCard == null)
        {
            slot.sprite = EmptyCardSprite;
            slot.color = Color.white;
            CardName.text = "";
            CardDescription.text = "";
            return;
        }

        slot.sprite = currentCard.GetComponent<SpriteRenderer>().sprite;
        slot.color = currentCard.GetComponent<SpriteRenderer>().color;
        CardName.text = currentCard.CardName;
        CardDescription.text = currentCard.CardDescription;
    }
}

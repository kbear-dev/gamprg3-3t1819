using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckHUD : MonoBehaviour
{
    public Image slot;
    public Deck deck;

    public Sprite EmptyCardSprite;

    // Start is called before the first frame update
    void Start()
    {
        ChangeCard(deck.GetCurrentCard());
    }

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
            return;
        }

        slot.sprite = currentCard.GetComponent<SpriteRenderer>().sprite;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class OnCardPicked : UnityEvent<Card> { }

public class ChestSlot : MonoBehaviour
{
    [HideInInspector] public OnCardPicked CardPicked = new OnCardPicked();
    [HideInInspector] public Card OfferedCard;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.image.sprite = OfferedCard.GetComponent<SpriteRenderer>().sprite;
        button.image.color = OfferedCard.GetComponent<SpriteRenderer>().color;
    }
    public void PickCard()
    {
        CardPicked.Invoke(OfferedCard);
    }
}

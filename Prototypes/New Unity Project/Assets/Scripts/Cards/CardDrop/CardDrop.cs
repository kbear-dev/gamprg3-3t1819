using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDrop : MonoBehaviour
{
    public Card Pickup;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Player player = collision.collider.GetComponent<Player>();
        if (player != null)
        {
            player.GetComponent<CardThrow>().Deck.AddCard(Pickup);
            Destroy(gameObject);
        }
    }
}

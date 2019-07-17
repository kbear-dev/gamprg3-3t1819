using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardThrow : MonoBehaviour
{
    //public Card Card;
    public Deck Deck;
    public Transform ProjectileSpawn;
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, GetMouseRotation()));
        if (Input.GetMouseButtonDown(0))
            if (Deck.GetCurrentCard() != null) ThrowCard();
    }

    void ThrowCard()
    {
        Card toThrow = Deck.GetCurrentCard();
        Vector3 newRot = transform.rotation.eulerAngles;
        //newRot.z -= 90;
        Instantiate(toThrow, ProjectileSpawn.position, Quaternion.Euler(newRot));
        Deck.RemoveCard();
    }

    float GetMouseRotation()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 relativePosition = mousePosition - transform.position;
        float angle = Mathf.Atan2(relativePosition.y, relativePosition.x) * Mathf.Rad2Deg; Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return angle;
    }
}

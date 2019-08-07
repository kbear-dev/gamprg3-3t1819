using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardThrow : MonoBehaviour
{
    //public Card Card;
    public Deck Deck;
    public Transform ProjectileSpawn;

    private bool canShoot;

    private void Start()
    {
        canShoot = true;
    }

    void Update()
    {
        if (MenuManager.isPaused) return;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, GetMouseRotation()));
        if (canShoot && Input.GetMouseButtonDown(0))
            if (Deck.GetCard() != null) StartCoroutine(ThrowCard());
    }

    IEnumerator ThrowCard()
    {
        Card toThrow = Deck.GetCard();

        if (toThrow == null)
        {
            //yield return Instantiate(toThrow, ProjectileSpawn.position, Quaternion.Euler(newRot));
            toThrow = Instantiate(toThrow);
            Deck.AddCard(toThrow);
        }

        toThrow.Caster = GetComponent<Unit>();
        Vector3 newRot = transform.rotation.eulerAngles;

        toThrow.transform.position = ProjectileSpawn.position;
        toThrow.transform.rotation = Quaternion.Euler(newRot);


        toThrow.OnThrow();
        yield return null;
    }

    float GetMouseRotation()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 relativePosition = mousePosition - transform.position;
        float angle = Mathf.Atan2(relativePosition.y, relativePosition.x) * Mathf.Rad2Deg; Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return angle;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<CardChest>()) canShoot = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<CardChest>()) canShoot = true;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingCard : Card
{
    public float ProjectileSpeed;
    public int Damage;
    public CardDrop CardDrop;

    void Update()
    {
        transform.Translate(ProjectileSpeed * Time.deltaTime, 0, 0);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        Target = collision.collider.GetComponent<Unit>();
        StartCoroutine(HandleCollision());
    }

    IEnumerator HandleCollision()
    {
        yield return StartCoroutine(OnEffect());
        yield return null;
        DropCard();
        Destroy(gameObject);
    }
    protected void DropCard()
    {
        if (CardDrop != null)
            Instantiate(CardDrop, transform.position, Quaternion.identity);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public CardDrop CardDrop;
    public float ProjectileSpeed;
    public int Damage;

    protected virtual IEnumerator OnEffect(Collision2D collision) { yield break; }

    public void Update()
    {
        transform.Translate(ProjectileSpeed * Time.deltaTime, 0, 0);
    }

    protected void DropCard()
    {
        if(CardDrop!= null) Instantiate(CardDrop, transform.position, Quaternion.identity);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(HandleCollision(collision));
    }

    IEnumerator HandleCollision(Collision2D collision)
    {
        yield return StartCoroutine(OnEffect(collision));
        yield return null;
        DropCard();
        Destroy(gameObject);
    }

}

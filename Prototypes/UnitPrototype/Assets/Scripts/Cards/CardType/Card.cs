using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public CardDrop CardDrop;
    public float ProjectileSpeed;
    public int Damage;

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
        StartCoroutine(DoEffect(collision));
    }

    public virtual IEnumerator DoEffect(Collision2D collision)
    {
        yield return null;
        DropCard();
        Destroy(gameObject);
    }
}

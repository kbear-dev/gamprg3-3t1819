using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public CardDrop CardDrop;
    public float ProjectileSpeed;

    public void Update()
    {
        transform.Translate(ProjectileSpeed * Time.deltaTime, 0, 0);
    }

    protected void DropCard()
    {
        if(CardDrop!= null) Instantiate(CardDrop, transform.position, Quaternion.identity);
    }

    public abstract void DoEffect(Enemy target);
}

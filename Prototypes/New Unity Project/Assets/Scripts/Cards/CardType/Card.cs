using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    public Unit Target;
    public CardDrop CardDrop;
    public float ProjectileSpeed;
    public int Damage;

    protected virtual IEnumerator OnEffect(Collision2D collision) { yield break; }

    protected void DropCard()
    {
        if(CardDrop!= null) Instantiate(CardDrop, transform.position, Quaternion.identity);
    }


}

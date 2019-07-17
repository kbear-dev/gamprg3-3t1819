using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Card : MonoBehaviour
{
    [HideInInspector] public Unit Caster;
    [HideInInspector] public Unit Target;
    public CardDrop CardDrop;
    public float ProjectileSpeed;
    public int Damage;

    protected virtual IEnumerator OnEffect() { yield break; }

    protected void DropCard()
    {
        if(CardDrop!= null) Instantiate(CardDrop, transform.position, Quaternion.identity);
    }


}

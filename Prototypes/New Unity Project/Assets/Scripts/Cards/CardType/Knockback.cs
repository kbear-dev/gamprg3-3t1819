using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : ThrowingCard
{
    public float KnockbackStrength;

    protected override IEnumerator OnEffect(Collision2D collision)
    {
        //if (!collision.collider.GetComponent<Unit>()) yield break;
        Vector2 direction = collision.transform.position - transform.position;
        collision.collider.GetComponent<Rigidbody2D>().AddForce(transform.right * KnockbackStrength);
        yield return null;
    }
}

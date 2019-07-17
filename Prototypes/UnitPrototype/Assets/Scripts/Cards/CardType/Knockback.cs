using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : ThrowingCard
{
    public float KnockbackStrength;

    protected override IEnumerator OnEffect()
    {
        if (Target == null) yield break;
        Vector2 direction = Target.transform.position - transform.position;
        Target.GetComponent<Rigidbody2D>().AddForce(transform.right * KnockbackStrength);
        yield return null;
    }
}

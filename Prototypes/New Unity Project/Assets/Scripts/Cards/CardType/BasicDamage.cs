using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDamage : ThrowingCard
{
    protected override IEnumerator OnEffect(Collision2D collision)
    {
        Health health = collision.collider.GetComponent<Health>();
        if (health != null) health.TakeDamage(Damage);
        yield return null;
    }

}

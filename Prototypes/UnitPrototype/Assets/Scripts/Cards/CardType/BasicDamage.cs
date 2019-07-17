using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDamage : ThrowingCard
{
    protected override IEnumerator OnEffect()
    {
        if (Target == null) yield break;
        Health health = Target.health;
        if (health != null) health.TakeDamage(Damage);
        yield return null;
    }

}

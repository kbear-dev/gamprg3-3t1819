using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffApplier : ThrowingCard
{
    public Buff Buff;

    protected override IEnumerator OnEffect()
    {
        if (Target == null) yield break;
        Target.health.TakeDamage(Damage);
        Target.GetComponent<BuffManager>().Register(Buff);
        yield return null;
    }
}

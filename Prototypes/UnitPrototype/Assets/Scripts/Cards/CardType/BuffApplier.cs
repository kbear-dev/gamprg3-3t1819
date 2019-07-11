using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffApplier : ThrowingCard
{
    public Buff Buff;

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

    protected override IEnumerator OnEffect(Collision2D collision)
    {
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy == null) yield break;
        enemy.health.TakeDamage(Damage);
        enemy.GetComponent<BuffManager>().Register(Buff);
        yield return null;
    }
}

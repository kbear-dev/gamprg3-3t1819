using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFire : ThrowingCard
{

    private CircleCollider2D AOECollider;

    private void Start()
    {
        AOECollider = GetComponent<CircleCollider2D>();
        AOECollider.enabled = false;
    }

    protected override IEnumerator OnEffect()
    {
        AOECollider.enabled = true;
        yield return null;
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Target == null) return;
        Target.health.TakeDamage(Damage);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDamage : Card
{
    public override IEnumerator DoEffect(Collision2D collision)
    {
        Health health = collision.collider.GetComponent<Health>();
        if (health != null) health.TakeDamage(Damage);
        yield return null;
        StartCoroutine(base.DoEffect(collision));
    }
}

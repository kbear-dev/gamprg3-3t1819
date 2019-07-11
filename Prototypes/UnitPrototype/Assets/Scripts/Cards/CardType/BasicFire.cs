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

    protected override IEnumerator OnEffect(Collision2D collision)
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
        Enemy enemy = collision.GetComponent<Enemy>();
        if(enemy != null) enemy.GetComponent<Health>().TakeDamage(Damage);
    }
}

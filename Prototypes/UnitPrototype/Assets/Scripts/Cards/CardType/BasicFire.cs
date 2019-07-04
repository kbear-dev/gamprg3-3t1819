using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFire : Card
{

    private CircleCollider2D AOECollider;

    private void Start()
    {
        AOECollider = GetComponent<CircleCollider2D>();
        AOECollider.enabled = false;
    }

    public override IEnumerator DoEffect(Collision2D collision)
    {
        AOECollider.enabled = true;
        yield return null;
        StartCoroutine(base.DoEffect(collision));
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

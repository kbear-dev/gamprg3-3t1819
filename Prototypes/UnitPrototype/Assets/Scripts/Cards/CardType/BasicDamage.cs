using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicDamage : Card
{
    public int Damage;
    public override void DoEffect(Enemy target)
    {
        Health health = target.GetComponent<Health>();
        if (health != null) health.TakeDamage(Damage);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null) DoEffect(enemy);
        DropCard();
        Destroy(gameObject);
    }
}

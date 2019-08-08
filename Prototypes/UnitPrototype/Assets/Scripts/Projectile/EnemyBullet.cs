using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Projectile
{
    public int BulletDamage;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        Destroy(gameObject, 3.0f);
    }

    protected override void ProjectileMove()
    {
        base.ProjectileMove();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle")) Destroy(gameObject);

        Player player = collision.gameObject.GetComponent<Player>();
        if (player == null) return;

        player.TakeDamage(BulletDamage);
        Destroy(gameObject);
    }
}

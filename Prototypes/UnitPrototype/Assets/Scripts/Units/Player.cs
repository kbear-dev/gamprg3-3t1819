using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
        if (isDead()) Destroy(gameObject);
    }
    
    protected override void Move()
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        float moveY = Input.GetAxis("Vertical") * moveSpeed;

        rb.velocity = new Vector2(moveX, moveY);
    }

    #region TESTING PURPOSES
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Enemy>() == null) return;

        TakeDamage(1);
        Debug.Log(health.currentHP);
    }
    #endregion
}

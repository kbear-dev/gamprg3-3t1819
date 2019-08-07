using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    // components of unit
    public Health health { get; set; }
    public Rigidbody2D rb { get; set; }
    
    // unit stats
    public int BaseHP;

    [Range(0.1f, 5.0f)]
    public float BaseMoveSpeed;
    public float moveSpeed { get; protected set; }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        health = GetComponent<Health>();
        rb = GetComponent<Rigidbody2D>();

        health.SetHP(BaseHP);
        moveSpeed = BaseMoveSpeed;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Move();
    }

    // base movement
    protected virtual void Move() { }

    // base take damage
    public void TakeDamage(int dmg)
    {
        health.TakeDamage(dmg);
        StartCoroutine(Flicker(gameObject, Color.red, 2.0f));
    }

    public virtual void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }

    // if unit is dead
    public bool isDead()
    {
        return health.currentHP <= 0;
    }

    #region UX STUFF
    protected IEnumerator Flicker(GameObject gO, Color flickerColor, float timer)
    {
        float t = timer;

        gO.GetComponent<SpriteRenderer>().color = flickerColor;
        while (t > 0)
        {
            t--;
            yield return new WaitForSeconds(0.1f);
        }

        if (gO != null)
            gO.GetComponent<SpriteRenderer>().color = Color.white;

        StopCoroutine("Flicker");
    }
    #endregion
}

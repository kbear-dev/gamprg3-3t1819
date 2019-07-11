using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : Enemy
{
    public GameObject Barrier;
    public int BaseBarrierHealth;
 
    public int barrier { get; set; }

    protected override void Start()
    {
        base.Start();
        barrier = BaseBarrierHealth;
    }

    protected override void Update()
    {
        base.Update();

        if (barrier <= 0)
        {
            if (Barrier != null) Destroy(Barrier);
            SetAISpeed(2.0f);
        }
    }

    protected override void isHitByCard(Collision2D collision)
    {
        if (collision.collider.gameObject.GetComponent<Card>() != null)
        {
            if (barrier > 0)
            {
                barrier--;
                StartCoroutine(Flicker(Barrier, Color.yellow, 2.0f));
                return; 
            }

            StartCoroutine(Flicker(gameObject, Color.red, 2.0f));
        }
    }
}

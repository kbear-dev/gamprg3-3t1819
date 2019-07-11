using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingCard : Card
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(ProjectileSpeed * Time.deltaTime, 0, 0);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(HandleCollision(collision));
    }

    IEnumerator HandleCollision(Collision2D collision)
    {
        yield return StartCoroutine(OnEffect(collision));
        yield return null;
        DropCard();
        Destroy(gameObject);
    }
}

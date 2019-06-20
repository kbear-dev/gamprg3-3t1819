using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    public Vector2 RandomMoveBounds;
    private Vector3 targetPosition;

    protected override void Start()
    {
        base.Start();
        SetTargetPosition(GetRandomLocation());
    }

    protected override void Update()
    {
        base.Update();
        if (isDead()) Destroy(gameObject);
    }

    protected override void Move()
    {
        RandomMove();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(RandomMoveBounds.x, RandomMoveBounds.y, 0));
        Gizmos.DrawLine(transform.position, targetPosition);
        Gizmos.DrawWireSphere(targetPosition, 0.5f);
    }

#region RANDOMIZED MOVEMENT
    // randomize movement in bounds
    public void RandomMove()
    {
        rb.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (transform.position == targetPosition)
        {
            SetTargetPosition(GetRandomLocation());
        }
    }

    // generate random location
    public Vector2 GetRandomLocation()
    {
        Vector2 randLoc = new Vector2();
        randLoc.x = Random.Range(-RandomMoveBounds.x / 2f, RandomMoveBounds.x / 2f);
        randLoc.y = Random.Range(-RandomMoveBounds.y / 2f, RandomMoveBounds.y / 2f);

        return randLoc;
    }
    
    // set target position
    public void SetTargetPosition(Vector3 pos)
    {
        targetPosition = pos;
        targetPosition.z = transform.position.z;
    }
#endregion
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Ranger : Enemy
{
    public GameObject BulletPrefab;
    public GameObject ShootingTarget;

    [Tooltip("Fire Interval in seconds")]
    public float FireInterval;

    private bool isTargetInRange;
    private AIPath ai;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        isTargetInRange = false;
        ai = GetComponent<AIPath>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void isHitByCard(Collision2D collision)
    {
        base.isHitByCard(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == ShootingTarget)
        {
            isTargetInRange = true;
            SetAISpeed(0.0f);
            StartCoroutine(ShootTarget());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == ShootingTarget)
        {
            isTargetInRange = false;
            SetAISpeed(moveSpeed);
            StopCoroutine(ShootTarget());
        }
    }

    public IEnumerator ShootTarget()
    {
        while (isTargetInRange)
        {
            Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, BulletPrefab.transform.position.z);
            Instantiate(BulletPrefab, spawnPos, Quaternion.AngleAxis(AngleToTarget(spawnPos), Vector3.forward));
            yield return new WaitForSeconds(FireInterval);
        }
    }

    public float AngleToTarget(Vector3 origin)
    {
        Vector3 distance = ShootingTarget.transform.position - origin;
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        return angle;
    }
}

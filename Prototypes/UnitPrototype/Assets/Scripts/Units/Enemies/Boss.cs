using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Enemy
{
    public Image HealthBar;
    public bool isPlayerInRange;
    public bool hasBulletHellStarted;

    public GameObject BulletHellPatternPrefab;
    public float FireInterval;

    private Coroutine bulletHellCoroutine;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        isPlayerInRange = false;
        hasBulletHellStarted = false;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        HealthBar.fillAmount = health.GetHpPercentage(true);
    }

    protected override void isHitByCard(Collision2D collision)
    {
        base.isHitByCard(collision);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() == null) return;
        isPlayerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() == null) return;
        isPlayerInRange = false;
    }

    public void StartBulletHell()
    {
        bulletHellCoroutine = StartCoroutine(BulletHell());
        hasBulletHellStarted = true;
    }

    public void StopBulletHell()
    {
        StopCoroutine(bulletHellCoroutine);
        hasBulletHellStarted = false;
    }

    private IEnumerator BulletHell()
    {
        Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, BulletHellPatternPrefab.transform.position.z);
        Instantiate(BulletHellPatternPrefab, spawnPos, Quaternion.identity);
        yield return new WaitForSeconds(FireInterval);
    }

    public float GetCurrentHealthPercent()
    {
        return health.GetHpPercentage(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Enemy
{
    public Image HealthBar;

    public bool isPlayerInRange { get; set; }
    public bool hasBulletHellStarted { get; set; }
    public bool isHealing { get; set; }

    public GameObject BulletHellPatternPrefab;

    private Coroutine bulletHellCoroutine;
    private Coroutine healingCoroutine;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        isPlayerInRange = false;
        hasBulletHellStarted = false;
        isHealing = false;
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

    #region FSM_BULLET

    public void StartBulletHell(float fireInterval)
    {
        bulletHellCoroutine = StartCoroutine(BulletHell(fireInterval));
        hasBulletHellStarted = true;
    }

    public void StopBulletHell()
    {
        StopCoroutine(bulletHellCoroutine);
        hasBulletHellStarted = false;
    }

    private IEnumerator BulletHell(float fireInterval)
    {
        while (isPlayerInRange)
        {
            Vector3 spawnPos = new Vector3(transform.position.x, transform.position.y, BulletHellPatternPrefab.transform.position.z);
            Instantiate(BulletHellPatternPrefab, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(fireInterval);
        }
    }

    #endregion

    #region FSM_RECUPERATION
    public void StartHealing(int healValue, float healInterval)
    {
        healingCoroutine = StartCoroutine(Recuperate(healValue, healInterval));
        isHealing = true;
    }

    public void StopHealing()
    {
        StopCoroutine(healingCoroutine);
        isHealing = false;
    }

    public IEnumerator Recuperate(int healValue, float healInterval)
    {
        while (isHealing)
        {
            health.Heal(healValue);
            yield return new WaitForSeconds(healInterval);
        }
    }
    #endregion

    public float GetCurrentHealthPercent()
    {
        return health.GetHpPercentage(false);
    }
}

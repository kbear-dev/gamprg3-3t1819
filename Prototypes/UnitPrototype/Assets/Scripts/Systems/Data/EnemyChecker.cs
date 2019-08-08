using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class EnemyChecker : MonoBehaviour
{
    public GameObject Gate;
    public List<Enemy> enemies;

    private int enemyCount;

    private void Start()
    {
        enemyCount = enemies.Count;

        foreach (var e in enemies)
        {
            e.OnDeath.AddListener(OnEnemyDeath);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("EnemyCount: " + enemyCount);
    }

    void DestroyGate()
    {
        Destroy(Gate);
    }

    void OnEnemyDeath()
    {
        enemyCount--;

        if (enemyCount <= 0)
        {
            DestroyGate();
        }
    }
}

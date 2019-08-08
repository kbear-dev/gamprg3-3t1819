using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class FireShield : Buff
{
    public float TickRate;
    public int Damage;
    public float TimeToDamage;
    public float Duration;


    private List<colEnemyData> trackedEnemies = new List<colEnemyData>();
    [SerializeField]
    private List<EnemyData> enemyData = new List<EnemyData>();

    public override IEnumerator Effect()
    {
        for(float x = 0; x < Duration; x += TickRate)
        {
            for(int i = 0; i< enemyData.Count; i++)
            {
                EnemyData data = enemyData[i];
                data.TimePassed += TickRate;

                if(data.TimePassed >= TimeToDamage)
                {
                    data.Enemy.health.TakeDamage(Damage);
                    enemyData.Remove(data);
                }
            }

            yield return new WaitForSeconds(TickRate);
        }

        buffEnded.Invoke(this);
        yield return null;
    }

    protected override IEnumerator Cleanup()
    {
        trackedEnemies.Clear();
        yield return null;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Enemy toAdd = collision.GetComponent<Enemy>();

        if (toAdd == null)
            return;
        if(!enemyData.Exists(s=>s.Enemy == toAdd))
        {
            EnemyData newData = new EnemyData(toAdd, 0);
            enemyData.Add(newData);
        }
    }

    [System.Serializable]
    class EnemyData
    {
        public EnemyData(Enemy enemy, float timePassed)
        {
            this.Enemy = enemy;
            this.TimePassed = timePassed;
        }

        public Enemy Enemy;
        public float TimePassed;
    }

    [System.Serializable]
    public struct colEnemyData
    {
        public Enemy collided;
        public float timePassed;

        public void IncreaseTime(float time)
        {
            timePassed += time;
        }
    }
}

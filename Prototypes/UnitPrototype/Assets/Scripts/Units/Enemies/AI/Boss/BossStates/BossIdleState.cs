using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IdleState", menuName = "States/Boss/IdleState")]
public class BossIdleState : BossState
{
    public float RetreatAtHealth;
     
    public override void Act()
    {
        boss.SetAISpeed(0);
    }

    public override State CheckStateChanges()
    {
        if (boss.GetCurrentHealthPercent() > RetreatAtHealth)
        {
            if (boss.isPlayerInRange)
            {
                return SwapState(0);
            }

            if (boss.hasBulletHellStarted) boss.StopBulletHell();
            return this;
        }
        else
        {
            return SwapState(1);
        }
    }
}

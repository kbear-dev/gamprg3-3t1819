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
        // if enough health
        if (boss.GetCurrentHealthPercent() > RetreatAtHealth)
        {
            // swap to attack state if player is in range
            if (boss.isPlayerInRange)
            {
                return SwapState(0);
            }

            // become idle if player is no longer in range
            if (boss.hasBulletHellStarted) boss.StopBulletHell();
            return this;
        }
        else
        {
            // swap to defense state if not enough health
            return SwapState(1);
        }
    }
}

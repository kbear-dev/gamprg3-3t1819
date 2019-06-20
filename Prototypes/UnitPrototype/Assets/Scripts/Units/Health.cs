using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHP { get; private set; }
    public int currentHP { get; private set; }

    public void Heal(int heal)
    {
        if (currentHP == maxHP) return;

        currentHP += heal;

        if (currentHP > maxHP) currentHP = maxHP;
    }

    public void TakeDamage(int dmg)
    {
        if (currentHP <= 0) return;

        currentHP -= dmg;
    }

    public float GetHpPercentage()
    {
        return (float)currentHP / maxHP * 100f;
    }

    public void SetHP(int hp)
    {
        maxHP = hp;
        currentHP = maxHP;
    }
}

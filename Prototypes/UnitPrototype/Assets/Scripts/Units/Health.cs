using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHP { get; private set; }

    [SerializeField]
    public int currentHP { get; private set; }
    public GameObject ShieldSprite;

    public bool isShielded;

    public void Heal(int heal)
    {
        if (currentHP == maxHP) return;

        currentHP += heal;

        if (currentHP > maxHP) currentHP = maxHP;
    }

    public void TakeDamage(int dmg)
    {
        if (currentHP <= 0) return;
        if(isShielded)
        {
            isShielded = false;
            ShieldSprite.SetActive(false);
        }
        else
            currentHP -= dmg;
    }

    public float GetHpPercentage(bool isDecimal)
    {
        float result = (float)currentHP / maxHP;
        return isDecimal ? result : result * 100f;
    }

    public void SetHP(int hp)
    {
        maxHP = hp;
        currentHP = maxHP;
    }
}

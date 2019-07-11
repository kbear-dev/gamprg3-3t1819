using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : Enemy
{
    public Image HealthBar;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
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
}

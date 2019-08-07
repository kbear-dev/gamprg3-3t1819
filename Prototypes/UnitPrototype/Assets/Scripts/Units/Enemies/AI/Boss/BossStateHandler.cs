using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateHandler : MonoBehaviour
{
    // put the default state here
    public BossState state;

    // get unit reference
    public Boss boss { get; set; }

    private void Start()
    {
        boss = GetComponent<Boss>();
    }

    // Update is called once per frame
    void Update()
    {
        state.boss = boss;
        state.Act();
        state = (BossState)state.CheckStateChanges(); 
    }
}

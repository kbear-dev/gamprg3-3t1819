﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfBuff : Card
{
    public Card Card;
    public Buff Buff;

    public override void OnThrow()
    {
        StartCoroutine(OnEffect());
    }

    protected override IEnumerator OnEffect()
    {
        Target = Caster;

        Caster.GetComponent<BuffManager>().Register(Buff);
        yield return null;
        Caster.GetComponent<CardThrow>().Deck.PoolCard(this);
    }

    private void OnEnable()
    {
        StartCoroutine(OnEffect());
    }
}

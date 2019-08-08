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
        GetComponent<SpriteRenderer>().enabled = false;

        Target = Caster;
        Buff.Target = Target;

        StartCoroutine(Caster.GetComponent<BuffManager>().Register(Buff));
        yield return null;
        //Caster.GetComponent<CardThrow>().Deck.AddCard(this);
        Caster.GetComponent<CardThrow>().Deck.RemoveCurrentCard();
    }
}


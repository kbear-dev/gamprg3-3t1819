using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfBuff : Card
{
    public Card Card;
    public Buff Buff;

    void Start()
    {
        StartCoroutine(OnEffect());
    }

    protected override IEnumerator OnEffect()
    {
        Target = Caster;
        //Card toAdd = Instantiate(Card);
        //Caster.GetComponent<CardThrow>().Deck.AddCard(toAdd);
        Caster.GetComponent<BuffManager>().Register(Buff);
        yield return null;
    }
}

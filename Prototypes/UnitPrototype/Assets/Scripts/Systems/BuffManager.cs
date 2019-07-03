﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BuffManager : MonoBehaviour
{
    private List<Buff> buffs = new List<Buff>();

    public void Register(Buff buff)
    {
        if(!buffs.Contains(buff)) buffs.Add(buff);
    }

    public void Remove(Buff buff)
    {
        buffs.RemoveAll(s => s == buff);
        buff.DestroyBuff();
    }

    public void ClearAllBuffs()
    {
        foreach (Buff buff in buffs) buff.DestroyBuff();
        buffs.Clear();
    }
}
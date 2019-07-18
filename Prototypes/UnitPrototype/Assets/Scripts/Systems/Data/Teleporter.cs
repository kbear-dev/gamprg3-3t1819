﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Teleporter : MonoBehaviour
{
    public UnityEvent OnEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnEnter.Invoke();
    }
}

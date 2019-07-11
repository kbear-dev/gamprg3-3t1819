using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float ProjectileVelocity;

    public Transform t;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        t = transform;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        ProjectileMove();
    }

    protected virtual void ProjectileMove()
    {
        t.Translate(ProjectileVelocity*Time.deltaTime, 0, 0);
    }
}

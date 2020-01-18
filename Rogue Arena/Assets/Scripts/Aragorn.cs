using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aragorn : Unit
{
    public Sword weapon;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();

        weapon = GetComponentInChildren<Sword>();
        speed = 10000;
        health = 100;
    }
}

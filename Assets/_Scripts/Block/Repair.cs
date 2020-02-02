using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SUPERLASER;

public class Repair : Block
{
    [SerializeField] private int healPerSec = 1;
    private Timer healTimer = new Timer();

    [NaughtyAttributes.ReadOnly]
    public Base targetBaseToHeal;

    private new void Update()
    {
        base.Update();

        if(targetBaseToHeal)
        {
            if(healTimer.TimeIsUp)
            {
                healTimer.SetTimer(1);
                targetBaseToHeal.Health += healPerSec;
            }
        }
    }
}

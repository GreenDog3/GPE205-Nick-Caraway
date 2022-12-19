using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class RapidfirePowerup : Powerup
{
    public float newTimeBetweenShots;
    public override void Apply(PowerupManager target)
    {
        Pawn targetPawn = target.GetComponent<Pawn>();
        if (targetPawn != null)
        {
            targetPawn.timeBetweenShots = newTimeBetweenShots;
        }
    }

    public override void Remove(PowerupManager target)
    {
        Pawn targetPawn = target.GetComponent<Pawn>();
        if (targetPawn != null)
        {
            targetPawn.timeBetweenShots = 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupManager : MonoBehaviour
{
    public List<Powerup> powerups;
    // Start is called before the first frame update
    void Start()
    {
        powerups = new List<Powerup>();
    }

    // Update is called once per frame
    void Update()
    {
        DecrementPowerupTimers();
    }

    public void Add(Powerup powerupToAdd)
    {   //Apply directly to forehead
        powerupToAdd.Apply(this);
        //Add to list of things we have applied directly to forehead
        powerups.Add(powerupToAdd);
    }

    public void Remove(Powerup powerupToRemove)
    {
        //removes the powerup
        powerupToRemove.Remove(this);
        //add it to the trash can
        powerups.Remove(powerupToRemove);
    }


    public void DecrementPowerupTimers()
    {
        List<Powerup> removedPowerupQueue = new List<Powerup>();
    //For each powerup we have, we need to decrease the duration until it runs out
        foreach (Powerup pu in powerups)
        {
            // Subtract the time that has passed from the duration
            pu.duration -= Time.deltaTime;
            // When there's no more duration, we can throw it away like an empty can
            if (pu.duration <= 0) 
            {
                removedPowerupQueue.Add(pu);
            }
        }

        foreach (Powerup powerup in removedPowerupQueue) 
        {
            Remove(powerup);
        }
    }
}
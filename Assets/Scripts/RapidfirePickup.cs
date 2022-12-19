using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidfirePickup : MonoBehaviour
{
    public RapidfirePowerup powerup;

    public void OnTriggerEnter(Collider other)
    {
        // Stores the PowerupManager of the other object, assuming it has one
        PowerupManager powerupManager = other.GetComponent<PowerupManager>();

        // If the other object has a PowerupController
        if (powerupManager != null) {
            // Add the powerup
            powerupManager.Add(powerup);

            // Destroy this pickup
            Destroy(gameObject);
        }
    }
}

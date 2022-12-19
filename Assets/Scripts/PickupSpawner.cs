using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    public GameObject pickupPrefab;
    public float spawnDelay;
    private float nextSpawnTime;
    private GameObject spawnedPickup;
    // Start is called before the first frame update
    void Start()
    {
        nextSpawnTime = Time.time + spawnDelay;
    }

    // Update is called once per frame
    void Update()
    {
        // If there's already a pickup, there's no point in spawning another
        if (spawnedPickup == null)
        {
            // My favorite part of the script was when PickupSpawner said "It's PickupSpawnerin' time!" and PickupSpawnered all over those guys.
            // What? It didn't say that?
            if (Time.time > nextSpawnTime)
            {
                // Spawn it and tell it to spawn again, but later
                spawnedPickup = Instantiate(pickupPrefab, transform.position, Quaternion.identity) as GameObject;
                nextSpawnTime = Time.time + spawnDelay;
            }
        }
        else
        {
            // It's like trying to sell someone something they already own. Just wait until a tank barrels through their home and destroys it, THEN sell them a new one.
            nextSpawnTime = Time.time + spawnDelay;
        }
    }
}

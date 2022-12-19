using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnSpawner : MonoBehaviour
{
    // Using Awake ensures that the spawn points are in the list before the GameManager tries to use them
    void Awake()
    {
        GameManager.instance.spawnLocations.Add(this.gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

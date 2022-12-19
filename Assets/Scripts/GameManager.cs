using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Game Manager instance
    public static GameManager instance;

    // Location of the Player Spawner
    public Transform playerSpawnTransform;
    public Transform enemySpawnTransform;
    public List<Transform> arenaWaypoints;
    public List<Transform> spawnLocations;

    // Lists
    public List<PlayerController> players;
    public List<AIController> enemies;

    // Prefabs
    public GameObject tankPawnPrefab;
    public GameObject playerControllerPrefab;
    public GameObject goombaControllerPrefab;
    public GameObject guardControllerPrefab;
    public GameObject sniperControllerPrefab;
    public GameObject leeroyControllerPrefab;

    public GameObject goombaTankPawnPrefab;
    public GameObject guardTankPawnPrefab;
    public GameObject sniperTankPawnPrefab;
    public GameObject leeroyTankPawnPrefab;

   
    void Awake()
    {
        if (instance == null)
        { //If there is no GameManager, create it
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        { //If there is a GameManager, THERE CAN ONLY BE ONE!
            Destroy(gameObject);
        }
    }

    void Start()
    {
        //spawns a player when the game begins. Otherwise, it wouldn't be much of a game.
        SpawnPlayer();

        //Spawns one of each enemy at random spawn points
        SpawnGoomba();
        SpawnGuard();
        SpawnSniper();
        SpawnLeeroy();
    }

    public void SimulateStart()
    {
        //spawns a player when the game begins. Otherwise, it wouldn't be much of a game.
        SpawnPlayer();

        //Spawns one of each enemy at random spawn points
        SpawnGoomba();
        SpawnGuard();
        SpawnSniper();
        SpawnLeeroy();
    }

    // Update is called once per frame
    void Update()
    {
        //This spawns a Goomba
        if (Input.GetKeyDown(KeyCode.G))
        {
            enemySpawnTransform = RandomSpawnPoint();
            SpawnGoomba();
        }
        //This spawns a Guard
        if (Input.GetKeyDown(KeyCode.H))
        {
            enemySpawnTransform = RandomSpawnPoint();
            SpawnGuard();
        }
        //This spawns a Sniper
        if (Input.GetKeyDown(KeyCode.J))
        {
            enemySpawnTransform = RandomSpawnPoint();
            SpawnSniper();
        }
        //This spawns Leeroy
        if (Input.GetKeyDown(KeyCode.K))
        {
            enemySpawnTransform = RandomSpawnPoint();
            SpawnLeeroy();
        }

        if (Input.GetKeyDown(KeyCode.O))
        {
            SimulateStart();
        }

        if (players.Count == 0)
        {
            SpawnPlayer();
        }


    }

    public void SpawnPlayer()
    {
        playerSpawnTransform = RandomSpawnPoint();
    
       // Spawn the Player Controller at (0,0,0) with rotation
       GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

       // Spawn the Pawn and connect it to the Controller
       GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation);

        // Get the Player Controller component and Pawn component
       Controller newController = newPlayerObj.GetComponent<Controller>();
       Pawn newPawn = newPawnObj.GetComponent<Pawn>();

       // Hook 'em up!
       newController.pawn = newPawn;
    }

    public void SpawnGoomba()
    {
        enemySpawnTransform = RandomSpawnPoint();
        // Spawn Goomba AI Controller at origin
        GameObject newGoombaObj = Instantiate(goombaControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        // Spawn Goomba Tank and connect it to the controller
        GameObject newPawnObj = Instantiate(goombaTankPawnPrefab, enemySpawnTransform.position, enemySpawnTransform.rotation);

        //Get Goomba Controller component and Pawn component
        Controller newController = newGoombaObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        //throw them IN THE POT!!!!!! STIR!!!!! *blender noises*
        newController.pawn = newPawn;
    }

    public void SpawnGuard()
    {
        enemySpawnTransform = RandomSpawnPoint();
        // Spawn Guard AI Controller at origin
        GameObject newGuardObj = Instantiate(guardControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        // Spawn Guard Tank and connect it to the controller
        GameObject newPawnObj = Instantiate(guardTankPawnPrefab, enemySpawnTransform.position, enemySpawnTransform.rotation);

        //Get Guard Controller component and Pawn component
        Controller newController = newGuardObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        //blender noises, continued
        newController.pawn = newPawn;
        newGuardObj.GetComponent<AIController_Guard>().waypoints = arenaWaypoints;
    }

    public void SpawnSniper()
    {
        enemySpawnTransform = RandomSpawnPoint();
        // Spawn Sniper AI Controller at origin
        GameObject newSniperObj = Instantiate(sniperControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        // Spawn Sniper Tank and connect it to the controller
        GameObject newPawnObj = Instantiate(sniperTankPawnPrefab, enemySpawnTransform.position, enemySpawnTransform.rotation);

        //Get Sniper Controller component and Pawn component
        Controller newController = newSniperObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        //slap 'em together
        newController.pawn = newPawn;
    }

    public void SpawnLeeroy()
    {
        enemySpawnTransform = RandomSpawnPoint();
        // Spawn Leeroy AI Controller at origin
        GameObject newLeeroyObj = Instantiate(leeroyControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        // Spawn Leeroy Tank and connect it to the controller
        GameObject newPawnObj = Instantiate(leeroyTankPawnPrefab, enemySpawnTransform.position, enemySpawnTransform.rotation);

        //Get Leeroy Controller component and Pawn component
        Controller newController = newLeeroyObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        //I think I still have a roll of flex tape around here somewhere...
        newController.pawn = newPawn;
    }
    public Transform RandomSpawnPoint()
    {
        int randomIndex = Random.Range(0, spawnLocations.Count);
        return spawnLocations[randomIndex];
    }
}
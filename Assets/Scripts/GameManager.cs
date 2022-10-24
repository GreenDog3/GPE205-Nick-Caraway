using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<PlayerController> players;
    public GameObject pawnPrefab;

   
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
        SpawnPlayer(0);
    }

    // Update is called once per frame
    void Update()
    {
        //This spawns a new player
        if (Input.GetKeyDown(KeyCode.P))
        {
            SpawnPlayer(1);
        }
    }

    public void SpawnPlayer(int playerNumber)
    {
        GameObject newPawn = Instantiate(pawnPrefab, Vector3.zero, Quaternion.identity);
        Pawn newPawnScript = newPawn.GetComponent<Pawn>();
        if (players.Count > playerNumber)
            {
                LinkPawnAndController(newPawnScript, players[playerNumber]);
            }
    }

    public void LinkPawnAndController(Pawn pawn, Controller controller)
    {
        pawn = pawn;
        controller = controller;
    }
}

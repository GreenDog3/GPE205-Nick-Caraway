using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] gridPrefabs;
    public int rows;
    public int cols;
    public int mapSeed;
    public float roomWidth = 50.0f;
    public float roomHeight = 50.0f;
    private Room[,] grid;
    public enum MapType { Random, MapOfTheDay, Seed };
    public MapType type;

    public GameObject RandomRoomPrefab() 
    {
        return gridPrefabs[Random.Range(0, gridPrefabs.Length)];
    }

    public void GenerateMap()
    {
        //seed rng based on design choice
        if (type == MapType.Random)
        {
            //seed rng randomly
            System.DateTime time;
            time = System.DateTime.Now;
            Random.InitState((int)time.Ticks);
        }
        else if (type== MapType.Seed)
        {
            //seed rng with a set number
            Random.InitState(mapSeed);
        }
        else
        {
            //seed rng for map of the day
            Random.InitState((int)System.DateTime.Today.Ticks);
        }
        grid = new Room[cols, rows];

        for(int currentRow = 0; currentRow < rows ; currentRow++)
        {
            for(int currentCol = 0; currentCol < cols ; currentCol++)
            {   //Find where these rooms are going to spawn
                float xPostion = roomWidth*currentCol;
                float zPosition = roomHeight*currentRow;
                Vector3 newPosition = new Vector3 (xPostion, 0.0f, zPosition);
                //Spawn the rooms in the right locations
                GameObject tempRoomObj = Instantiate (RandomRoomPrefab(), newPosition, Quaternion.identity) as GameObject;
                //Set its parent
                tempRoomObj.transform.parent = this.transform;
                //Give it a name
                Room tempRoom = tempRoomObj.GetComponent<Room>();
                //add it to The List except it's an array, not a list
                grid[currentCol,currentRow] = tempRoom;

                // Open the doors
                // If we are on the bottom row, open the north door
                if (currentRow == 0) 
                {
                    tempRoom.doorNorth.SetActive(false);
                } 
                else if ( currentRow == rows-1 )
                {
                    // Otherwise, if we are on the top row, open the south door
                    tempRoom.doorSouth.SetActive(false);
                }
                else 
                {
                    // Otherwise, we are in the middle, so open both doors
                    tempRoom.doorNorth.SetActive(false);
                    tempRoom.doorSouth.SetActive(false);
                }

                //If we are on the left, open the right door
                if (currentCol == 0)
                {
                    tempRoom.doorEast.SetActive(false);
                }
                else if (currentCol == cols-1)
                {
                    //If we are on the right, open the left door
                    tempRoom.doorWest.SetActive(false);
                }
                else
                {
                    //If neither of those are true, we are in the middle
                    tempRoom.doorEast.SetActive(false);
                    tempRoom.doorWest.SetActive(false);
                }
            }
        }
    }


    void Awake()
    {
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

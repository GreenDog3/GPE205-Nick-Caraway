using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Controller
{
    [Header("Keyboard Controls")]
    public KeyCode moveForward;
    public KeyCode moveBackward;
    public KeyCode turnRight;
    public KeyCode turnLeft;
    public KeyCode shoot;
    // Start is called before the first frame update
    void Start()
    {
        //adds itself to the players list
        GameManager.instance.players.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (pawn != null)
        {
            MakeDecisions();
        }
        else
        {
            Destroy(this);
        }
    }

    public override void MakeDecisions() //side note, why is it so hard to spell decisions? Is that just me?
    {
        if(Input.GetKey(moveForward)) //these blocks of code remind me of making a Scratch project. Just replacing the blocks with typing it out myself.
        {
            pawn.MoveForward();
        }
        if(Input.GetKey(moveBackward))
        {
            pawn.MoveBackward();
        }
         if(Input.GetKey(turnRight))
        {
            pawn.TurnRight();
        }
         if(Input.GetKey(turnLeft))
        {
            pawn.TurnLeft();
        }
         if(Input.GetKey(shoot))
        {
            pawn.Shoot();
        }
    }
    public void OnDestroy()
    {
        GameManager.instance.players.Remove(this);
    }
}

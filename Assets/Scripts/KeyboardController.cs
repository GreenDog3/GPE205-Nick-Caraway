using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : Controller
{
    public KeyCode moveForward;
    public KeyCode moveBackward;
    public KeyCode turnRight;
    public KeyCode turnLeft;
    public KeyCode shoot;


    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        MakeDecisions();
    }

    public override void MakeDecisions()
    {
        if (Input.GetKey(moveForward))
        {
            pawn.MoveForward();
        }
        if (Input.GetKey(moveBackward))
        {
            pawn.MoveBackward();
        }
        if (Input.GetKey(turnRight))
        {
            pawn.TurnRight();
        }
        if (Input.GetKey(turnLeft))
        {
            pawn.TurnLeft();
        }
        if (Input.GetKeyDown(shoot))
        {
            pawn.Shoot();
        }
    }
    public override void MoveForward()
    {

    }
}

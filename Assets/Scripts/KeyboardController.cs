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
            Debug.Log("Forward");
        }
        if (Input.GetKey(moveBackward))
        {
            Debug.Log("Backward");
        }
        if (Input.GetKey(turnRight))
        {
            pawn.TurnRight();
        }
        if (Input.GetKey(turnLeft))
        {
            Debug.Log("CCW");
        }
        if (Input.GetKeyDown(shoot))
        {
            Debug.Log("pew");
        }
    }
    public override void MoveForward()
    {

    }
}

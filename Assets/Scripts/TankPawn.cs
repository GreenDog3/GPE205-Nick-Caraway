using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{
    public float turnSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void MoveForward()
    {
        base.MoveForward();
    }

    public override void MoveBackward()
    {
        base.MoveBackward();
    }

    public override void TurnRight()
    {
        mover.Turn(turnSpeed);
        base.TurnRight();
    }

    public override void TurnLeft()
    {
        mover.Turn(-turnSpeed);
        base.TurnLeft();
    }
}

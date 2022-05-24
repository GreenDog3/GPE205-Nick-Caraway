using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{

    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Mover>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void MoveForward()
    {
        mover.MoveForward(moveSpeed);
        base.MoveForward();
    }

    public override void MoveBackward()
    {
        mover.MoveForward(-moveSpeed);
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

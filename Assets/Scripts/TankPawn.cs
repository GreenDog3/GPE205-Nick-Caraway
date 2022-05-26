using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{

    public GameObject bulletPrefab;
    public Shooter shooter;
    public float shootForce;
    public float damageDone;
    public Vector3 shootOffset;
    


    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();
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

    public override void Shoot()
    {
        shooter.Shoot(bulletPrefab, shootForce, damageDone, shootOffset, this);
    }
}

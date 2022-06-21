using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{

    public GameObject bulletPrefab;
    public Shooter shooter;
    public float shootForce;
    public float damageDone;
    public Transform shootPoint;
    private float nextShootTime;
    public float timeBetweenShots;


    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Mover>();
        shooter = GetComponent<Shooter>();

        //set next shoot time
        nextShootTime = Time.time + timeBetweenShots;
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
        if (Time.time >= nextShootTime)
        {
            //if yes, shoot
            shooter.Shoot(bulletPrefab, shootForce, damageDone, shootPoint, this);
            //set new time
            nextShootTime = Time.time + timeBetweenShots;

        }
        
    }

    public override void TurnTowards( Vector3 targetPosition )
    {
        //find the vector to the target from our location
        Vector3 vectorToTargetPosition = targetPosition - transform.position;
        //find quaternion needed to look at that vector
        Quaternion look = Quaternion.LookRotation(vectorToTargetPosition, transform.up);
        //change rotation to be slightly down that quaternion
        transform.rotation = Quaternion.RotateTowards(transform.rotation, look, turnSpeed*Time.deltaTime);
    }
}

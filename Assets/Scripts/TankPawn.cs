using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{

    
    // Start is called before the first frame update
    public override void Start()
    {
       base.Start();
        // TODO: write funny comment here
        nextShootTime = Time.time + timeBetweenShots;
    }

    public override void Update() 
    {
        base.Update();
        if (noise.noiseDistance>=5)
            {
                noise.noiseDistance = 5;
            }
    }

    
    public override void MoveForward()
    { 
        //Forwards is just positive backwards.
        mover.Move(transform.forward, moveSpeed);
        noise.MakeNoise(10);
    }

    public override void MoveBackward()
    { //Backwards is just negative forwards.
        mover.Move(transform.forward, -moveSpeed);
        noise.MakeNoise(10);
    }

    public override void TurnRight()
    { //I don't have anything funny to say for turning right. I just like typing comments because it means I can pretend to work harder without having to actually put in more effort. Besides, it's better than under-commenting.
        mover.Turn(turnSpeed);
        noise.MakeNoise(5);
    }

    public override void TurnLeft()
    { //I guess "TurnCounterclockwise" would be more accurate, but that's way too many letters for me to type. Ignore that this file will probably end up more comment than code by the end of this.
        mover.Turn(-turnSpeed);
        noise.MakeNoise(5);
    }

    public override void Shoot()
    { //We must not shoot until we are ready!
        if (Time.time >= nextShootTime)
        {
            //If it is shoot time, SHOOT!
            shooter.Shoot(bulletPrefab, shootForce, damageDone, shootPoint, this);
            noise.MakeNoise(20);
            //When will we be ready to shoot again?
            nextShootTime = Time.time + timeBetweenShots;
        }
    }

    public override void TurnTowards(Vector3 targetPosition)
    {
        //Find the vector from where we are to where we want to be (the target)
        Vector3 vectorToTargetPosition = targetPosition - transform.position;
        //Find the quaternion that lets us look at the vector
        Quaternion look = Quaternion.LookRotation(vectorToTargetPosition, transform.up);
        //Rotate to slightly down the quaternion
        transform.rotation = Quaternion.RotateTowards(transform.rotation, look, turnSpeed*Time.deltaTime);
    }

    public override void TurnAway(Vector3 targetPosition)
    {
        //Find the vector from where we are to where we don't want to be (the target)
        Vector3 vectorToTargetPosition = targetPosition - transform.position;
        //Find the quaternion that lets us look at the negative vector
        Quaternion look = Quaternion.LookRotation(-vectorToTargetPosition, transform.up);
        //Rotate to slightly down the quaternion
        transform.rotation = Quaternion.RotateTowards(transform.rotation, look, turnSpeed*Time.deltaTime);
    }
}
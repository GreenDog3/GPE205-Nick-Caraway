using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankPawn : Pawn
{

    
    // Start is called before the first frame update
    void Start()
    {
       base.Start();
        // TODO: write funny comment here
        nextShootTime = Time.time + timeBetweenShots;
    }

    public override void Update() 
    {
        base.Update();
    }

    
    public override void MoveForward()
    { 
        Debug.Log("Moving Forward");
        //Forwards is just positive backwards.
        mover.Move(transform.forward, moveSpeed);
    }

    public override void MoveBackward()
    { //Backwards is just negative forwards.
        mover.Move(transform.forward, -moveSpeed);
    }

    public override void TurnRight()
    { //I don't have anything funny to say for turning right. I just like typing comments because it means I can pretend to work harder without having to actually put in more effort. Besides, it's better than under-commenting.
        mover.Turn(turnSpeed);
    }

    public override void TurnLeft()
    { //I guess "TurnCounterclockwise" would be more accurate, but that's way too many letters for me to type. Ignore that this file will probably end up more comment than code by the end of this.
        mover.Turn(-turnSpeed);
    }

    public override void Shoot()
    { //We must not shoot until we are ready!
        if (Time.time >= nextShootTime)
        {
            //If it is shoot time, SHOOT!
            shooter.Shoot(bulletPrefab, shootForce, damageDone, shootPoint, this);
            //When will we be ready to shoot again?
            nextShootTime = Time.time + timeBetweenShots;
        }
    }
}
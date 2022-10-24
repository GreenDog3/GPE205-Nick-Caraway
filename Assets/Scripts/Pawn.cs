using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public GameObject bulletPrefab;
    public Shooter shooter;
    public Mover mover;
    public float shootForce;
    public float damageDone;
    public Transform shootPoint;
    public float nextShootTime;
    public float timeBetweenShots;

    // Start is called before the first frame update
   public virtual void Start()
    {
         mover = GetComponent<Mover>();
         shooter = GetComponent<Shooter>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
        
    }

    public virtual void MoveForward()
    {

    }

    public virtual void MoveBackward()
    {

    }

    public virtual void TurnLeft()
    {

    }

    public virtual void TurnRight()
    {

    }

    public virtual void Shoot()
    {
        
    }
}

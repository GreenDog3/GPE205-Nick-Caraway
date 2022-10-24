using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : Mover
{
    private Rigidbody rigidbodyComponent;
    // Start is called before the first frame update
    void Start()
    {
        //loading the component as a suprise tool that will help us later
        rigidbodyComponent = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Move(Vector3 direction, float speed)
    { //Moves the tank forward at a certain speed per second
        Vector3 moveVector = direction.normalized * speed * Time.deltaTime;
        rigidbodyComponent.MovePosition(rigidbodyComponent.position + moveVector);
    }

    public override void Turn(float speed)
    { //Turns the tank at a certain speed per second
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}

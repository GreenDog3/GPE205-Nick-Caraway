using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : Mover
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void MoveForward(float speed)
    {
        
    }

    public override void Turn(float speed)
    {
        transform.Rotate(0, speed, 0);
    }
}

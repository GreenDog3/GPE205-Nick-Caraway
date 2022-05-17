using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardController : Controller
{
    public KeyCode moveForward;
    public KeyCode moveBackward;
    public KeyCode turnClockwise;
    public KeyCode turnCounterclockwise;


    // Start is called before the first frame update
    public override void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        if(Input.GetKey(moveForward))
        {
            Debug.Log("Forward");
        }
    }
}

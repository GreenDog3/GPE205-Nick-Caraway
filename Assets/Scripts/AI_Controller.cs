using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AI_Controller : Controller
{
    public enum AIStates {Idle, Chase, Attack, Flee, ChooseTarget};
    public AIStates currentState;
    public float timeEnteredCurrentState;
    public GameObject AITarget;

    public virtual void ChangeState(AIStates newState)
    {
        //set the time that we entered the new state
        timeEnteredCurrentState = Time.time;
        //change to the new state
        currentState = newState;

    }

    public virtual void DoIdleState()
    {
        //Standing here, i am standing here, i am standing here, and i am standing he-eere
    }

    public virtual void DoChaseState()
    {

        // TODO: add max speed to pawns and set this ai's speed to the max

        //*play Run! from deltarune here*
        Chase(AITarget);
    
    }

    public virtual void DoAttackState()
    {
        //chase player
        //shoot player
    }

    public virtual void DoChangeTargetState()
    {
        AITarget = GameManager.instance.players[0].pawn.gameObject;
    }

    public virtual void Chase(GameObject chaseTarget)
    {
        if(chaseTarget != null)
        {
            //turn toward target
            pawn.TurnTowards(chaseTarget.transform.position);
            //move forward
            pawn.MoveForward();
        }
        else
        {
            Debug.Log("Null target!");
        }
        
    }

    public virtual bool IsTimePassed (float amountOfTime)
    {
        if (Time.time - timeEnteredCurrentState >= amountOfTime)
        {
            return true;
        }
        return false;
    }
}

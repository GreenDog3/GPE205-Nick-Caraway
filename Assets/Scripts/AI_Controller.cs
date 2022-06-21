using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AI_Controller : Controller
{
    public enum AIStates {Idle, Chase, Attack, Flee, ChooseTarget, Patrol};
    public AIStates currentState;
    public float timeEnteredCurrentState;
    public GameObject AITarget;
    public List<Transform> waypoints;
    public int currentWaypoint;
    //sense data
    public float hearingRadius;
    public float fieldOfView;
    public float viewDistance;


    public virtual void ChangeState(AIStates newState)
    {
        //set the time that we entered the new state
        timeEnteredCurrentState = Time.time;
        //change to the new state
        currentState = newState;

    }

    public virtual void DoPatrolState()
    {
        Vector3 tempTargetLocation = waypoints[currentWaypoint].position;
        //move to current waypoint
        tempTargetLocation = new Vector3(tempTargetLocation.x, pawn.transform.position.y, tempTargetLocation.z);
        Chase(tempTargetLocation);
        //go to next waypoint if there
        if (Vector3.Distance(pawn.transform.position, tempTargetLocation) <= 1)
        {
            currentWaypoint++;
        }
        //once list exhausted, go back to first waypoint
        if (currentWaypoint >= waypoints.Count)
        {
            //go back to the first
            currentWaypoint = 0;
        }
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
            Chase(chaseTarget.transform.position);
        }
        else
        {
            Debug.Log("Null target!");
        }
        
    }

    public virtual void Chase(Transform chaseTarget)
    {
        Chase(chaseTarget.gameObject);
    }

    public virtual void Chase ( Controller chaseTarget)
    {
        Chase(chaseTarget.pawn.gameObject);
    }

    public virtual void Chase(Vector3 chaseTarget)
    {
        if (chaseTarget != null)
        {
            //turn toward target
            pawn.TurnTowards(chaseTarget);
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

    public virtual bool IsCanHear(GameObject target)
    {

        //Get Noisemaker component
        Noisemaker targetNoisemaker = target.GetComponent<Noisemaker>();
        //If it existn't
        if (targetNoisemaker == null)
        {
            //no sound, return false
            return false;
        }
        else //if it existn'tn't
        {
            //check if the distance between objects is less than the sum of two radii
            float sumOfRadii = targetNoisemaker.noiseDistance + hearingRadius;
            if (Vector3.Distance(target.transform.position, pawn.transform.position) <= sumOfRadii)
            {
                //if yes, return true
                return true;
            }
            else
            {
                //if no, return false
                return false;
            }
        }
    }
        
        public virtual bool IsCanSee(GameObject target)
    {
        //check if target is in field of view
        Vector3 vectorToTarget = target.transform.position - pawn.transform.position;
        float angleToTarget = Vector3.Angle(pawn.transform.forward, vectorToTarget);
        if (angleToTarget > fieldOfView)
        {
            return false;
        }
        
        //check if target is in line of sight
        Ray tempRay = new Ray(pawn.transform.position, vectorToTarget);
        RaycastHit hitInfo;
        if (Physics.Raycast(tempRay, out hitInfo, viewDistance))
        {
            //check if the thing we hit is the thing we want to hit
            if (hitInfo.collider.gameObject == target)
            {
                //we can see it
                return true;
            }
            else
            {
                //we've been blocked like in tetris
                return false;
            }
        }
        return false;



        
    }

    }

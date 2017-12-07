using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour {

    private NavMeshAgent agent;
    public Transform[] destinationPoints;
    private Transform goal;
    private int currentGoal = 0;
    private bool chase = false;

	// Use this for initialization
	void Start ()
    {
        goal = destinationPoints[0];
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if(Input.GetKeyDown(KeyCode.A))
            
        agent.SetDestination(goal.position);


		if(Vector3.Distance(transform.position, goal.position) < 1.0f)
        {
            if(goal == destinationPoints[currentGoal])
            {
                if (currentGoal == destinationPoints.Length - 1)
                    currentGoal = 0;
                else
                    currentGoal++;
                goal = destinationPoints[currentGoal];
            }
        }
	}
}

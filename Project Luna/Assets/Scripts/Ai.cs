using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ai : MonoBehaviour {

    private NavMeshAgent agent;
    public Transform[] destinationPoints;
    [HideInInspector]
    public Vector3 goal;
    private int currentGoal = 0;
    private bool chase = false;
    private bool moving = true;
    private float timer = 0;
    public float cd = 15;
    [HideInInspector]
    public Detection playerDetection;
    private float lookDegrees = 0;
    private bool gate = true;

    // Use this for initialization
    void Start ()
    {
        goal = destinationPoints[0].position;
        agent = GetComponent<NavMeshAgent>();

        playerDetection = GameObject.FindGameObjectWithTag("Player").GetComponent<Detection>();
	}

    // Update is called once per frame
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.A))

        agent.SetDestination(goal);

        if (!chase)
        {
            if (Vector3.Distance(transform.position, goal) < 1.0f)
            {
                if (goal == destinationPoints[currentGoal].position || goal == playerDetection.pos)
                {

                    if (moving)
                        StartCoroutine(CoolDown());

                    if (!moving)
                    {
                        if (gate)
                        {
                            lookDegrees += 1 * Time.deltaTime;
                            if (lookDegrees >= 1.3f)
                                gate = false;
                        }

                        else if (!gate)
                        {
                            lookDegrees -= 1 * Time.deltaTime;
                            if (lookDegrees <= -1.3f)
                                gate = true;
                        }

                        transform.Rotate(transform.rotation.x, transform.rotation.y + lookDegrees, transform.rotation.z);
                    }
                }
            }
        }
    

        else if (chase)
        {
            //Check if the player is walking again
            if (!playerDetection.collider.enabled)
            {
                
                chase = false;
                //Set the new goal to where the player was last heard running
                goal = playerDetection.pos;
                //StartCoroutine(CoolDown());
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        //Check if ai walks in the sphere collider when the player is running
        if (other.gameObject.tag == "Player")
        {
            gameObject.GetComponent<NavMeshAgent>().speed = 6;
            //Set new goal to players position
            goal = other.gameObject.transform.position;
            chase = true;
        }
    }


    public IEnumerator CoolDown()
    {
        if (gameObject.GetComponent<NavMeshAgent>().speed >= 6)
            gameObject.GetComponent<NavMeshAgent>().speed = 3.5f;

        moving = false;
        while(timer <= cd)
        {
            timer += Time.deltaTime;

            yield return 0;
        }

        if (currentGoal == destinationPoints.Length - 1)
            currentGoal = 0;
        else
            currentGoal++;

        goal = destinationPoints[currentGoal].position;

        moving = true;

        timer = 0;
        yield return 0;
    }
}

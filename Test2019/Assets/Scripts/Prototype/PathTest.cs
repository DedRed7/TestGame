using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathTest : MonoBehaviour
{
    public PathPoints path;
    public PlayerState PlayerState;
    private int destPoint = 0;
    private NavMeshAgent agent;
    private Vector3 nextPoint;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GotoNextPoint(path.points[destPoint]);
    }
    
    void Update()
    {
        // Choose the next destination point when the agent gets
        // close to the current one.
        //if (!agent.pathPending && agent.remainingDistance < 0.5f)
        if (!agent.pathPending && Vector3.Distance(transform.position, nextPoint) < 1f)
        {
            destPoint = (destPoint + 1) % path.points.Count;
            GotoNextPoint(path.points[destPoint]);
        }
    }
    
    public void GotoNextPoint(Vector3 destination)
    {
        PlayerState.autoRoaming = true;
        
        // Returns if no points have been set up
        if (path.points.Count == 0)
            return;

        // Set the agent to go to the currently selected destination.
        agent.destination = destination;
        nextPoint = destination;

        // Choose the next point in the array as the destination,
        // cycling to the start if necessary.
        
    }
}

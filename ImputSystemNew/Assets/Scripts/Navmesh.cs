using UnityEngine;
using UnityEngine.AI;

public class Navmesh : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public Transform[] waypoints;

    private void Update()
    {
        // Pursuit();
        WayPatrol();
        // RandomPatrol();
    }

    void Pursuit()
    {
        if (player != null)
        {
            agent.stoppingDistance = 6f;
            agent.SetDestination(player.position);
            transform.LookAt(player);
        }
    }

    void WayPatrol()
    {
        if (waypoints.Length != 0 && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            int randomIndex = Random.Range(0, waypoints.Length);
            agent.SetDestination(waypoints[randomIndex].position);
        }
    }

    void RandomPatrol()
    {
        
    }
}
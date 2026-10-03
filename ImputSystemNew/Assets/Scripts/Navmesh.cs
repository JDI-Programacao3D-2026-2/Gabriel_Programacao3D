using UnityEngine;
using UnityEngine.AI;

public class Navmesh : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public Transform[] waypoints;
    public float baseSpeed;

    public enum EnemyState
    {
        WayPatrol,
        RandomPatrol,
        FurtivePatrol,
        Pursuit
    }

    public EnemyState currentState = EnemyState.WayPatrol;
    public LayerMask layerMask;

    private void Update()
    {
        FiniteStateMachine();
    }

    public void ChangeState(EnemyState newState)
    {
        currentState = newState;
    }

    void FiniteStateMachine()
    {
        switch (currentState)
        {
            case EnemyState.WayPatrol:
                WayPatrol();
                break;
            case EnemyState.RandomPatrol:
                RandomPatrol();
                break;
            case EnemyState.Pursuit:
                Pursuit();
                break;
            case EnemyState.FurtivePatrol:
                FurtivePatrol();
                break;
            default:
                break;
        }

        if (currentState != EnemyState.FurtivePatrol)
        {
            if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 20, layerMask))
            {
                ChangeState(EnemyState.Pursuit);
            }
            else
            {
                ChangeState(EnemyState.WayPatrol);
            }
        }
        else
        {
            if (Vector3.Distance(transform.position, player.position) >= 20f)
            {
                ChangeState(EnemyState.WayPatrol);
            }
        }
    }

    void Pursuit()
    {
        if (player != null)
        {
            agent.speed = baseSpeed;
            agent.stoppingDistance = 6f;
            agent.SetDestination(player.position);
            transform.LookAt(player);
        }
    }

    void WayPatrol()
    {
        agent.stoppingDistance = 0f;
        agent.speed = baseSpeed;
        if (waypoints.Length != 0 && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            int randomIndex = Random.Range(0, waypoints.Length);
            agent.SetDestination(waypoints[randomIndex].position);
        }
    }

    void RandomPatrol()
    {
        
    }

    void FurtivePatrol()
    {
        agent.stoppingDistance = 0f;
        agent.speed = baseSpeed * 1.75f;
        if (waypoints.Length != 0 && !agent.pathPending && agent.remainingDistance < 0.5f)
        {
            int randomIndex = Random.Range(0, waypoints.Length);
            agent.SetDestination(waypoints[randomIndex].position);
        }
    }

 
}
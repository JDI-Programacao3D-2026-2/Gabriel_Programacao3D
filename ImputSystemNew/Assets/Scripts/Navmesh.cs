using UnityEngine;
using UnityEngine.AI;

public class Navmesh : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public Transform[] waypoints;
    public float baseSpeed;
    public float losePlayerDistance = 5f;

    public enum EnemyState
    {
        WayPatrol,
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
            case EnemyState.Pursuit:
                Pursuit();
                break;
            default:
                break;
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

            float dist = Vector3.Distance(transform.position, player.position);
            if (dist >= losePlayerDistance)
            {
                agent.ResetPath();
                ChangeState(EnemyState.WayPatrol);
            }
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
        SearchPlayer();
    }

    void SearchPlayer()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, 10f, layerMask) || Vector3.Distance(transform.position, player.position) <= 5f)
        {
            ChangeState(EnemyState.Pursuit);
            CallBackup();
        }
    }

    void CallBackup()
    {
        Navmesh[] todosInimigos = FindObjectsByType<Navmesh>();
        foreach (Navmesh aliado in todosInimigos)
        {
            float dist = Vector3.Distance(transform.position, aliado.transform.position);
            if (dist < 5f)
            {
                aliado.ChangeState(EnemyState.Pursuit);
            }
        }
    }

    void RunAway()
    {
        // Chamada quando o inimigo estiver com "pouca vida"
        float maxDist = 0f;
        Transform highestWay = transform;
        foreach (Transform way in waypoints)
        {
            highestWay = Vector3.Distance(transform.position, way.position) >= maxDist ? way : highestWay;
            maxDist = Vector3.Distance(transform.position, way.position) >= maxDist ? Vector3.Distance(transform.position, way.position) : maxDist;
        }
    }
}
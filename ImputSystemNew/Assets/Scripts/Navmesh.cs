using UnityEngine;
using UnityEngine.AI;

public class Navmesh : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;

    private void Update()
    {
        agent.SetDestination(player.position);
    }
}

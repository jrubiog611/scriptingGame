using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent enemyAgent;
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        InvokeRepeating("Move", 0f, 0.5f);
    }
    private void Move()
    {
        Debug.Log("I should be moving");
        if (GameManager.Instance.Player != null)
            enemyAgent.SetDestination(GameManager.Instance.Player.position);
    }
}

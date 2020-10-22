using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{

    public Transform player;
    public float speed, health, defense, attack;
    private NavMeshAgent enemyAgent;
    public Gun enemyGun;
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
    }
    void FixedUpdate()
    {
        // check first if the enemy is in range, then try to atk
        if (GameManager.Instance.Player != null)
        {
            if (Vector3.Distance(transform.position, GameManager.Instance.Player.position) <= enemyGun.Range)
            {
                Debug.Log("Estoy a rango");
                // cast a ray and if it hits then shoot the arrow
                Ray ray = new Ray(transform.position, transform.forward);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, enemyGun.Range))
                {
                    if (hit.collider.gameObject.CompareTag("Player"))
                    {
                        //stop te movement then atk
                        enemyAgent.isStopped = true;
                        Attack();
                        // then start moving again
                        StartCoroutine(StartMoving());
                    }
                }
            }
        }
    }

    private IEnumerator StartMoving()
    {
        yield return new WaitForSeconds(0.5f);
        enemyAgent.isStopped = false;
    }

    private void Attack()
    {
        enemyGun.Shoot();
    }
}

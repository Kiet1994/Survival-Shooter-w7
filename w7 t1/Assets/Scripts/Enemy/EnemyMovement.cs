using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    UnityEngine.AI.NavMeshAgent nav;
    EnemyHealth enemyHealth;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
    }


    void Update()
    {
        if (enemyHealth.CurrentHealth > 0)
        {
            nav.SetDestination(player.position);
        }
        else
        {
            nav.enabled = false;
        }
    }
}

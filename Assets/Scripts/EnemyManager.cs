using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public float startingHealth = 100;            // The amount of health the enemy starts the game with.
    public float currentHealth; 
    Transform player;
    NavMeshAgent navmesh;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        navmesh = GetComponent <NavMeshAgent> ();
        currentHealth = startingHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        //navmesh.SetDestination (player.position);
    }

    public void TakeDamage (float amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
            {
                // ... the enemy is dead.
                Destroy(gameObject);
        }
    }
}

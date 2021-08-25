using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public float startingHealth = 100;            // The amount of health the enemy starts the game with.
    public float currentHealth; 

    public AudioClip deathClip; 
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10; 
    GameObject player;
    PlayerManager playerManager;
    bool playerInRange; 
    float timer;
    AudioSource enemyAudio;
    Animator anim;
     


    Transform playerT;
    NavMeshAgent navmesh;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent <Animator> ();
        enemyAudio = GetComponent <AudioSource> ();
        player = GameObject.FindGameObjectWithTag ("Player");
        playerManager = player.GetComponent <PlayerManager> ();
        playerT = GameObject.FindGameObjectWithTag ("Player").transform;
        navmesh = GetComponent <NavMeshAgent> ();
        currentHealth = startingHealth;
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= timeBetweenAttacks && playerInRange)
            {
                Attack ();
            }
        //navmesh.SetDestination (playerT.position);
    }

    public void TakeDamage (float amount)
    {
        enemyAudio.Play ();
        currentHealth -= amount;
        if(currentHealth <= 0)
            {
                Death ();
                //Destroy(gameObject);
        }
    }

    void OnTriggerEnter (Collider other)
        {
            // If the entering collider is the player...
            if(other.gameObject == player)
            {
                // ... the player is in range.
                playerInRange = true;
            }
        }


    void OnTriggerExit (Collider other)
    {
        // If the exiting collider is the player...
        if(other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
        }
    }

    void Attack ()
    {
        timer = 0f;
        if(playerManager.currentHealth > 0)
        {
            // ... damage the player.
            playerManager.TakeDamage (attackDamage);
        }
    }

    void Death ()
        {
            anim.SetTrigger ("Dead");

            // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).
            enemyAudio.clip = deathClip;
            enemyAudio.Play ();
            Destroy (gameObject, 2f);
        }
}

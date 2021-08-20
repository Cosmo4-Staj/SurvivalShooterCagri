using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    Transform player;
    NavMeshAgent navmesh;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag ("Player").transform;
        navmesh = GetComponent <NavMeshAgent> ();
    }

    // Update is called once per frame
    void Update()
    {
        navmesh.SetDestination (player.position);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigosMovimiento : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent pathFinder;
    Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        pathFinder = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        pathFinder.SetDestination(target.position);
    }
}

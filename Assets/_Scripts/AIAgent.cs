using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIAgent : MonoBehaviour
{
    // Start is called before the first frame update

    public float lookRadius = 1f;
    public Transform midobj;

    Transform target;
    NavMeshAgent agent;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Ball").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 midposition = midobj.position;
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius && target.position.z > midposition.z + 0.5) 
        {
            agent.SetDestination(target.position);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}

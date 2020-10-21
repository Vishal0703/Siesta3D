using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIAgent : MonoBehaviour
{
    // Start is called before the first frame update

    public float lookRadius = 1f;
    public Transform midobj;
    public float jumpForce = 300f;

    Transform target;
    NavMeshAgent agent;
    float _vy;
    Rigidbody _rigidbody;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Ball").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 midposition = midobj.position;
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius && target.position.z > midposition.z + 0.4) 
        {
            agent.SetDestination(target.position);
            //DoJump();
        }
    }

    void DoJump()
    {
        // reset current vertical motion to 0 prior to jump
        _vy = 0f;
        // add a force in the up direction
        _rigidbody.AddForce(new Vector3(0, jumpForce, 0));
        // play the jump sound
        //PlaySound(jumpSFX);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnamyAITest : MonoBehaviour
{
    public float lookRadius = 10f;  // Detection range for player

    Transform target;   // Reference to the player
    NavMeshAgent agent; // Reference to the NavMeshAgent

    Animator animetionCon;
    // Use this for initialization
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();

        animetionCon = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            // Move towards the target
            agent.SetDestination(target.position);
            FaceTarget();   // Make sure to face towards the target
            animetionCon.SetBool("Idle", false);
            animetionCon.SetBool("Walk", true);
        }
        else
        {
            Stop();
            animetionCon.SetBool("Walk", false);
            animetionCon.SetBool("Idle", true);
        }

    }

    // Rotate to face the target
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

        
    }
    void Stop()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 0f);
    }

    // Show the lookRadius in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag( "Player"))
        {
            animetionCon.SetBool("Walk", false);
            animetionCon.SetBool("Attack", true);
        }

        else
        {
            animetionCon.SetBool("Attack", false);
            animetionCon.SetBool("Idle", true);
        }
    }
}

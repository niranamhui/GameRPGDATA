using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enamy : MonoBehaviour
{
    public float lookRadius = 10f;  // Detection range for player

    Transform target;   // Reference to the player
    NavMeshAgent agent; // Reference to the NavMeshAgent

    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public float sightRange, attackRange;

    public GameObject Projack;
    // Use this for initialization
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        
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
         }

        }

    // Rotate to face the target
    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void AttackPlayer()
    {
        agent.SetDestination(transform.position);

        transform.LookAt(target);


        if (!alreadyAttacked)
        {
            Rigidbody rd = Instantiate(Projack, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rd.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rd.AddForce(transform.up * 8f, ForceMode.Impulse);

            alreadyAttacked = true;
            //Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    // Show the lookRadius in editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boood"))
        {
            Destroy(this.gameObject);
        }
    }
}

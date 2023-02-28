using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // pointler arasi hereket
    //public GameObject[] wayPoints;

    public Animator animator;

    public AudioClip zombieSound;
    private AudioSource zombieAudio;




    int currentWP = 0;
    [SerializeField]
    private float speed = 10.00f;
    public float rotSpeed = 1f;

    // oyuncunu izle
    public float lookRadius = 20f;


    Transform target;
    target target1;
    NavMeshAgent agent;

    void Awake()
    {
        zombieAudio = GetComponent<AudioSource>();
        target = PlayerManager.instance.player.transform;
        target1 = GetComponent<target>();
        agent = GetComponent<NavMeshAgent>();

    }


    void Update()
    {

        float distance = Vector3.Distance(target.transform.position, transform.position);


       
        if (distance <= lookRadius && target1.isDead==false)
        {
            FaceTarget();
            agent.SetDestination(target.position);
            animator.SetBool("Walk", false);
            animator.SetBool("Scream", true);
            agent.speed = 0;
            agent.angularSpeed = 0;
            agent.acceleration = 0;
            StartCoroutine(walking());


            if (distance <= agent.stoppingDistance)
            {
                // Attack the player
                //Face the Target
                
                
                FaceTarget();
                zombieAudio.PlayOneShot(zombieSound, 1f);
            }
        }
        

        /*if (distance > lookRadius && target1.isDead == false)
        {
            if (Vector3.Distance(this.transform.position, wayPoints[currentWP].transform.position) <= 3)
            {
                currentWP++;
            }
            if (currentWP >= wayPoints.Length)
            {
                currentWP = 0;
            }
            //this.transform.LookAt(wayPoints[currentWP].transform);
            Quaternion lookAtWP = Quaternion.LookRotation(wayPoints[currentWP].transform.position - this.transform.position);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookAtWP, rotSpeed * Time.deltaTime);
            this.transform.Translate(0, 0, speed * Time.deltaTime);
            
        }*/

    }


    IEnumerator walking()
    {
        yield return new WaitForSeconds(3.0f);

        animator.SetBool("Walk", true);
        animator.SetBool("Scream", false);
        agent.speed = 4;
        agent.angularSpeed = 120;
        agent.acceleration = 8;

    }


    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }
}

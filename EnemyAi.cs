using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 


public class EnemyAi : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] public LayerMask playerMask;

    [SerializeField] private bool  inAttackRange;
    [SerializeField] private float attackTimer; 
    [SerializeField] private float timeBetweenAttack;
    [SerializeField] private bool  attacked;
    [SerializeField] private float attackRange;

    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed; 

    [SerializeField] private GameObject[] systems;
    [SerializeField] private ShipSystems targetSystem;

    [SerializeField] private float hackingTimer;
    [SerializeField] private float maxHackingTimer;

    [SerializeField] private float hackNum;
    [SerializeField] private float hackChance;

    [SerializeField] private bool targetingSystem; 

    // Start is called before the first frame update
    void Start()
    {
        targetingSystem = Random.Range(0.0f, 1.0f) > 0.5f ? true : false;

        if (targetingSystem)
        {
            targetSystem = systems[Random.Range(0, 3)].GetComponent<ShipSystems>();
        }

        agent = GetComponent<NavMeshAgent>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(targetingSystem)
        {
            MoveToSystem(); 
        }
        else
        {
            if (!inAttackRange)
                ChasePlayer();
            else
                AttackPlayer(); 
        }

        if (attacked)
            attackTimer -= Time.deltaTime; 

    }

    private void MoveToSystem()
    {
        agent.SetDestination(targetSystem.transform.position); 
    }

    private void HackingSystem()
    {
        // Beign hackSystem
        hackingTimer -= Time.deltaTime; 

        if(hackingTimer <= 0 && !targetSystem.systemFailed)
        {
            hackNum = Random.Range(0.0f, 1.0f);

            if (hackNum >= hackChance)
                targetSystem.TriggerFailure(); 
        }
    }

    private void ChasePlayer()
    {
        if (agent.isOnNavMesh)
            agent.SetDestination(Player.Instance.transform.position);


        Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange, playerMask);

        foreach (var col in colliders)
        {
            if (col.transform.tag == "Player")
            {
                inAttackRange = true;
            }
            else
            {
                inAttackRange = false;
            }
        }
    }

    private void AttackPlayer()
    {
        if(attackTimer <= 0)
        {
            //Shoot();
            attackTimer = timeBetweenAttack; 
        }
        Debug.Log("Attacking Player"); 
    }

    private void Shoot() 
    {
        GameObject tempBullet = Instantiate(bullet, transform.position, transform.rotation);

        tempBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);

        attacked = true; 
    }
}

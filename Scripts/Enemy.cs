using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.AI.NavMeshAgent agent;

    private Player player;

    [SerializeField]
    private int health;

    [SerializeField]
    private Rigidbody body; 

    [SerializeField]
    private GameObject deathParticles;

    [SerializeField]
    private int strength; 

    [SerializeField]
    private float damageForce; 

    [Header("Sounds")]
    [SerializeField]
    private AudioSource damageSound;

    [SerializeField]
    private AudioSource deathSound; 

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(agent.isOnNavMesh)
            agent.SetDestination(Player.Instance.transform.position);

        if (health <= 0)
            Die(); 
    }

    void Die()
    {

        Instantiate(deathParticles, transform.position, Quaternion.identity);
        Destroy(gameObject); 
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        body.AddForce(-transform.forward * damageForce, ForceMode.VelocityChange);
    }

    private void AttackPlayer()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Player.Instance.TakeDamage(strength);
            Player.Instance.ToggleInvuln(); 
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Bullet")
        {
            TakeDamage(1); 
            damageSound.Play(); 
        }
    }

    private void OnDestroy()
    {
        deathSound.Play();
    }
}

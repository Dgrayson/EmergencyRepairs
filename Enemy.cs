using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.AI.NavMeshAgent agent;

    private Player player;

    public float speed;

    public int health;

    public Rigidbody body; 

    public GameObject deathParticles;

    public float damageForce; 

    public AudioSource damageSound;
    public AudioSource deathSound; 

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class Enemy : MonoBehaviour
{
    public NavMeshAgent agent; 
    
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

    [SerializeField] private GameObject healthBox; 

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (agent.isOnNavMesh)
            agent.SetDestination(Player.Instance.transform.position);*/ 

        if (health <= 0)
            Die(); 
    }

    void Die()
    {

        Instantiate(deathParticles, transform.position, Quaternion.identity);

        if (Random.Range(0.0f, 1.0f) < 0.4f)
        {
            Debug.Log("SPawning health");
            Instantiate(healthBox, transform.position, Quaternion.identity);
        }

        if (gameObject != null)
            deathSound.Play();

        EnemyWaves.Instance.totalEnemies.Remove(this.gameObject); 

        Destroy(gameObject); 
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        body.velocity = Vector3.zero; 
        body.AddForce(-transform.forward * damageForce, ForceMode.VelocityChange);
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

    }
}

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

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(Player.Instance.transform.position);

        if (health <= 0)
            Die(); 
    }

    void Die()
    {
        Destroy(gameObject); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 1; 
        }
    }


}

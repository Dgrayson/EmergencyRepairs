using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float timer = 2.0f; 

    public GameObject explosionParticles;

    public int damage = 5;
    public float radius; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f)
            Explode(); 
    }

    void Explode()
    {
        Instantiate(explosionParticles, transform.position, Quaternion.identity);

        Collider[] colliders = Physics.OverlapSphere(transform.position, radius); 

        foreach(Collider target in colliders)
        {
            Enemy enemy = target.GetComponent<Enemy>(); 

            if(enemy != null)
            {
                enemy.TakeDamage(damage); 
            }
        }

        Destroy(gameObject); 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticles : MonoBehaviour
{
    public AudioSource deathSound; 
    public float timer = 5.0f; 

    // Start is called before the first frame update
    void Start()
    {
        deathSound.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0.0f)
            Destroy(gameObject); 
    }
}

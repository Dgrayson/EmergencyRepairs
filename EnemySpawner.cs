using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float xOffset;
    public float zOffset;

    public float timer; 

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
        ResetTimer(); 
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; 

        if(timer <= 0)
        {
            SpawnEnemies();
            ResetTimer(); 
        }
    }

    public void SpawnEnemies()
    {
        int numEnemies = Random.Range(1, 6);

        for (int i = 0; i < numEnemies; i++) {
            Vector3 pos = new Vector3(Random.Range(transform.position.x - xOffset, transform.position.x + xOffset), transform.position.y, Random.Range(transform.position.z - zOffset, transform.position.z + zOffset));
            Instantiate(enemy, pos, Quaternion.identity);
        }
    }

    private void ResetTimer()
    {
        timer = Random.Range(5.0f, 15.0f);
    }
}

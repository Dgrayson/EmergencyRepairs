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
    }

    // Update is called once per frame
    void Update()
    {
    }

    public List<GameObject> SpawnEnemies(int min, int max)
    {
        List<GameObject> enemies = new List<GameObject>(); 

        int numEnemies = Random.Range(min, max);

        for (int i = 0; i < numEnemies; i++) {
            Vector3 pos = new Vector3(Random.Range(transform.position.x - xOffset, transform.position.x + xOffset), transform.position.y, Random.Range(transform.position.z - zOffset, transform.position.z + zOffset));
            enemies.Add(Instantiate(enemy, pos, Quaternion.identity));
        }

        return enemies;
    }

    public void SpawnSmallerWave()
    {

    }

    private void ResetTimer()
    {
        timer = Random.Range(5.0f, 15.0f);
    }
}

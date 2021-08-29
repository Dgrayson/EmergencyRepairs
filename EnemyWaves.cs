using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    private static EnemyWaves _instance;

    public static EnemyWaves Instance { get { return _instance; } }

    [SerializeField]
    private EnemySpawner[] spawners;

    public List<GameObject> totalEnemies;

    [SerializeField] private float timer;
    [SerializeField] private float maxTimer;

    public int minSpawnNum;
    public int maxSpawnNum;

    // Start is called before the first frame update
    void Start()
    {
        if (_instance == null || _instance != this)
            _instance = this;

        SpawnEnemies(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(totalEnemies.Count == 0)
        {
            timer -= Time.deltaTime; 

            if(timer <= 0)
            {
                SpawnEnemies();
                timer = maxTimer; 
            }
        }
    }

    private void SpawnEnemies()
    {
        foreach (var spawner in spawners)
        {
            totalEnemies.AddRange(spawner.GetComponent<EnemySpawner>().SpawnEnemies(minSpawnNum, maxSpawnNum));
        }

        minSpawnNum++;
        maxSpawnNum++; 
    }
}

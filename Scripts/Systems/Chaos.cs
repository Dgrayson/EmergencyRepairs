using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaos : MonoBehaviour
{
    public float maxTimer = 15.0f; 
    public float timer = 15.0f;

    public float chaosDelta = .1f;

    public NavSystem navSystem;
    public GravitySystem gravitySystem;
    public OxygenSystem oxygenSystem; 

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime; 

        if(timer <= 0.0f)
        {
            if(!navSystem.systemFailed)
                ChaosTrigger(navSystem);
            
            if(!gravitySystem.systemFailed)
                ChaosTrigger(gravitySystem);

            if (!oxygenSystem.systemFailed)
                ChaosTrigger(oxygenSystem);

            timer = maxTimer; 
        }
    }

    private void ChaosTrigger(ShipSystems system)
    {
        float randomNum = Random.Range(0.0f, 1.0f);

        if (system.currFailChance > randomNum)
        {
            system.TriggerFailure();
            IncrementFailChance(system); 
        }
        else
        {
            IncrementFailChance(system);
        }
    }

    private void IncrementFailChance(ShipSystems system)
    {
        system.maxFailChance += chaosDelta;
        system.currFailChance = system.maxFailChance; 
    }
}

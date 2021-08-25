using UnityEngine;

public class NavSystem : ShipSystems
{

    public ParticleSystem sparksParticles;
    public override void Restoresystem()
    {
        systemFailed = false;
        currFailChance = currFailChance / 2.0f;
        sparksParticles.Clear(); 
    }

    public override void TriggerFailure()
    {
        Debug.Log("Nav System Failed");
        systemFailed = true;
        repairValue = 0;

        sparksParticles.Play(); 
    }
}

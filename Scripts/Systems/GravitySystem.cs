using UnityEngine;

public class GravitySystem : ShipSystems
{
    public ParticleSystem sparksParticles;

    public override void Restoresystem()
    {
        systemFailed = false;
        sparksParticles.Clear(); 

        Debug.Log("Gravity Repaired");
    }

    public override void TriggerFailure()
    {
        Debug.Log("Gravity System Failed");
        systemFailed = true;
        repairValue = 0;
        sparksParticles.Play(); 
    }
}

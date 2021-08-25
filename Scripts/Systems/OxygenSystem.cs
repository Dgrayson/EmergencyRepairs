using UnityEngine;

public class OxygenSystem : ShipSystems
{

    public ParticleSystem sparksParticles;
    public override void Restoresystem()
    {
        systemFailed = false;
        sparksParticles.Clear(); 
    }

    public override void TriggerFailure()
    {
        Debug.Log("Oxygen Failure!");
        systemFailed = true;
        repairValue = 0;

        sparksParticles.Play(); 
    }
}

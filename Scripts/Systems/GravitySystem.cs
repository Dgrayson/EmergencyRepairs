using UnityEngine;

public class GravitySystem : ShipSystems
{
    public override void Restoresystem()
    {
        systemFailed = false;


        Debug.Log("Gravity Repaired");
    }

    public override void TriggerFailure()
    {
        Debug.Log("Gravity System Failed");
        systemFailed = true;
        repairValue = 0; 
    }
}

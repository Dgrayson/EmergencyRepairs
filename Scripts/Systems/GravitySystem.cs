using UnityEngine;

public class GravitySystem : ShipSystems
{
    public override void Restoresystem()
    {
        throw new System.NotImplementedException();
    }

    public override void TriggerFailure()
    {
        Debug.Log("Gravity System Failed");
        
    }
}

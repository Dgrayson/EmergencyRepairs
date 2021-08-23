using UnityEngine;

public class OxygenSystem : ShipSystems
{
    public override void Restoresystem()
    {
        throw new System.NotImplementedException();
    }

    public override void TriggerFailure()
    {
        Debug.Log("Oxygen Failure!"); 
    }
}

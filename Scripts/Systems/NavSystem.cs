using UnityEngine;

public class NavSystem : ShipSystems
{
    public override void Restoresystem()
    {
        throw new System.NotImplementedException();
    }

    public override void TriggerFailure()
    {
        Debug.Log("Nav System Failed"); 
       
    }
}

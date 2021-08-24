using UnityEngine;

public class NavSystem : ShipSystems
{
    public override void Restoresystem()
    {
        systemFailed = false;

        Debug.Log("Nav System Restored");
    }

    public override void TriggerFailure()
    {
        Debug.Log("Nav System Failed");
        systemFailed = true;
        repairValue = 0;
    }
}

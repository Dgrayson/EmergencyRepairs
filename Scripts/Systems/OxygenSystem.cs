using UnityEngine;

public class OxygenSystem : ShipSystems
{
    public override void Restoresystem()
    {
        systemFailed = false;

        Debug.Log("Oxygen Repaired!");
    }

    public override void TriggerFailure()
    {
        Debug.Log("Oxygen Failure!");
        systemFailed = true;
        repairValue = 0;
    }
}

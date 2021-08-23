using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipSystems : MonoBehaviour
{
    public float maxFailChance = .1f;
    public float currFailChance = .1f;
    public bool systemFailed = false; 

    public abstract void TriggerFailure();
    public abstract void Restoresystem(); 
}

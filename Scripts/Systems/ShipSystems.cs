using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShipSystems : MonoBehaviour
{
    public float maxFailChance = .1f;
    public float currFailChance = .1f;
    public float repairValue = 100.0f;
    public float maxRepairValue = 100.0f;
    public bool systemFailed = false;

    public AudioSource explosionSound; 

    public abstract void TriggerFailure();
    public abstract void Restoresystem(); 
}

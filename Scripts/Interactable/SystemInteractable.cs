using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SystemInteractable : Interactable
{
    public enum SystemStatus
    {
        Fine, 
        Warning, 
        Danger, 
        Error
    }

    public float repairStatus = 600;
    public SystemStatus currSystemStatus = SystemStatus.Fine;
    public bool repairing = false; 
}

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

    public enum SystemType
    {
        Navigation, 
        Oxygen, 
        Gravity
    }

    protected GameObject repairBarParent; 
}

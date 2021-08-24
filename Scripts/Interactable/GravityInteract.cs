using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityInteract : SystemInteractable
{
    public SystemStatus currSystemStatus = SystemStatus.Fine;
    public bool repairing = false;
    public SystemType systemType;

    public GravitySystem gravSystem; 

    float repairSpeed = 5;

    public override void ClearHit()
    {
        intearactText.enabled = false;
        repairing = false;
    }

    public override void Interact()
    {
        repairing = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        gravSystem.repairValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (repairing && gravSystem.repairValue < 100 && gravSystem.systemFailed)
        {
            gravSystem.repairValue += repairSpeed * Time.deltaTime;
            //Debug.Log("Repairing " + repairStatus + "%");


            repairBarImage.rectTransform.sizeDelta = new Vector2(6 * (gravSystem.repairValue / 100), 0.8f);
        }

        if(gravSystem.repairValue >= 100 && gravSystem.systemFailed)
        {
            gravSystem.Restoresystem(); 
        }
    }
}

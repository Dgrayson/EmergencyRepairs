using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenInteract : SystemInteractable
{
    public SystemStatus currSystemStatus = SystemStatus.Fine;
    public bool repairing = false;
    public SystemType systemType;

    public OxygenSystem oxygenSystem; 

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

    }

    // Update is called once per frame
    void Update()
    {
        if (repairing && oxygenSystem.repairValue < 100 && oxygenSystem.systemFailed)
        {
            oxygenSystem.repairValue += repairSpeed * Time.deltaTime;
            //Debug.Log("Repairing " + repairStatus + "%");


            repairBarImage.rectTransform.sizeDelta = new Vector2(6 * (oxygenSystem.repairValue / 100), 0.8f);
        }

        if (oxygenSystem.repairValue >= 100 && oxygenSystem.systemFailed)
        {
            oxygenSystem.Restoresystem();  
        }
    }
}

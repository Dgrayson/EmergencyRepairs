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
        repairBarParent.SetActive(false);
    }

    public override void Interact()
    {
        Player.Instance.body.velocity = Vector3.zero;

        repairSpeed = Player.Instance.systemRepairSpeed; 
        repairing = true;

        if(gravSystem.systemFailed)
            repairBarParent.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        gravSystem.repairValue = 0;
        repairBarParent = repairBarImage.transform.parent.gameObject;
        repairBarParent.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gravSystem.repairValue == 0 && repairBarImage.rectTransform.sizeDelta.x != 0)
        {
            repairBarImage.rectTransform.sizeDelta = new Vector2(0.0f, 0.8f);
        }

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

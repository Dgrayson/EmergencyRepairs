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
        repairBarParent.SetActive(false);
    }

    public override void Interact()
    {
        repairSpeed = Player.Instance.SystemRepairSpeed;
        Player.Instance.Body.velocity = Vector3.zero;
        repairing = true;

        if(oxygenSystem.systemFailed)
            repairBarParent.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        repairBarParent = repairBarImage.transform.parent.gameObject;
        repairBarParent.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (oxygenSystem.repairValue == 0 && repairBarImage.rectTransform.sizeDelta.x != 0)
        {
            repairBarImage.rectTransform.sizeDelta = new Vector2(0.0f, 0.8f);
        }


        if (repairing && oxygenSystem.repairValue < 100 && oxygenSystem.systemFailed)
        {
            oxygenSystem.repairValue += repairSpeed * Time.deltaTime;

            repairBarImage.rectTransform.sizeDelta = new Vector2(6 * (oxygenSystem.repairValue / 100), 0.8f);
            oxygenSystem.oxygenBarUI.rectTransform.sizeDelta = new Vector2(500 * (oxygenSystem.repairValue / 100), 50.0f);
        }

        if (oxygenSystem.repairValue >= 100 && oxygenSystem.systemFailed)
        {
            oxygenSystem.Restoresystem();  
        }
    }
}

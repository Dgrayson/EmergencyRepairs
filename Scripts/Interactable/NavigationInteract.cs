using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class NavigationInteract : SystemInteractable
{
    public NavSystem navSystem; 

    public SystemStatus currSystemStatus = SystemStatus.Fine;
    public bool repairing = false;
    public SystemType systemType;
     

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

        if(navSystem.systemFailed)
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
        if (navSystem.repairValue == 0 && repairBarImage.rectTransform.sizeDelta.x != 0)
        {
            repairBarImage.rectTransform.sizeDelta = new Vector2(0.0f, 0.8f);
        }

        if (repairing && navSystem.repairValue < 100 && navSystem.systemFailed)
        {
            navSystem.repairValue += repairSpeed * Time.deltaTime;
            //Debug.Log("Repairing " + repairStatus + "%");


            repairBarImage.rectTransform.sizeDelta = new Vector2(6 * (navSystem.repairValue / 100), 0.8f);
        }

        if(navSystem.repairValue >= 100 && navSystem.systemFailed)
        {
            navSystem.Restoresystem(); 
        }
    }

}

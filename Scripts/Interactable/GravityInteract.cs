using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityInteract : SystemInteractable
{
    public float repairStatus = 600;
    public SystemStatus currSystemStatus = SystemStatus.Fine;
    public bool repairing = false;
    public SystemType systemType;

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
        repairStatus = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (repairing && repairStatus < 100)
        {
            repairStatus += repairSpeed * Time.deltaTime;
            Debug.Log("Repairing " + repairStatus + "%");


            repairBarImage.rectTransform.sizeDelta = new Vector2(6 * (repairStatus / 100), 0.8f);
        }
    }
}

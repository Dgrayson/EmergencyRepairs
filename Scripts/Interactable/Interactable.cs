using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public abstract class Interactable : MonoBehaviour
{
    public float maxRepairBarWidth = 6;

    public Image repairBarImage;     
    public TextMeshProUGUI intearactText; 

    public abstract void Interact();

    public abstract void ClearHit(); 

    public void ClearRepairBarImage()
    {
        repairBarImage.rectTransform.sizeDelta = new Vector2(0.0f, 0.8f);
    }
}

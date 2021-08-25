using UnityEngine;
using UnityEngine.UI; 

public class OxygenSystem : ShipSystems
{

    public float oxygenValue = 100f;
    public Image oxygenBarUI; 
    public ParticleSystem sparksParticles;

    public override void Restoresystem()
    {
        systemFailed = false;
        sparksParticles.Clear(); 
    }

    public override void TriggerFailure()
    {
        Debug.Log("Oxygen Failure!");
        systemFailed = true;
        repairValue = 0;

        oxygenBarUI.rectTransform.sizeDelta = new Vector2(0, 50);
        sparksParticles.Play(); 
    }
}

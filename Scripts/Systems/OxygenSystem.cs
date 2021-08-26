using UnityEngine;
using UnityEngine.UI; 

public class OxygenSystem : ShipSystems
{

    public float oxygenValue = 100f;
    public GameObject oxygenUIObject; 
    public Image oxygenBarUI; 
    public ParticleSystem sparksParticles;

    public override void Restoresystem()
    {
        oxygenUIObject.SetActive(false);
        systemFailed = false;
        sparksParticles.Clear();

        currFailChance = currFailChance * .2f;
    }

    public override void TriggerFailure()
    {
        Debug.Log("Oxygen Failure!");
        systemFailed = true;
        repairValue = 0;

        oxygenUIObject.SetActive(true);
        oxygenBarUI.rectTransform.sizeDelta = new Vector2(0, 50);
        sparksParticles.Play();
        explosionSound.Play();

        
    }
}

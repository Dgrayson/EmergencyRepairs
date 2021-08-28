using UnityEngine;
using UnityEngine.UI; 

public class OxygenSystem : ShipSystems
{

    public float oxygenValue = 100f;
    public float oxygenDecreaseRate = 5f;
    public float oxygenIncreaseRate = 2.5f;

    public GameObject oxygenUIObject; 
    public Image oxygenBarUI; 
    public ParticleSystem sparksParticles;

    public override void Restoresystem()
    {
        oxygenUIObject.SetActive(false);
        systemFailed = false;
        sparksParticles.Clear();

        currFailChance = currFailChance * .2f;

        //SystemsManager.Instance.LightsOnline = true;
        //SystemsManager.Instance.UpdateStatus();
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

        //SystemsManager.Instance.LightsOnline = false;
        //SystemsManager.Instance.UpdateStatus();


    }

    private void Update()
    {
        if (systemFailed)
            oxygenValue -= oxygenDecreaseRate * Time.deltaTime;
        else if (oxygenValue < 100.0f)
            oxygenValue += oxygenIncreaseRate * Time.deltaTime; 

        oxygenBarUI.rectTransform.sizeDelta = new Vector2(500 * (oxygenValue / 100), 50.0f);

        if(oxygenValue <= 0.0f)
        {
            Player.Instance.Die(); 
        }
    }
}

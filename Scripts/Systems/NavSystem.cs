using System.Collections.Generic;
using UnityEngine;

public class NavSystem : ShipSystems
{
    public Light[] lights;
    public List<float> defaultLightIntensity; 

    public ParticleSystem sparksParticles;

    private void Start()
    {
        foreach (var _light in lights)
        {
            defaultLightIntensity.Add(_light.intensity); 
        }
    }

    public override void Restoresystem()
    {
        systemFailed = false;
        currFailChance = currFailChance * .2f;
        sparksParticles.Clear();

        var i = 0; 

        foreach (var _light in lights)
        {
            _light.intensity = defaultLightIntensity[i];

            i++; 
        }

        //SystemsManager.Instance.LightsOnline = true; 
        //SystemsManager.Instance.UpdateStatus();
    }

    public override void TriggerFailure()
    {
        Debug.Log("Nav System Failed");
        systemFailed = true;
        repairValue = 0;

        foreach(var _light in lights)
        {
            _light.intensity = 0.0f; 
        }

        //SystemsManager.Instance.LightsOnline = false;
        //SystemsManager.Instance.UpdateStatus();

        sparksParticles.Play();
        explosionSound.Play();
    }
}

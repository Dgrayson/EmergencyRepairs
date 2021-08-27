using UnityEngine;

public class GravitySystem : ShipSystems
{
    public ParticleSystem sparksParticles;
    public float gravityForce;

    public Vector3 defaultGravity = Physics.gravity; 

    public override void Restoresystem()
    {
        systemFailed = false;
        sparksParticles.Clear();

        currFailChance = currFailChance * .2f;

        Debug.Log("Gravity Repaired");

        Physics.gravity = defaultGravity;

        //SystemsManager.Instance.GravityOnline = true;
        //SystemsManager.Instance.UpdateStatus(); 

        Player.Instance.GetComponent<Rigidbody>().AddForce(-Vector3.up * gravityForce, ForceMode.Impulse);
    }

    public override void TriggerFailure()
    {
        Debug.Log("Gravity System Failed");
        systemFailed = true;
        repairValue = 0;
        sparksParticles.Play();
        explosionSound.Play();

        //SystemsManager.Instance.GravityOnline = false;
        //SystemsManager.Instance.UpdateStatus();

        Physics.gravity = Vector3.zero;

        Player.Instance.GetComponent<Rigidbody>().AddForce(Vector3.up * gravityForce, ForceMode.Impulse);
    }
}

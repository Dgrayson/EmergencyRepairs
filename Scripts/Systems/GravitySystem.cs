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

        Debug.Log("Gravity Repaired");

        Physics.gravity = defaultGravity;

        Player.Instance.GetComponent<Rigidbody>().AddForce(-Vector3.up * gravityForce, ForceMode.Impulse);
    }

    public override void TriggerFailure()
    {
        Debug.Log("Gravity System Failed");
        systemFailed = true;
        repairValue = 0;
        sparksParticles.Play();

        Physics.gravity = Vector3.zero;

        Player.Instance.GetComponent<Rigidbody>().AddForce(Vector3.up * gravityForce, ForceMode.Impulse);
    }
}

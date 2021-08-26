using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Pickup : MonoBehaviour
{

    public PickupType type;
    public int healValue;

    public PickupObject pickupObject;

    private void Start()
    {
        Instantiate(pickupObject.pickupMesh, transform.position, transform.rotation); 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PickupEffect(collision.gameObject); 
        }

        Destroy(gameObject);
    }

    private void PickupEffect(GameObject player)
    {
        switch(type)
        {
            case PickupType.Health:
                player.GetComponent<Player>().HealDamage(healValue); 
                break;
            case PickupType.Ammo:
                player.GetComponent<PlayerShoot>().RefillAmmo(); 
                break;
            case PickupType.Grenade:
                player.GetComponent<PlayerShoot>().RefillGrenade(); 
                break; 
        }
    }
}

public class HealthPickup : Pickup
{

}

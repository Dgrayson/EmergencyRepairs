using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Pickup", menuName = "ScriptableObjects/PickupObject", order =1)]
public class PickupObject : ScriptableObject
{

    public GameObject pickupMesh;
    public PickupType pickupType; 
}

[CreateAssetMenu(fileName = "HealthObject", menuName = "ScriptableObjects/HealthObject", order = 2)]
public class HealthObject : PickupObject
{
    public int healValue; 
}
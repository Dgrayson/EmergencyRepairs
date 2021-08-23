using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipSystems : MonoBehaviour
{

    public bool gravity;
    public bool o2;
    public bool navigation;

    public float remainingO2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculateO2(); 
    }

    private void CalculateO2()
    {
        if(!o2)
        {
            remainingO2 -= Time.deltaTime; 
        }
    }


}

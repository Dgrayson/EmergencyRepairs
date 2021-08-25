using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player _instance;

    public static Player Instance { get { return _instance; } }

    public float systemRepairSpeed = 10; 
    
    // Start is called before the first frame update
    void Start()
    {
        if (_instance == null || _instance != this)
            _instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateRepairSpeed(float repairSpeed)
    {
        systemRepairSpeed = repairSpeed; 
    }
}

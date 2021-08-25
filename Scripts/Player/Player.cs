using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player _instance;

    public static Player Instance { get { return _instance; } }

    public float systemRepairSpeed = 10;

    public Rigidbody body; 
    
    // Start is called before the first frame update
    void Start()
    {
        if (_instance == null || _instance != this)
            _instance = this;

        body = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= 4.0f)
        {
            body.velocity = new Vector3(body.velocity.x, 0.0f, body.velocity.z);
            transform.position = new Vector3(transform.position.x, 3.999f, transform.position.z);
        }
    }

    public void UpdateRepairSpeed(float repairSpeed)
    {
        systemRepairSpeed = repairSpeed; 
    }
}

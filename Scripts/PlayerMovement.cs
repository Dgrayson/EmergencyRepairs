using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody body;

    [SerializeField]
    private float moveSpeed;

    private bool moving; 
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if(Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
        {
            moving = true; 
        }
        else
        {
            moving = false;
            body.velocity = Vector3.zero; 
        }*/

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        body.AddForce(movement * moveSpeed); 
    }


}

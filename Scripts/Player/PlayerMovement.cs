using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody body;

    [SerializeField]
    private float moveSpeed;

    private bool moving; 

    [SerializeField]
    private float rotOffset = 90.0f;

    [SerializeField]
    private float dashSpeed = 20; 

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>(); 
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        body.velocity = movement * moveSpeed;

        if (Input.GetKeyDown(KeyCode.LeftShift))
            Dash(movement);
        
        RotateTowardMouse(); 
    }

    void Dash(Vector3 movement)
    {
        //body.velocity = movement * moveSpeed * dashSpeed; 
        body.AddForce(movement * moveSpeed * dashSpeed, ForceMode.Impulse);
    }

    void RotateTowardMouse()
    {
        Vector2 screenPos = Camera.main.WorldToViewportPoint(transform.position);

        Vector2 mousePos = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition);

        float angle = AngleBetweenTwoPoints(screenPos, mousePos);

        transform.rotation = Quaternion.Euler(new Vector3(0, -angle + rotOffset, 0)); 
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg; 
    }
}

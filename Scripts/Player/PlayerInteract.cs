using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    private Ray ray;
    private RaycastHit hit;

    public float rayLength = 25f;
    public float yOffset = 1.0f;

    public Camera cam; 

    [SerializeField]
    public Interactable interactObject;

    public bool detectingObject = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        ray = new Ray(transform.position, fwd); 
        Debug.DrawRay(transform.position, fwd * rayLength, Color.blue); 

        if(Physics.Raycast(ray, out hit, rayLength))
        {
            if(hit.transform.gameObject.GetComponent<Interactable>())
            {
                Debug.Log("Hit object");

                interactObject = hit.transform.gameObject.GetComponent<Interactable>();
                interactObject.intearactText.enabled = true; 

                if(Input.GetKey(KeyCode.E))
                {
                    interactObject.Interact();
                }
                else
                {
                    interactObject.ClearHit(); 
                }
            }
            else
            {

                if(interactObject != null)
                {
                    interactObject.ClearHit();
                    interactObject = null; 
                }
            }
        }
    }
}

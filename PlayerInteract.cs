using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    public Interactable interactObject; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.layer == 6 && interactObject == null)
        {
            interactObject = collision.gameObject.GetComponent<Interactable>(); 
        }

        if(interactObject != null)
            Debug.Log("Found Interactable"); 
    }

    private void OnTriggerExit(Collider collision)
    {
        interactObject = null; 
    }
}

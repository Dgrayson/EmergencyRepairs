using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource audioClip; 

    // Start is called before the first frame update
    void Start()
    {
        audioClip.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

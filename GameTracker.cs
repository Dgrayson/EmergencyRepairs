using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTracker : MonoBehaviour
{

    public float winTimer;

    public TextMeshProUGUI timer; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        winTimer -= 2 * Time.deltaTime;

        if (winTimer <= 0)
            MenuControl.Instance.DispalyWinScreen();

        timer.text = Mathf.RoundToInt(winTimer).ToString(); 
    }
}
